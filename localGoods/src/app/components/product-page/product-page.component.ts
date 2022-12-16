import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Good } from 'src/app/schema/good.model';
import { Vendor } from 'src/app/schema/vendor.model';
import { BasketService } from 'src/app/services/basket.service';
import { HttpRequestService } from 'src/app/services/http-request.service';

@Component({
  selector: 'app-product-page',
  templateUrl: './product-page.component.html',
  styleUrls: ['./product-page.component.css']
})
export class ProductPageComponent implements OnInit {
  good:Good = {  id: '0', name: '', description: '',
  price: 0, poster: '', discount: 0, vendorId: '0',   amount: 0,  unitType: {
  id: '0', name: ''}, categories: [], images: []}
  id:string = '';
  vendor:Vendor = {id:'', name:'', viberNumber:'', telegramName:'',
    instagramName:'', userId:'', products: [], paymentMethods: [],
    deliveryMethods: []}
  constructor(private route: ActivatedRoute, private basketService:BasketService, public httprequestService:HttpRequestService) {
    this.route.params.subscribe( params => this.id = params['id']);
  }

  ngOnInit() {
    this.httprequestService.getProduct(this.id).subscribe(
      data => {
        this.good = data;
        this.httprequestService.getVendorById(this.good.vendorId)
    .subscribe( data => this.vendor = data)});
  }
  addToBasket(){
    this.basketService.basket
    .filter( el => el.good.id === this.good.id)[0] == undefined ?
    this.basketService.basket.push({good:this.good, quantity:1}) :
    this.basketService.basket.filter( el => el.good.id === this.good.id)[0].quantity++;
    this.basketService.onTotalChange();
  }
}
