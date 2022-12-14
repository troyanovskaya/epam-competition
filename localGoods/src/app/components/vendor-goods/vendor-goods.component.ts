import { Component, OnInit } from '@angular/core';
import { Good } from 'src/app/schema/good.model';
import { PublishedGoodsService } from 'src/app/services/published-goods.service';

@Component({
  selector: 'app-vendor-goods',
  templateUrl: './vendor-goods.component.html',
  styleUrls: ['./vendor-goods.component.css']
})
export class VendorGoodsComponent implements OnInit {
  goods:Good[] = [];

  constructor(public publishedGoodsService: PublishedGoodsService) {

   }

  ngOnInit(): void {
  }

}
