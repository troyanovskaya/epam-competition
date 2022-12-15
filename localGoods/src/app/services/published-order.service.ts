import { Injectable } from '@angular/core';
import { PublishedOrderItem } from '../schema/publishedOrder.model';
import { HttpRequestService } from './http-request.service';
import { UserService } from './user.service';

@Injectable({
  providedIn: 'root'
})
export class PublishedOrderService {
  vendorOrders:PublishedOrderItem[] = [];

  GetVendorPublishedOrders(vendorId: string){
    this.httpRequestService.getPublishedOrders(vendorId).subscribe(
      data => {this.vendorOrders = data;
      console.log(data)})
  }

  constructor(private httpRequestService: HttpRequestService, private userService: UserService) {
    let userId = userService.userId;
    console.log('userId: ' + userId);
    httpRequestService.getVendorByUserId(userId)
      .subscribe(vendor => {
        let currentVendor = vendor;
        this.GetVendorPublishedOrders(currentVendor.id);
      });
  }
}
