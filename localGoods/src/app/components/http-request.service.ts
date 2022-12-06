import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { City, Country } from './country.model';


@Injectable({
  providedIn: 'root'
})
export class HttpRequestService {

  constructor(private http: HttpClient) { }

  post(url: string, value: Object) {
    return this.http.post(`https://localgoodsapi.azurewebsites.net/api${url}`, value);
  }

  get(url: string) {
    return this.http.get(`https://localgoodsapi.azurewebsites.net/api${url}`);
  }

  getCountries(): Observable<Country[]> {
    return this.get('/Countries') as Observable<Country[]>;
  }
}
