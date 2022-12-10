import { Pipe, PipeTransform } from '@angular/core';
import { Good } from '../schema/good.model';
import { OrderItem } from '../schema/orderItem.model';
import { GoodsService } from '../services/goods.service';


@Pipe({
  name: 'basketVendor',
  pure: false
})
export class BasketVendorPipe implements PipeTransform {

  transform(orders:OrderItem[], search:string): OrderItem[] {
    if (search==='all'){
      return orders;
    }
    return orders.filter( el => el.good.vendorId===search);
  }

}
