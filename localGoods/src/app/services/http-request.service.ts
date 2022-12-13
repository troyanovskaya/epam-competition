import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { catchError, Observable, of, tap } from 'rxjs';
import { LocalStorageService } from '../../app/local-storage.service';
import { City, Country } from '../components/country.model';
import { Category } from '../schema/category.model';
import { UserService } from './user.service';
import { environment } from 'src/environments/environment';


@Injectable({
  providedIn: 'root'
})
export class HttpRequestService {
  URL:string = 'https://localgoodsapi.azurewebsites.net/api';

  constructor(private http: HttpClient,
    private localStorageService: LocalStorageService,
    private userService:UserService) { }

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

  confirmEmail(email: any, token: any){
    var parameters = {email: '', token: ''};

    if (email) parameters['email'] = email;
    if (token) parameters['token'] = token;

    return this.http.get(`${environment.apiUrl}/auth/confirmEmail`, {
      params: parameters
    });
  }

  resetPassword(model: any){
    return this.http.post(`${environment.apiUrl}/auth/resetPassword`, model);
  }

  checkUser(url: string, value: Object, dialogRef: any) {
    this.post(url, value).pipe(
      tap(token => {
        this.localStorageService.setItemToStorage('user', JSON.stringify(token));
        this.userService.isAutorized = true;
        dialogRef.close();
        return;
      }),
      catchError(err => {
        alert(err.error.message)
        return of('');
      })
    ).subscribe()
  }
}
