import { Injectable } from '@angular/core';
import { Category } from '../schema/category.model'
import { Good } from '../schema/good.model';
import { BasketItem } from '../schema/basketItem.model';

@Injectable({
  providedIn: 'root'
})
export class BasketService {
  basket:BasketItem[] = [];

  showVendor:string = 'all';
  total:number = this.basket.reduce((pastVal, currentEl) => pastVal+currentEl.good.price*currentEl.quantity, 0);
  orderPrice:number = 0;
  onTotalChange(){
    this.total = this.basket.reduce((pastVal, currentEl) => pastVal+currentEl.good.price*currentEl.quantity, 0);
  }

  vendors:{id:string, companyName:string, deliveryMethods:string[],
    paymentMethods:string[] }[] = [{id:'1', companyName:'Vendor1', deliveryMethods:['Take away', 'Delivery'],
    paymentMethods:['Card', 'Cash']}, {id:'2', companyName:'Vendor2', deliveryMethods:['Take away', 'Delivery'],
    paymentMethods:['Card', 'Cash']}, {id:'3', companyName:'Vendor3', deliveryMethods:['Take away', 'Delivery'],
    paymentMethods:['Card', 'Cash']}]

  orderArr:{id:number, name:string, vendor:string, src:string, price:number, delivery:string, amount:number}[] = [];
  orderVendor: {id:number, companyName:string, deliveryMethods:string[],
    paymentMethods:string[] } = {id:1, companyName:'Vendor1', deliveryMethods:['Take away', 'Delivery'],
    paymentMethods:['Card', 'Cash']};
  getVendor(id:string):{id:string, companyName:string, deliveryMethods:string[],
    paymentMethods:string[] }{
    return this.vendors.filter( el => el.id === id)[0] ??
    {id:'none', companyName:'none', deliveryMethods:[], paymentMethods:[]};
  }
  vendorIdByName(name:string):string{
    let cN = this.vendors.find( el => el.companyName === name);
    if(cN){
      return cN.id;
    }
    return 'none';
  }
  isVendorInBasket(id:string):boolean{
    return !this.basket.reduce((past, curr)=>{
      return past && curr.good.vendorId !== id;
    }, true)

  }
  constructor() { }
}
