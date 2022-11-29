import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class BasketService {
  basket = [{id: 1, name: "Carrot", vendor: "Vendor1", src: "assets/carrot.jpg", price: 120, delivery: "take away", amount:1},
  {id: 2, name: "Carrot", vendor: "Vendor3", src: "assets/carrot.jpg", price: 110, delivery: "take away", amount:1},
  {id: 3, name: "Carrot", vendor: "Vendor2", src: "assets/carrot.jpg", price: 100, delivery: "take away", amount:1},
  {id: 4, name: "Carrot", vendor: "Vendor1", src: "assets/carrot.jpg", price: 90, delivery: "take away", amount:1},
  ].sort((el1, el2) => el1.vendor.localeCompare(el2.vendor));

  total:number = this.basket.reduce((pastVal, currentEl) => pastVal+currentEl.price*currentEl.amount, 0);
  onTotalChange(){
    this.total = this.basket.reduce((pastVal, currentEl) => pastVal+currentEl.price*currentEl.amount, 0);
  }
  constructor() { }
}
