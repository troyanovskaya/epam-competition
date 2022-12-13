import { Injectable } from '@angular/core';
import { Good } from '../schema/good.model';
import { HttpRequestService } from './http-request.service';

@Injectable({
  providedIn: 'root'
})
export class GoodsService {
  goods:Good[] = [];
  keyword:string = '';

  constructor(private httpRequestService: HttpRequestService) {
    this.httpRequestService.getProducts('none', []).subscribe( data => this.goods = data);
  }
  findGoods(Cityid:string, categoryIds:string[]){
    this.httpRequestService.getProducts(Cityid, categoryIds).subscribe( data => this.goods = data);
  }
}
