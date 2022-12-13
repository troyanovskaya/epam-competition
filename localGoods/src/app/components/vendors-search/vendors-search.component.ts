import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { Vendor } from 'src/app/schema/vendor.model';
import { GoodsService } from 'src/app/services/goods.service';
import { HttpRequestService } from 'src/app/services/http-request.service';
import { LocationService } from 'src/app/services/location.service';
import { ShareDataService } from 'src/app/services/share-data.service';
import { VendorItemPageComponent } from '../vendor-item-page/vendor-item-page.component';

@Component({
  selector: 'app-vendors-search',
  templateUrl: './vendors-search.component.html',
  styleUrls: ['./vendors-search.component.css']
})
export class VendorsSearchComponent{
  country = new FormControl('');
  city = new FormControl('');
  vendors: Vendor[] = [];
  vendorId!: string;

  constructor(public countriesService: LocationService,
    public goods: GoodsService,
    private shareDataService: ShareDataService,
    private http: HttpRequestService) {
  }

  ngOnInit(){
    this.http.getVendors().subscribe((vendorsList: Array<Vendor>) => {
      vendorsList.forEach((vendor) => {
        this.vendors.push(vendor);
      })
    });
  }

  getCountry(){
    this.countriesService.choosenCountry = this.countriesService.countries.find(el => el.name===this.country.value)?? {id:'', name:'', cities:[{id:'0', name:'Choose country first!', countryId:'0'}]};
    if(this.countriesService.choosenCountry.id){
      this.getCity();
    }

  }

  getCity(){
    if(this.countriesService.choosenCountry.cities.filter( el => el.name===this.city.value)[0]){
      this.countriesService.choosenCity = this.countriesService.choosenCountry.cities.filter( el => el.name===this.city.value)[0];
    }
    if(this.city.value!=='None'&&this.city.value!==''){
      this.findGoods();
    }

  }
  findGoods(){
    console.log(this.countriesService.choosenCity);
    if(this.countriesService.choosenCity.id){
      return this.goods.findGoods(this.countriesService.choosenCity.id, []);
    }
    return this.goods.findGoods('none', []);
  }

  selectVendor(vendor:Vendor){
    this.shareDataService.setVendor(vendor);
  }

}
