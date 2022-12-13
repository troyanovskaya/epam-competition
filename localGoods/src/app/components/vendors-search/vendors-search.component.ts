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
  disabled:boolean = true;
  vendors: string[] = ['Vendor1', 'Vendor2', 'Vendor3', 'Vendor4', 'Vendor5',
  'Vendor6', 'Vendor7', 'Vendor8', 'Vendor9', 'Vendor10', 'Vendor11'];


  constructor(public countriesService: LocationService,
    public goods: GoodsService) {
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



}
