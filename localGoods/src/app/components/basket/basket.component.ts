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

  ngOnInit(): void {
  }

}
