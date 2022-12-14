import { Pipe, PipeTransform } from '@angular/core';
import { Good } from '../schema/good.model';

@Pipe({
  name: 'goodsByKeyword',
  pure: false
})
export class GoodsByKeywordPipe implements PipeTransform {

  transform(goods:Good[], keyword:string): Good[] {
    return goods.filter(g => g.name.toLowerCase().includes(keyword.toLowerCase()));
  }

}
