import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { catchError, Observable, of, tap } from 'rxjs';
import { LocalStorageService } from '../../app/local-storage.service';
import { City, Country } from '../components/country.model';
import { Category } from '../schema/category.model';
import { environment } from 'src/environments/environment';
import { DeliveryMethod } from '../schema/deliveryMethod.model';
import { FullUser } from '../schema/fullUser.model';
import { Good } from '../schema/good.model';
import { OrderItem } from '../schema/orderItem.model';
import { PaymentMethod } from '../schema/paymentMethod.model';
import { Vendor } from '../schema/vendor.model';
import { UserService } from './user.service';
import jwt_decode from 'jwt-decode';


@Injectable({
  providedIn: 'root'
})
export class HttpRequestService {
  URL:string = 'https://localgoodsapi.azurewebsites.net/api';

  postVendor(vendor:Vendor){
    let user1:{token:string} = JSON.parse(localStorage.getItem('user')??JSON.stringify({token:'none'}));
    let headers = new HttpHeaders();
    headers = headers.set('Authorization', 'Bearer ' + user1.token);
    return this.http.post(`${this.URL}/Vendors`, vendor, {headers:headers});
  }

  postOrder(order: OrderItem) {
    let user1:{token:string} = JSON.parse(localStorage.getItem('user')??JSON.stringify({token:'none'}));
    let headers = new HttpHeaders();
    headers = headers.set('Authorization', 'Bearer ' + user1.token);
    console.log(headers);
    return this.http.post<OrderItem>(`${this.URL}/Orders`, order, {headers:headers}).subscribe(
      (data) => console.log(data),
      (err) => console.log(err)
    );
  }

  getVendors(): Observable<Vendor[]>{
    return this.http.get<Vendor[]>(`${this.URL}/Vendors`)
  }

  getDelMeth(): Observable<DeliveryMethod[]>{
    return this.http.get<DeliveryMethod[]>(`${this.URL}/DeliveryMethods`)
  }
  getPayMeth(): Observable<PaymentMethod[]>{
    return this.http.get<PaymentMethod[]>(`${this.URL}/PaymentMethods`)
  }

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
  getDecodedAccessToken(token: string): any {
    try {
      return jwt_decode(token);
    } catch(Error) {
      return null;
    }
  }
  getUser(id:string): Observable<FullUser> {
    return this.http.get<FullUser>(`${this.URL}/Users/${id}`);
  }
  getProducts(cityId:string, categoryIds:string[]): Observable<Good[]>{
    if(cityId==='none'&&categoryIds.length===0){
      return this.http.get<Good[]>(`${this.URL}/Products`);
    } else if(cityId!=='none'&& categoryIds.length===0){
      return this.http.get<Good[]>(`${this.URL}/Products?CityId=${cityId}`);
    } else if (cityId!=='none'&& categoryIds.length!==0){
      let url = '';
      for (let i=0; i<categoryIds.length; i++){
        url += `CategoryIds=${categoryIds[i]}`;
        if(categoryIds.length!=i-1){
          url+='&';
        }
      }
      return this.http.get<Good[]>(`${this.URL}/Products?CityId=${cityId}&${url}`);
    }
    let url = '';
      for (let i=0; i<categoryIds.length; i++){
        url += `CategoryIds=${categoryIds[i]}`;
        if(categoryIds.length!=i-1){
          url+='&';
        }
      }
      return this.http.get<Good[]>(`${this.URL}/Products?${url}`);
  }



  getVendor(vendorId:string): Observable<Vendor>{
    return this.http.get<Vendor>(`${this.URL}/Vendors/${vendorId}`);

  }
  getProduct(productId:string): Observable<Good>{
    return this.http.get<Good>(`${this.URL}/Products/${productId}`);
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
        let user = localStorage.getItem('user');
        if(user){
          let user1:{token:string, validTo:string} = JSON.parse(localStorage.getItem('user')??JSON.stringify({token:'none', validTo:'none'}));
          console.log(user1.token);
          if(this.getDecodedAccessToken(user1.token)){
            let userId = this.getDecodedAccessToken(user1.token).sub;
            this.userService.userRole = this.getDecodedAccessToken(user1.token)['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'];
            this.getUser(userId).subscribe(
              data => this.userService.user = data);
          };
        }
        return;
      }),
      catchError(err => {
        alert(err.error.message)
        return of('');
      })
    ).subscribe()
  }

  getVendorProducts(vendorId: string): Observable<Good[]>{
    return this.http.get<Good[]>(`${this.URL}/Vendors/${vendorId}/products`);
  }
}

