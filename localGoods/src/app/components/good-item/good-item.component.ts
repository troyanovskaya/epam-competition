import { Component, Input, OnInit } from '@angular/core';
import { Good } from 'src/app/schema/good.model';
import { BasketService } from 'src/app/services/basket.service';

@Component({
  selector: 'app-good-item',
  templateUrl: './good-item.component.html',
  styleUrls: ['./good-item.component.css']
})
export class GoodItemComponent implements OnInit {
  @Input() item:Good = {  id: '0', name: '', description: '',
    price: 0, poster: '', discount: 0, vendorId: '0', amount: 0,  unitType: {
    id: '0', name: ''}, categories: [], images: []};

  constructor(private basketService: BasketService) { }
  addToBasket(){
    let basketItem  = this.basketService.basket.find( el => el.good.id === this.item.id);
    if(basketItem){
      basketItem.quantity = basketItem.quantity+1;
      this.basketService.basket = this.basketService.basket.filter( el => el.good.id !== this.item.id);
      this.basketService.basket.push(basketItem);
    } else{
      this.basketService.basket.push({good:this.item, quantity:1});
    }
    this.basketService.onTotalChange();
  }

  ngOnInit(): void {
  }

}
