import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { GoodsService } from 'src/app/services/goods.service';
import { LocationService } from 'src/app/services/location.service';

@Component({
  selector: 'app-vendors-search',
  templateUrl: './vendors-search.component.html',
  styleUrls: ['./vendors-search.component.css']
})
export class VendorsSearchComponent{
  country = new FormControl('');
  city = new FormControl('');
  vendors: string[] = ['Vendor1', 'Vendor2', 'Vendor3', 'Vendor4', 'Vendor5',
  'Vendor6', 'Vendor7', 'Vendor8', 'Vendor9', 'Vendor10', 'Vendor11'];


  constructor(public countriesService: LocationService,
    public goods: GoodsService) {

  }
  getCountry(){
    this.countriesService.choosenCountry = this.countriesService.countries.find(el => el.name===this.country.value)?? {id:'0', name:'Choose country first!', cities:[{id:'0', name:'Choose country first!', countryId:'0'}]};
  }
  getCity(){
    this.countriesService.choosenCity = this.countriesService.choosenCountry.cities.filter( el => el.name===this.city.value)[0];
    this.goods.findGoods(this.countriesService.choosenCity.id);
  }



}
