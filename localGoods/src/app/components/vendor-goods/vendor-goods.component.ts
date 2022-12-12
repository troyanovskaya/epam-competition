import { Component, OnInit } from '@angular/core';
import { PublishedGoodsService } from 'src/app/services/published-goods.service';

@Component({
  selector: 'app-vendor-goods',
  templateUrl: './vendor-goods.component.html',
  styleUrls: ['./vendor-goods.component.css']
})
export class VendorGoodsComponent implements OnInit {

  constructor(public publishedGoodsService: PublishedGoodsService) { }

  ngOnInit(): void {
  }

}
