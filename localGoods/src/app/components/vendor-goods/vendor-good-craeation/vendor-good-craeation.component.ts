import { Component, OnInit } from '@angular/core';
import { FormArray, FormControl, FormGroup, Validators } from '@angular/forms';
import { Unit } from '../../../schema/unit.model'
import { HttpRequestService } from 'src/app/services/http-request.service';
import { MatDialogRef } from '@angular/material/dialog';
import { Category } from 'src/app/schema/category.model';
import { catchError, of, tap } from 'rxjs';
import { LocalStorageService } from 'src/app/local-storage.service';
import { User } from 'src/app/schema/user.model';
import { Vendor } from 'src/app/schema/vendor.model';

@Component({
  selector: 'app-vendor-good-craeation',
  templateUrl: './vendor-good-craeation.component.html',
  styleUrls: ['./vendor-good-craeation.component.css']
})
export class VendorGoodCraeationComponent{

  units: Unit[] = [];
  selectedUnitId!:string;
  categories: Category[]=[];
  selectedCategoryId!:string;
  vendor:Vendor = JSON.parse(localStorage.getItem('ve')!)

  constructor(
    private http: HttpRequestService, 
    private dialogRef: MatDialogRef<VendorGoodCraeationComponent>,
    private localStorageService: LocalStorageService,) { }

  ngOnInit() {
    this.http.getUnitTypes().subscribe((unitList: Array<Unit>) => {
        this.units=unitList;
        this.selectedUnitId = this.units[0].id;
        console.log(this.units);
    });
    this.http.getCategories().subscribe((categoryList: Array<Category>) => {
      this.categories=categoryList;
      this.selectedCategoryId = this.categories[0].id;
      console.log(this.units);
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
    this.splitImageURLs(this.goodForm.value.image!);
    this.http.post('/Products',{
        name: this.goodForm.value.name,
        description: this.goodForm.value.description,
        price: this.goodForm.value.price,
        discount: this.goodForm.value.discount,
        vendorId: this.vendor.id,
        unitTypeId: this.selectedUnitId,
        amount: this.goodForm.value.amount,
        poster: this.goodForm.value.poster,
        images: this.splitImageURLs(this.goodForm.value.image!),
        categoryId: [this.selectedCategoryId]
    }).pipe(
      tap(token => {
        this.localStorageService.setItemToStorage('product', JSON.stringify(token));
        this.dialogRef.close();
        return;
      }),
      catchError(err => {
        console.log(err)
        alert(err.error.message)
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

