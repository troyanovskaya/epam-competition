import { Component, OnInit } from '@angular/core';
import { FormArray, FormControl, FormGroup, Validators } from '@angular/forms';
import { UnitType } from '../../../schema/unitType.model'
import { HttpRequestService } from 'src/app/services/http-request.service';
import { MatDialogRef } from '@angular/material/dialog';
import { Category } from 'src/app/schema/category.model';
import { catchError, of, tap } from 'rxjs';
import { LocalStorageService } from 'src/app/local-storage.service';
import { User } from 'src/app/schema/user.model';
import { Vendor } from 'src/app/schema/vendor.model';
import { PublishedGoodsService } from 'src/app/services/published-goods.service';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Component({
  selector: 'app-vendor-good-craeation',
  templateUrl: './vendor-good-craeation.component.html',
  styleUrls: ['./vendor-good-craeation.component.css']
})
export class VendorGoodCraeationComponent{

  units: UnitType[] = [];
  selectedUnitId!:string;
  categories: Category[]=[];
  selectedCategoryId!:string;
  user!: Object;
  vendorId!: string;
  headers!: HttpHeaders;

  constructor(
    private http: HttpRequestService, 
    private httpPost: HttpClient,
    private getUserService : PublishedGoodsService,
    private dialogRef: MatDialogRef<VendorGoodCraeationComponent>,
    private localStorageService: LocalStorageService,) { 
      let user = localStorage.getItem('user');
      if(user){
        let user1:{token:string, validTo:string} = JSON.parse(localStorage.getItem('user')??JSON.stringify({token:'none', validTo:'none'}));
        this.headers =new HttpHeaders();
        this.headers = this.headers.set('Authorization', 'Bearer ' + user1.token)
        if(this.getUserService.getDecodedAccessToken(user1.token)){
          let userId = this.getUserService.getDecodedAccessToken(user1.token).sub;
          this.http.getVendor(userId).subscribe((vendor: Vendor) => {
            this.vendorId = vendor.id;
            console.log(this.vendorId);
        })
      }
    }
  }

  ngOnInit() {
    this.http.getUnitTypes().subscribe((unitList: Array<UnitType>) => {
        this.units=unitList;
        this.selectedUnitId = this.units[0].id;
    });
    this.http.getCategories().subscribe((categoryList: Array<Category>) => {
      this.categories=categoryList;
      this.selectedCategoryId = this.categories[0].id;
  });
  } 

  goodForm = new FormGroup({
    name: new FormControl('', [
      Validators.required,
      Validators.pattern("^[a-zA-Z\s]*$")
    ]),
    description: new FormControl('', [
      Validators.required,
      Validators.minLength(5),
      Validators.maxLength(250)
    ]),
    price: new FormControl(1, [
      Validators.required,
      Validators.min(0.1)
    ]),
    discount: new FormControl(0, [
      Validators.required,
      Validators.min(0)
    ]),
    unit: new FormControl(''),
    amount: new FormControl(0, [
      Validators.required,
      Validators.min(0)
    ]),
    poster: new FormControl('', [
      Validators.required,
    ]),
    image:new FormControl('',[
      Validators.required,
      Validators.minLength(5)
    ]),
    category:new FormControl(''),
    
  })

  createGood(){
    this.httpPost.post('https://localgoodsapi.azurewebsites.net/api/Products',{
        name: this.goodForm.value.name,
        description: this.goodForm.value.description,
        price: this.goodForm.value.price,
        poster: this.goodForm.value.poster,
        discount: this.goodForm.value.discount,
        vendorId: this.vendorId,
        amount: this.goodForm.value.amount,
        unitTypeId: this.selectedUnitId,
        categoryIds: [this.selectedCategoryId],
        images: this.splitImageURLs(this.goodForm.value.image!),
    },{headers: this.headers})
    .pipe(
      tap(token => {
        this.localStorageService.setItemToStorage('product', JSON.stringify(token));
        this.dialogRef.close();
        return;
      }),
      catchError(err => {
        console.log(err)
        alert(err.error.message)
        console.log(this.headers)
        return of('');
      })
    ).subscribe()
  }
  
  selectUnit(){
    this.selectedUnitId = this.units.find(unit => unit.name == this.goodForm.value.unit)!.id;
  }

  selectCategory(){
    this.selectedCategoryId = this.categories.find(category => category.name == this.goodForm.value.category)!.id;
  }

  closeWindow() {
    this.dialogRef.close();
  }

  splitImageURLs(str:string){
    return str.split(',')
  }
}
