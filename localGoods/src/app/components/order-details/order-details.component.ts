import { Component, Input, OnInit } from '@angular/core';
import { Good } from 'src/app/schema/good.model';
import { OrderDetails } from 'src/app/schema/orderDetails.model';
import { HttpRequestService } from 'src/app/services/http-request.service';

@Component({
  selector: 'app-order-details',
  templateUrl: './order-details.component.html',
  styleUrls: ['./order-details.component.css']
})
export class OrderDetailsComponent implements OnInit {
  @Input() orderDetails: OrderDetails = {
    id: '', amount: 0, discount: 0, orderId: '', price: 0, productId: '', unitTypeId: ''
  };
  product: Good = { id: '', amount: 0, categories: [], description: '', discount: 0, images: [],
    name: '', poster: '', price: 0, unitType: {id: '', name: ''}, vendorId: ''
  };

  constructor(private httpRequestService: HttpRequestService) {
  }

  ngOnInit(): void {
    this.httpRequestService.getProduct(this.orderDetails.productId)
      .subscribe(product => this.product = product);
  }
}
