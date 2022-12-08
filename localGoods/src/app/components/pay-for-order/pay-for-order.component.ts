import { Component, OnInit } from '@angular/core';
import { BasketService } from 'src/app/services/basket.service';
import { VisibilityService } from 'src/app/services/visibility.service';

@Component({
  selector: 'app-pay-for-order',
  templateUrl: './pay-for-order.component.html',
  styleUrls: ['./pay-for-order.component.css']
})
export class PayForOrderComponent implements OnInit {
  sendOrder(){
    this.basketService.basket = this.basketService.basket.filter( el => el.vendor!==this.basketService.orderVendor.companyName)
    this.basketService.onTotalChange();
    this.orderFinished = true;
    this.visibility.isBasketVisible = false;
    this.basketService.orderArr.reduce((past, current)=>past+current.amount*current.price, 0);
  }

  price:number = 0;
  orderFinished:boolean = false;

  constructor(public visibility: VisibilityService, public basketService:BasketService) {

  }

  ngOnInit(): void {
  }

}
