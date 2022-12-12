import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Good } from 'src/app/schema/good.model';
import { BasketService } from 'src/app/services/basket.service';

@Component({
  selector: 'app-product-page',
  templateUrl: './product-page.component.html',
  styleUrls: ['./product-page.component.css']
})
export class ProductPageComponent implements OnInit {
  good:Good = {  id: '1', name: 'carrot', description: 'Sweet fresh carrot that can benefit your health.Sweet fresh carrot that can benefit your health.Sweet fresh carrot that can benefit your health. Sweet fresh carrot that can benefit your health',
  price: 3, poster: 'assets/carrot.jpg', discount: 0, vendorId: '3',   amount: 66,  unitType: {
  id: '0', name: 'kg'}, categories: [], images: ['assets/carrot.jpg']}
  id:number = 0;
  vendor = {id:'1', companyName:'Vendor1', deliveryMethods:['Take away', 'Delivery'],
  paymentMethods:['Card', 'Cash']}
  constructor(private route: ActivatedRoute, private basketService:BasketService) {
    this.route.params.subscribe( params => this.id = params['id'])
  }

  ngOnInit(): void {
    console.log(this.basketService.basket);
  }
  addToBasket(){
    this.basketService.basket
    .filter( el => el.good.id === this.good.id) == undefined ?
    this.basketService.basket.push({good:this.good, quantity:1}) :
    this.basketService.basket.filter( el => el.good.id === this.good.id)[0].quantity++;
    this.basketService.onTotalChange();
  }

}
