import { Component, OnInit } from '@angular/core';
import { GoodsService } from 'src/app/services/goods.service';

@Component({
  selector: 'app-main-page',
  templateUrl: './main-page.component.html',
  styleUrls: ['./main-page.component.css']
})
export class MainPageComponent implements OnInit {

  constructor(public goodService:GoodsService) { }

  ngOnInit(): void {
  }

}
