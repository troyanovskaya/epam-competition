import { Injectable, OnInit } from '@angular/core';
import { Good } from '../schema/good.model';
import { HttpRequestService } from './http-request.service';
import { UserService } from './user.service';
import jwt_decode from 'jwt-decode';

@Injectable({
  providedIn: 'root'
})
export class PublishedGoodsService implements OnInit {
  vendorGoods:Good[] = [];
  vendorId:string = '';
  getDecodedAccessToken(token: string): any {
    try {
      return jwt_decode(token);
    } catch(Error) {
      return null;
    }
  }
  GetVendorId(userId:string){
    this.httpRequestService.getVendors()
    .subscribe( data => data.map( el => {
      console.log(el.userId);
      if(el.userId===userId){
        this.vendorId = el.id;
        console.log('in');

      }}));
    console.log(this.vendorId);
  }
  GetVendorProducts(){
    this.httpRequestService.getVendorProducts(this.vendorId).subscribe(
      data => {this.vendorGoods = data;
      console.log(data)})
  }
  constructor(private httpRequestService: HttpRequestService,
    private userService: UserService) {
      let user = localStorage.getItem('user');
      if(user){
        let user1:{token:string, validTo:string} = JSON.parse(localStorage.getItem('user')??JSON.stringify({token:'none', validTo:'none'}));
        if(this.getDecodedAccessToken(user1.token)){
          let userId = this.getDecodedAccessToken(user1.token).sub;
          this.GetVendorId(userId);
          this.GetVendorProducts();
        };
      }
     }
  ngOnInit(): void {

  }
}
