import { Injectable } from '@angular/core';
import { Good } from '../schema/good.model';

@Injectable({
  providedIn: 'root'
})
export class PublishedGoodsService {
  vendorGoods:Good[] = [{  id: '1', name: 'carrot', description: 'Sweet fresh carrot that can benefit your health',
  price: 3, poster: 'assets/carrot.jpg', discount: 0, vendorId: '3',   amount: 66,  unitType: {
  id: '0', name: 'kg'}, categories: [], images: ['assets/carrot.jpg']}, {  id: '2', name: 'carrot', description: 'Sweet fresh carrot that can benefit your health',
  price: 3, poster: 'assets/carrot.jpg', discount: 0, vendorId: '3',   amount: 66,  unitType: {
  id: '0', name: 'kg'}, categories: [], images: ['assets/carrot.jpg']}, {  id: '3', name: 'carrot', description: 'Sweet fresh carrot that can benefit your health',
  price: 3, poster: 'assets/carrot.jpg', discount: 0, vendorId: '3',   amount: 66,  unitType: {
  id: '0', name: 'kg'}, categories: [], images: ['assets/carrot.jpg']}, {  id: '4', name: 'carrot', description: 'Sweet fresh carrot that can benefit your health',
  price: 3, poster: 'assets/carrot.jpg', discount: 0, vendorId: '3',   amount: 66,  unitType: {
  id: '0', name: 'kg'}, categories: [], images: ['assets/carrot.jpg']}, {  id: '5', name: 'carrot', description: 'Sweet fresh carrot that can benefit your health',
  price: 3, poster: 'assets/carrot.jpg', discount: 0, vendorId: '3',   amount: 66,  unitType: {
  id: '0', name: 'kg'}, categories: [], images: ['assets/carrot.jpg']},
  {  id: '6', name: 'carrot', description: 'Sweet fresh carrot that can benefit your health',
  price: 3, poster: 'assets/carrot.jpg', discount: 0, vendorId: '3',   amount: 66,  unitType: {
  id: '0', name: 'kg'}, categories: [], images: ['assets/carrot.jpg']}]

  constructor() { }
}
