import { Injectable } from '@angular/core';
import { City } from '../schema/city.model';
import { Country } from '../schema/country.model';
import { HttpRequestService } from './http-request.service';

@Injectable({
  providedIn: 'root'
})
export class LocationService {
  countries:Country[] = [];
  choosenCountry:Country = {id:'0', name:'Choose country first!', cities:[{id:'0', name:'Choose country first!', countryId:'0'}]};
  choosenCity:City = {id:'0', name: 'None', countryId:'0'};

  constructor(private http: HttpRequestService) {
    this.http.getCountries().subscribe( res => this.countries=res);
  }
}
