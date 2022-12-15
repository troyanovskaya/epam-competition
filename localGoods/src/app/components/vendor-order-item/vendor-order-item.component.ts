import { Component, Input, OnInit } from '@angular/core';
import { DeliveryMethod } from 'src/app/schema/deliveryMethod.model';
import { FullUser } from 'src/app/schema/fullUser.model';
import { OrderStatus } from 'src/app/schema/orderStatus.model';
import { PaymentMethod } from 'src/app/schema/paymentMethod.model';
import { PublishedOrderItem } from 'src/app/schema/publishedOrder.model';
import { HttpRequestService } from 'src/app/services/http-request.service';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-vendor-order-item',
  templateUrl: './vendor-order-item.component.html',
  styleUrls: ['./vendor-order-item.component.css']
})
export class VendorOrderItemComponent implements OnInit {
  NewOrderStatusId: string = '5cd43639-e879-4331-9e3b-019537bb729b';
  PendingOrderStatusId: string = '6f0a355f-c0b1-46a3-a93a-94fad9aa1ed3';
  PaidOrderStatusId: string = 'de780f77-888f-44e8-be34-d796f5342b55';
  CompletedOrderStatusId: string = '17cf0057-aa23-4cdf-96a4-6573c7ae96e6';
  CanceledOrderStatusId: string = '712572b2-5991-48eb-a882-5b842dcfc5bf';

  @Input() order: PublishedOrderItem = { id: '', createdAt: new Date(),
    deliveryInformation: '', deliveryMethodId: '', orderDetails: [],
    orderStatusId: '', paymentMethodId: '', userId: ''
  };
  @Input() isForVendor: boolean = false;
  deliveryMethod: DeliveryMethod = {id: '', name: ''};
  paymentMethod: PaymentMethod = {id: '', name: ''};
  orderStatus: OrderStatus = {id: '', name: ''};
  user: FullUser = {  id:'',  email:'', firstName:'', lastName: '',
    addressInformation:'', cityId: ''};

  constructor(private httpRequestService: HttpRequestService, private userService: UserService) {
  }

  ngOnInit(): void {
    this.httpRequestService.getUser(this.order.userId)
      .subscribe(user => this.user = user);
    this.httpRequestService.getPaymentMethod(this.order.paymentMethodId)
      .subscribe(user => this.paymentMethod = user);
    this.httpRequestService.getDeliveryMethod(this.order.deliveryMethodId)
      .subscribe(user => this.deliveryMethod = user);
    this.httpRequestService.getOrderStatus(this.order.orderStatusId)
      .subscribe(user => this.deliveryMethod = user);
  }

  setOrderStatusToTheNextStage(): void {
    this.httpRequestService.changeOrderStatus(this.order.id)
      .subscribe({error: e => console.log(e)});
  }

  cancelOrder(): void {
    this.httpRequestService.cancelOrder(this.order.id)
      .subscribe({error: e => console.log(e)});
  }

  isOrderStatusChangeable(): boolean {
    return this.isForVendor && this.order.orderStatusId != this.CompletedOrderStatusId
      && this.order.orderStatusId != this.CanceledOrderStatusId;
  }

  isOrderCancelable(): boolean {
    return this.isForVendor && this.order.orderStatusId != this.CompletedOrderStatusId
      && this.order.orderStatusId != this.CanceledOrderStatusId
      && this.order.orderStatusId != this.PaidOrderStatusId;
  }
}
