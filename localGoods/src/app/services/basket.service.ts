import { Injectable } from '@angular/core';
import { Category } from '../schema/category.model'
import { Good } from '../schema/good.model';
import { BasketItem } from '../schema/basketItem.model';
import { HttpRequest } from '@angular/common/http';
import { HttpRequestService } from './http-request.service';
import { Vendor } from '../schema/vendor.model';

@Injectable({
  providedIn: 'root'
})
export class BasketService {
  basket:BasketItem[] = [];
  vendorsInBasket:Vendor[] = [];

  showVendor:string = 'all';
  total:number = this.basket.reduce((pastVal, currentEl) => pastVal+currentEl.good.price*currentEl.quantity, 0);
  orderPrice:number = 0;
  onTotalChange(){
    this.total = this.basket.reduce((pastVal, currentEl) => pastVal+currentEl.good.price*currentEl.quantity, 0);
  }

  vendors:Vendor[]=[];

  // orderVendor: Vendor = {id:'1', name:'', deliveryMethods:[],
  //   paymentMethods:['Card', 'Cash']};
  getVendorName(id:string):string{
    let vendor = this.vendors.filter( el => el.id === id)[0];
    return vendor.name ?? 'None';
  }
  vendorIdByName(name:string):string{
    let vendor = this.vendors.find( el => el.name === name);
    if(vendor){
      return vendor.id;
    }
    return 'none';
  }
  isVendorInBasket(id:string):boolean{
    return !this.basket.reduce((past, curr)=>{
      return past && curr.good.vendorId !== id;
    }, true)

  }
  constructor(private httpRequestService: HttpRequestService) {
    this.httpRequestService.getVendors().subscribe( res => this.vendors = res);
   }
}
