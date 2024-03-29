import { Component, Input, OnInit } from '@angular/core';
import { Good } from 'src/app/schema/good.model';
import { HttpRequestService } from 'src/app/services/http-request.service';
import { PublishedGoodsService } from 'src/app/services/published-goods.service';

@Component({
  selector: 'app-vendor-good-item',
  templateUrl: './vendor-good-item.component.html',
  styleUrls: ['./vendor-good-item.component.css']
})
export class VendorGoodItemComponent implements OnInit {
  @Input() item: Good = {
    id: '0',
    name: '',
    description: '',
    price: 0,
    poster: '',
    discount: 0,
    vendorId: '0',
    amount: 0,
    unitType: {
      id: '0',
      name: ''
    },
    categories: [],
    images: []
  };

  deleteItem() {
    this.publishedGoodsService.vendorGoods = this.publishedGoodsService.vendorGoods
      .filter(el => el.id !== this.item.id);
    this.httpRequestService.deleteProductById(this.item.id)
    .subscribe(data => console.log, err => console.log(err));

  }

  constructor(private publishedGoodsService: PublishedGoodsService,
    private httpRequestService:HttpRequestService) { }

  ngOnInit(): void {
  }

}
