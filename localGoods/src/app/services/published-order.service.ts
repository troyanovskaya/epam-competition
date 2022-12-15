import { Injectable } from '@angular/core';
import { PublishedOrderItem } from '../schema/publishedOrder.model';

@Injectable({
  providedIn: 'root'
})
export class PublishedOrderService {
  orders:PublishedOrderItem[] = [{good:{  id: '1', name: 'carrot', description: 'Sweet fresh carrot that can benefit your health',
  price: 3, poster: 'assets/carrot.jpg', discount: 0, vendorId: '3',   amount: 66,  unitType: {
  id: '0', name: 'kg'}, categories: [], images: ['assets/carrot.jpg']}, quantity:2, status: 'On delivery',
recipient: {name: 'Larsy', surname: 'MacGreen', phone:'0123455378', address:'12 Line'}},
{good:{  id: '1', name: 'carrot', description: 'Sweet fresh carrot that can benefit your health',
  price: 3, poster: 'assets/carrot.jpg', discount: 0, vendorId: '3',   amount: 66,  unitType: {
  id: '0', name: 'kg'}, categories: [], images: ['assets/carrot.jpg']}, quantity:2, status: 'On delivery',
recipient: {name: 'Larsy', surname: 'MacGreen', phone:'0123455378', address:'12 Line'}},
{good:{  id: '1', name: 'carrot', description: 'Sweet fresh carrot that can benefit your health',
  price: 3, poster: 'assets/carrot.jpg', discount: 0, vendorId: '3',   amount: 66,  unitType: {
  id: '0', name: 'kg'}, categories: [], images: ['assets/carrot.jpg']}, quantity:2, status: 'On delivery',
recipient: {name: 'Larsy', surname: 'MacGreen', phone:'0123455378', address:'12 Line'}},
{good:{  id: '1', name: 'carrot', description: 'Sweet fresh carrot that can benefit your health',
  price: 3, poster: 'assets/carrot.jpg', discount: 0, vendorId: '3',   amount: 66,  unitType: {
  id: '0', name: 'kg'}, categories: [], images: ['assets/carrot.jpg']}, quantity:2, status: 'On delivery',
recipient: {name: 'Larsy', surname: 'MacGreen', phone:'0123455378', address:'12 Line'}},
{good:{  id: '1', name: 'carrot', description: 'Sweet fresh carrot that can benefit your health',
  price: 3, poster: 'assets/carrot.jpg', discount: 0, vendorId: '3',   amount: 66,  unitType: {
  id: '0', name: 'kg'}, categories: [], images: ['assets/carrot.jpg']}, quantity:2, status: 'On delivery',
recipient: {name: 'Larsy', surname: 'MacGreen', phone:'0123455378', address:'12 Line'}},
{good:{  id: '1', name: 'carrot', description: 'Sweet fresh carrot that can benefit your health',
  price: 3, poster: 'assets/carrot.jpg', discount: 0, vendorId: '3',   amount: 66,  unitType: {
  id: '0', name: 'kg'}, categories: [], images: ['assets/carrot.jpg']}, quantity:2, status: 'On delivery',
recipient: {name: 'Larsy', surname: 'MacGreen', phone:'0123455378', address:'12 Line'}}]

  constructor() { }
}
