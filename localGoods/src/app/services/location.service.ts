import { Injectable } from '@angular/core';
import { City } from '../schema/city.model';
import { Country } from '../schema/country.model';

@Injectable({
  providedIn: 'root'
})
export class LocationService {
  countries:Country[] = [];
  choosenCountry:Country = {id:'0', name:'Choose country first!', cities:[{id:'0', name:'Choose country first!', countryId:'0'}]};
  choosenCity:City = {id:'0', name: 'None', countryId:'0'};

  constructor() {
    fetch('https://localgoodsapi.azurewebsites.net/api/Countries')
    .then((response) => response.json())
    .then((data) => {this.countries = data});
  }
}
