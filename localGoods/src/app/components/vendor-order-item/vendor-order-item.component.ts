import { Component, Input, OnInit } from '@angular/core';
import { PublishedOrderItem } from 'src/app/schema/publishedOrder.model';

@Component({
  selector: 'app-vendor-order-item',
  templateUrl: './vendor-order-item.component.html',
  styleUrls: ['./vendor-order-item.component.css']
})
export class VendorOrderItemComponent implements OnInit {

@Input() order:PublishedOrderItem = {good:{  id: '0', name: '', description: '',
price: 0, poster: '', discount: 0, vendorId: '0',   amount: 0,  unitType: {
id: '0', name: ''}, categories: [], images: []}, quantity:2, status: '',
recipient: {name: '', surname: '', phone:'', address:''}};
  constructor() { }

  ngOnInit(): void {
  }

}
