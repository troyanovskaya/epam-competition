import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { catchError, Observable, of, tap } from 'rxjs';
import { City, Country } from './country.model';
import { LocalStorageService } from '../local-storage.service'


@Injectable({
  providedIn: 'root'
})
export class HttpRequestService {

  constructor(private http: HttpClient,
    private localStorageService: LocalStorageService) { }

  post(url: string, value: Object) {
    return this.http.post(`https://localgoodsapi.azurewebsites.net/api${url}`, value);
  }

  get(url: string) {
    return this.http.get(`https://localgoodsapi.azurewebsites.net/api${url}`);
  }

  getCountries(): Observable<Country[]> {
    return this.get('/Countries') as Observable<Country[]>;
  }

  checkUser(url: string, value: Object, dialogRef: any) {
    this.post(url, value).pipe(
      tap(token => {
        this.localStorageService.setItemToStorage('user', token.toString());
        dialogRef.close();
        return;
      }),
      catchError(err => {
        alert(err.error.message)
        return of('');
      })
    )
      .subscribe()
  }
}
