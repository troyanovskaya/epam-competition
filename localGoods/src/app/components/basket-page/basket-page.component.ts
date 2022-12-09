import { Component, OnInit } from '@angular/core';
import { BasketService } from 'src/app/services/basket.service';
import { VisibilityService } from 'src/app/services/visibility.service';

@Component({
  selector: 'app-basket-page',
  templateUrl: './basket-page.component.html',
  styleUrls: ['./basket-page.component.css']
})
export class BasketPageComponent implements OnInit {

  constructor(public basketService:BasketService, public visibility:VisibilityService) { }
  showPayWindow(){
    this.visibility.isOrderFinishVisible = true;

  }

  ngOnInit(): void {
  }

}
