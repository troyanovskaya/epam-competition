import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { catchError, Observable, of, tap } from 'rxjs';
import { LocalStorageService } from '../../app/local-storage.service';
import { City, Country } from '../components/country.model';
import { Category } from '../schema/category.model';
import { Good } from '../schema/good.model';
import { Vendor } from '../schema/vendor.model';


@Injectable({
  providedIn: 'root'
})
export class HttpRequestService {
  URL:string = 'https://localgoodsapi.azurewebsites.net/api';

  constructor(private http: HttpClient,
    private localStorageService: LocalStorageService) { }

  getCategories():Observable<Category[]>{
    return this.http.get<Category[]>(`${this.URL}/Categories`)
  }

  post(url: string, value: Object) {
    return this.http.post(`${this.URL}${url}`, value);
  }

  get(url: string) {
    return this.http.get(`${this.URL}${url}`);
  }

  getCountries(): Observable<Country[]> {
    return this.http.get<Country[]>(`${this.URL}/Countries`);
  }

  checkUser(url: string, value: Object, dialogRef: any) {
    this.post(url, value).pipe(
      tap(token => {
        this.localStorageService.setItemToStorage('user', JSON.stringify(token));
        dialogRef.close();
        return;
      }),
      catchError(err => {
        alert(err.error.message)
        return of('');
      })
    ).subscribe()
  }

  getVendors(): Observable<Vendor[]> {
    return this.http.get<Vendor[]>(`${this.URL}/Vendors`);
  }

  getProducts(vendorId: string): Observable<Good[]>{
    return this.http.get<Good[]>(`${this.URL}/Vendors/${vendorId}/products`);
  }
}
