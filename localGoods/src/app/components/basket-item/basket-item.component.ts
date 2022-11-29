
import { Component, Input, OnInit } from '@angular/core';
import { BasketService } from 'src/app/services/basket.service';

@Component({
  selector: 'app-basket-item',
  templateUrl: './basket-item.component.html',
  styleUrls: ['./basket-item.component.css']
})
export class BasketItemComponent implements OnInit {
  @Input() item:any;
  number = 1;
  deleteItem(){
    this.basketService.basket = this.basketService.basket.filter((el) => el.id!==this.item.id);
    this.basketService.onTotalChange();
  }
  changeTotal(){
    let basketItem = this.basketService.basket.find(el => el.id === this.item.id);
    if(basketItem){
      basketItem.amount = this.number;
      this.basketService.onTotalChange();
    } else{
      this.deleteItem();
    }
  }

  constructor(public basketService: BasketService) { }

  ngOnInit(): void {
  }

}
