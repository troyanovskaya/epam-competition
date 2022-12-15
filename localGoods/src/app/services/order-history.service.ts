import { Injectable } from '@angular/core';
import { PublishedOrderItem } from '../schema/publishedOrder.model';
import { HttpRequestService } from './http-request.service';

@Injectable({
  providedIn: 'root'
})
export class OrderHistoryService {
  pastOrders: PublishedOrderItem[] = [];

  constructor(private httpRequestService: HttpRequestService) {
    this.httpRequestService.getPastOrdersOrders().subscribe(
      data => this.pastOrders = data);
  }
}
