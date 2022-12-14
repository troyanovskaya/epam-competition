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
  GetVendor(userId:string){
    let vendor;
    this.httpRequestService.getVendor(userId)
    .subscribe( data => {this.vendorId = data.id;
      this.GetVendorProducts();});
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
          this.GetVendor(userId);
        };
      }
     }
  ngOnInit(): void {

  }
}
