import { Injectable } from '@angular/core';
import { Good } from '../schema/good.model';

@Injectable({
  providedIn: 'root'
})
export class GoodsService {
  goods:Good[] = [];

  constructor() {
  }
  findGoods(Cityid:string){
    fetch(`https://localgoodsapi.azurewebsites.net/api/Products?CityId=${Cityid}`)
    .then((response) => response.json())
    .then((data) => {this.goods = data});
  }
}
