import { Injectable } from '@angular/core';
import { Good } from '../schema/good.model';
import { Vendor } from '../schema/vendor.model';
import { HttpRequestService } from './http-request.service';

@Injectable({
  providedIn: 'root'
})
export class GoodsService {
  goods:Good[] = [];
  vendors:Vendor[] = [];
  keyword:string = '';
  vendorIds:Set<string> = new Set();

  constructor(private httpRequestService: HttpRequestService) {
    this.httpRequestService.getVendors().subscribe( data => console.log(data))
    this.httpRequestService.getProducts('none', []).subscribe( data => {this.goods = data;
      this.goods.map( el => this.vendorIds.add(el.vendorId));
      this.vendorIds.forEach( el => {
        this.httpRequestService.getVendorById(el).subscribe( data => this.vendors.push(data))
        return el});
      });
      this.vendorIds= new Set();
  }
  findGoods(Cityid:string, categoryIds:string[]){
    if(Cityid==='0') Cityid = 'none';
    this.httpRequestService.getProducts(Cityid, categoryIds).subscribe( data => {this.goods = data;
    this.goods.map( el => this.vendorIds.add(el.vendorId));
    this.vendors = [];
    this.vendorIds.forEach( el => {
      this.httpRequestService.getVendorById(el).subscribe( data => this.vendors.push(data))
      return el;
    })});
    this.vendorIds= new Set();
  }
}
