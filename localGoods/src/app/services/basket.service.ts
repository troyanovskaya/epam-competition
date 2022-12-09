import { Injectable } from '@angular/core';
import { Category } from '../schema/category.model'
import { Good } from '../schema/good.model';
import { OrderItem } from '../schema/orderItem.model';

@Injectable({
  providedIn: 'root'
})
export class BasketService {
  basket:OrderItem[] = [{good:{  id: '1', name: 'carrot', description: 'Sweet fresh carrot that can benefit your health',
    price: 3, poster: 'assets/carrot.jpg', discount: 0, vendorId: '3',   amount: 66,  unitType: {
    id: '0', name: 'kg'}, categories: [], images: ['assets/carrot.jpg']}, quantity:1},
    {good:{  id: '2', name: 'carrot', description: 'Sweet fresh carrot that can benefit your health',
    price: 123, poster: 'assets/carrot.jpg', discount: 0, vendorId: '1',   amount: 66,  unitType: {
    id: '0', name: 'kg'}, categories: [], images: ['assets/carrot.jpg']}, quantity:1},
    {good:{  id: '3', name: 'carrot', description: 'Sweet fresh carrot that can benefit your health',
    price: 123, poster: 'assets/carrot.jpg', discount: 0, vendorId: '2',   amount: 66,  unitType: {
    id: '0', name: 'kg'}, categories: [], images: ['assets/carrot.jpg']}, quantity:1},
    {good:{  id: '4', name: 'carrot', description: 'Sweet fresh carrot that can benefit your health',
    price: 123, poster: 'assets/carrot.jpg', discount: 0, vendorId: '1',   amount: 66,  unitType: {
    id: '0', name: 'kg'}, categories: [], images: ['assets/carrot.jpg']}, quantity:1},
    {good:{  id: '5', name: 'carrot', description: 'Sweet fresh carrot that can benefit your health',
    price: 123, poster: 'assets/carrot.jpg', discount: 0, vendorId: '1',   amount: 66,  unitType: {
    id: '0', name: 'kg'}, categories: [], images: ['assets/carrot.jpg']}, quantity:1},
    {good:{  id: '6', name: 'carrot', description: 'Sweet fresh carrot that can benefit your health',
    price: 123, poster: 'assets/carrot.jpg', discount: 0, vendorId: '2',   amount: 66,  unitType: {
    id: '0', name: 'kg'}, categories: [], images: ['assets/carrot.jpg']}, quantity:1},
    {good:{  id: '7', name: 'carrot', description: 'Sweet fresh carrot that can benefit your health',
    price: 123, poster: 'assets/carrot.jpg', discount: 0, vendorId: '1',   amount: 66,  unitType: {
    id: '0', name: 'kg'}, categories: [], images: ['assets/carrot.jpg']}, quantity:1},
    {good:{  id: '8', name: 'carrot', description: 'Sweet fresh carrot that can benefit your health',
    price: 3, poster: 'assets/carrot.jpg', discount: 0, vendorId: '3',   amount: 66,  unitType: {
    id: '0', name: 'kg'}, categories: [], images: ['assets/carrot.jpg']}, quantity:1},].sort((el1, el2) => el1.good.vendorId.localeCompare(el2.good.vendorId));

  showVendor:string = 'all';
  total:number = this.basket.reduce((pastVal, currentEl) => pastVal+currentEl.good.price*currentEl.quantity, 0);
  orderPrice:number = 0;
  onTotalChange(){
    this.total = this.basket.reduce((pastVal, currentEl) => pastVal+currentEl.good.price*currentEl.quantity, 0);
  }

  vendors:{id:string, companyName:string, deliveryMethods:string[],
    paymentMethods:string[] }[] = [{id:'1', companyName:'Vendor1', deliveryMethods:['Take away', 'Delivery'],
    paymentMethods:['Card', 'Cash']}, {id:'2', companyName:'Vendor2', deliveryMethods:['Take away', 'Delivery'],
    paymentMethods:['Card', 'Cash']}, {id:'3', companyName:'Vendor3', deliveryMethods:['Take away', 'Delivery'],
    paymentMethods:['Card', 'Cash']}]

  orderArr:{id:number, name:string, vendor:string, src:string, price:number, delivery:string, amount:number}[] = [];
  orderVendor: {id:number, companyName:string, deliveryMethods:string[],
    paymentMethods:string[] } = {id:1, companyName:'Vendor1', deliveryMethods:['Take away', 'Delivery'],
    paymentMethods:['Card', 'Cash']};
  getVendor(id:string):{id:string, companyName:string, deliveryMethods:string[],
    paymentMethods:string[] }{
    return this.vendors.filter( el => el.id === id)[0];
  }
  constructor() { }
}
