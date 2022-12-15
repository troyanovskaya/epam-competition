import { Good } from "./good.model";

export interface PublishedOrderItem{
  good:Good,
  quantity:number,
  status:string,
  recipient: {name: string, surname: string, phone: string, address:string}

}
