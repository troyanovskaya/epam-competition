import { Component, DoCheck, OnChanges, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, NgForm, Validators } from '@angular/forms';
import { BasketService } from 'src/app/services/basket.service';
import { UserService } from 'src/app/services/user.service';
import { VisibilityService } from 'src/app/services/visibility.service';
import { ReactiveFormsModule } from '@angular/forms';
import { DeliveryMethod } from 'src/app/schema/deliveryMethod.model';
import { PaymentMethod } from 'src/app/schema/paymentMethod.model';
import { HttpRequestService } from 'src/app/services/http-request.service';
import { OrderItem } from 'src/app/schema/orderItem.model';

@Component({
  selector: 'app-pay-for-order',
  templateUrl: './pay-for-order.component.html',
  styleUrls: ['./pay-for-order.component.css']
})
export class PayForOrderComponent implements OnInit, DoCheck {
  money:number = 0;
  form = new FormGroup({
    del: new FormControl<string>('Delivery'),
    pay: new FormControl<string>('Cash')
  });
  delMeth:DeliveryMethod[] = [];
  payMeth:PaymentMethod[] = [];
  sendOrder(){
    let arr:{amount:number, productId:string}[] = [];
    if (this.basketService.showVendor === 'all'){
      this.basketService.basket.map( el => arr.push({amount:el.quantity, productId:el.good.id}));
      this.basketService.basket = [];
    } else{
      this.basketService.basket.filter( el => el.good.vendorId===this.basketService.showVendor)
      .map( el => arr.push({amount:el.quantity, productId:el.good.id}))
      this.basketService.basket = this.basketService.basket.filter( el => el.good.vendorId!==this.basketService.showVendor);
    }
    this.basketService.onTotalChange();
    this.orderFinished = true;
    this.basketService.showVendor = 'all';
    let pay:PaymentMethod = this.payMeth.find( el => el.name===this.form.controls.pay.value) ?? {id:'0', name:''};
    let del:DeliveryMethod = this.delMeth.find( el => el.name===this.form.controls.del.value) ?? {id:'0', name:''};
    let order:OrderItem = {paymentMethodId: pay.id,
      deliveryMethodId: del.id,
      deliveryInformation: '',
      orderDetails: arr
    }
    console.log(order);
    this.httpRequestService.postOrder(order);
  }
  vendorIds:string[] = [];
  vendorNames:Set<string> = new Set();
  vendorNamesStr:string = '';
  onSubmit() {
    console.log(this.form.controls);
}

  countPrice(){
    if (this.basketService.showVendor === 'all'){
      this.money = this.basketService.total;
    } else{
      let arr = this.basketService.basket.filter( el => el.good.vendorId === this.basketService.showVendor)
      this.money = arr.reduce( (past, curr) => past + curr.quantity*curr.good.price, 0 )
    }
  }
  getVendorNames(){
    if (this.basketService.showVendor === 'all'){
      this.vendorIds = this.basketService.basket.map( el => el.good.vendorId);
      this.vendorIds.map( el => this.vendorNames.add(this.basketService.getVendor(el).companyName));
      this.vendorNamesStr = Array.from(this.vendorNames).join(', ');
    } else{
      this. vendorNamesStr = this.basketService.getVendor(this.basketService.showVendor).companyName;
    }

  }
  price:number = 0;
  orderFinished:boolean = false;
  constructor(public visibility: VisibilityService, public basketService:BasketService,
    public userService:UserService, private httpRequestService: HttpRequestService){
      httpRequestService.getDelMeth().subscribe( res => this.delMeth = res);
      httpRequestService.getPayMeth().subscribe( res => this.payMeth = res);
    }

  ngOnInit(): void {
    this.getVendorNames();
  }
  ngDoCheck(){
    this.getVendorNames();
    this.countPrice()
  }

}
