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

  constructor(private httpRequestService: HttpRequestService) {
    this.httpRequestService.getProducts('none', []).subscribe( data => this.goods = data);
    this.httpRequestService.getVendors().subscribe( data => this.vendors = data);
  }
  findGoods(Cityid:string, categoryIds:string[]){
    if(Cityid==='0') Cityid = 'none';
    this.httpRequestService.getProducts(Cityid, categoryIds).subscribe( data => this.goods = data);
  }
}
