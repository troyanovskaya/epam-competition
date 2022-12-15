import { Injectable } from '@angular/core';
import { PublishedOrderItem } from '../schema/publishedOrder.model';
import { HttpRequestService } from './http-request.service';

@Injectable({
  providedIn: 'root'
})
export class OrderInProcessService {
  ordersInProcess: PublishedOrderItem[] = [];

  constructor(private httpRequestService: HttpRequestService) {
    this.httpRequestService.getOpenedOrders().subscribe(
      data => this.ordersInProcess = data);
  }
}
