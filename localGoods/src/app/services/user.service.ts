import { Injectable } from '@angular/core';
import { UserRole } from '../schema/userRole.model';
import jwt_decode from 'jwt-decode';
import { Observable } from 'rxjs';
import { HttpRequestService } from './http-request.service';
import { FullUser } from '../schema/fullUser.model';
import { HttpClient } from '@angular/common/http';
import { Good } from '../schema/good.model';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  URL:string = 'https://localgoodsapi.azurewebsites.net/api';
  user:FullUser = {  id:'',  email:'', firstName:'', lastName: '',
  addressInformation:'', cityId: ''};
  userRole: UserRole = 'None';
  isAutorized:boolean = false;
  userId:string = '';
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

  constructor(private http: HttpClient) {
    let user = localStorage.getItem('user');
    if(user){
      let user1:{token:string, validTo:string} = JSON.parse(localStorage.getItem('user')??JSON.stringify({token:'none', validTo:'none'}));
      this.isAutorized = true;
      if(this.getDecodedAccessToken(user1.token)){
        //this.userRole = this.getDecodedAccessToken(user1.token)['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'];
        let userId = this.getDecodedAccessToken(user1.token).sub;
        this.userId = userId;

        this.getRolesByUserId(userId).subscribe(r => {
          if (r){
            if (r.includes('Vendor')){
              this.userRole = 'VENDOR';
            }
            else{
              this.userRole = 'Buyer';
            }
          }
        })
        this.getUser(userId).subscribe(
          data => {this.user = data})
      };
    }
  }

  getRolesByUserId(id: string){
    return this.http.get<string[]>(`${this.URL}/users/${id}/roles`);
  }
}

