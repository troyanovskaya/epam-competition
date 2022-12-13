
import { Component, Input, OnInit } from '@angular/core';
import { BasketItem } from 'src/app/schema/basketItem.model';
import { BasketService } from 'src/app/services/basket.service';

@Component({
  selector: 'app-basket-item',
  templateUrl: './basket-item.component.html',
  styleUrls: ['./basket-item.component.css']
})
export class BasketItemComponent implements OnInit{
  @Input() item:BasketItem = {good:{  id: '0', name: '', description: '',
  price: 0, poster: '', discount: 0, vendorId: '0', amount: 0,  unitType: {
    id: '0', name: ''}, categories: [], images: []}, quantity:0};
  number = 1;
  deleteItem(){
    this.basketService.basket = this.basketService.basket.filter((el) => el.good.id!==this.item.good.id);
    this.basketService.onTotalChange();
  }
  changeTotal(){
    let basketItem = this.basketService.basket.find(el => el.good.id === this.item.good.id);
    if(basketItem){
      basketItem. quantity = this.number;
      this.basketService.onTotalChange();
    } else{
      this.deleteItem();
    }
  }

  constructor(public basketService: BasketService) { }
  ngOnInit(){
    let basketItem = this.basketService.basket.find(el => el.good.id === this.item.good.id);
    if(basketItem){
      this.number = basketItem.quantity;
    }
  }


}
