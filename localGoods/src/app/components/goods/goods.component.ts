import { Component, OnInit } from '@angular/core';
import { GoodsService } from 'src/app/services/goods.service';

@Component({
  selector: 'app-goods',
  templateUrl: './goods.component.html',
  styleUrls: ['./goods.component.css']
})
export class GoodsComponent implements OnInit {

  constructor(public goodService:GoodsService) { }

  ngOnInit(): void {
  }

}
