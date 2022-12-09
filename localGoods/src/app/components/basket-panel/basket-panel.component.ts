import { Component, Input, OnInit } from '@angular/core';
import { BasketService } from 'src/app/services/basket.service';

@Component({
  selector: 'app-basket-panel',
  templateUrl: './basket-panel.component.html',
  styleUrls: ['./basket-panel.component.css']
})
export class BasketPanelComponent implements OnInit {
  @Input() activeVendor:string = '';
  showVendorGoods(id:string){
    this.basketService.showVendor=id;
    this.activeVendor = this.basketService.getVendor(id).companyName

  }

  constructor(public basketService:BasketService) { }

  ngOnInit(): void {
  }

}
