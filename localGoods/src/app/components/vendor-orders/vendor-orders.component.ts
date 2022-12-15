import { Component, OnInit } from '@angular/core';
import { PublishedOrderService } from 'src/app/services/published-order.service';

@Component({
  selector: 'app-vendor-orders',
  templateUrl: './vendor-orders.component.html',
  styleUrls: ['./vendor-orders.component.css']
})
export class VendorOrdersComponent implements OnInit {

  constructor(public publishedOrderService: PublishedOrderService) {}

  ngOnInit(): void {
  }

}
