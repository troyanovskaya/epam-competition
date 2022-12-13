import { Component, DoCheck, OnInit } from '@angular/core';
import { BasketService } from 'src/app/services/basket.service';

@Component({
  selector: 'app-basket-panel',
  templateUrl: './basket-panel.component.html',
  styleUrls: ['./basket-panel.component.css']
})
export class BasketPanelComponent implements OnInit, DoCheck {
  activeVendor:string = 'all';
  showVendorGoods(id:string){
    this.basketService.showVendor=id;
    this.activeVendor = this.basketService.getVendorName(id);
  }

  constructor(public basketService:BasketService) { }

  ngOnInit(): void {
    this.basketService.showVendor = 'all';
  }

  ngDoCheck(){
    if(this.activeVendor!=='' && this.activeVendor!=='all'){
     let id  = this.basketService.vendorIdByName(this.activeVendor);
     if(!this.basketService.isVendorInBasket(id)){
      this.activeVendor = 'all';
     }
    }
  }

}
