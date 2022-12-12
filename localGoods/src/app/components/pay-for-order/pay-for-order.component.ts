import { Component, DoCheck, OnChanges, OnInit } from '@angular/core';
import { BasketService } from 'src/app/services/basket.service';
import { VisibilityService } from 'src/app/services/visibility.service';

@Component({
  selector: 'app-pay-for-order',
  templateUrl: './pay-for-order.component.html',
  styleUrls: ['./pay-for-order.component.css']
})
export class PayForOrderComponent implements OnInit, DoCheck {
  money:number = 0;
  sendOrder(){
    if (this.basketService.showVendor === 'all'){
      this.basketService.basket = [];
    } else{
      this.basketService.basket = this.basketService.basket.filter( el => el.good.vendorId!==this.basketService.showVendor)
    }
    this.basketService.onTotalChange();
    this.orderFinished = true;
    this.basketService.showVendor = 'all';
  }
  vendorIds:string[] = [];
  vendorNames:Set<string> = new Set();
  vendorNamesStr:string = '';

  countPrice(){
    if (this.basketService.showVendor === 'all'){
      this.money = this.basketService.total;
    } else{
      let arr = this.basketService.basket.filter( el => el.good.vendorId === this.basketService.showVendor)
      this.money = arr.reduce( (past, curr) => past + curr.quantity*curr.good.price, 0 )
    }
  }

  getVendorNames(){
    if (this.basketService.showVendor === 'all'){
      this.vendorIds = this.basketService.basket.map( el => el.good.vendorId);
      this.vendorIds.map( el => this.vendorNames.add(this.basketService.getVendor(el).companyName));
      this.vendorNamesStr = Array.from(this.vendorNames).join(', ');
    } else{
      this. vendorNamesStr = this.basketService.getVendor(this.basketService.showVendor).companyName;
    }

  }
  price:number = 0;
  orderFinished:boolean = false;
  constructor(public visibility: VisibilityService, public basketService:BasketService){}

  ngOnInit(): void {
    this.getVendorNames();
  }
  ngDoCheck(){
    this.getVendorNames();
    this.countPrice()
  }

}
