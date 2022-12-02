import { Component, OnInit } from '@angular/core';
import { BasketService } from 'src/app/services/basket.service';
import { VisibilityService } from 'src/app/services/visibility.service';

@Component({
  selector: 'app-basket',
  templateUrl: './basket.component.html',
  styleUrls: ['./basket.component.css']
})
export class BasketComponent implements OnInit {
  constructor(public visibility:VisibilityService, public basketService:BasketService) { }
  openOrder(vendor:string){
    this.basketService.orderArr = this.basketService.basket.filter( el => el.vendor === vendor);
    this.basketService.orderVendor.companyName = this.basketService.orderArr[0].vendor;
    this.basketService.orderPrice = this.basketService.orderArr.reduce((past, current)=>past+current.price*current.amount, 0);
    this.visibility.isOrderFinishVisible = true;
  }
  ngOnInit(): void {
  }

}
