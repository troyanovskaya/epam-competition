import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class OrderHistoryService {
  pastOrders = [{id:1, adress:'Green street 16B, 13412', vendor: 'Vendor1', total:'643', date:'12/11/2022'},
  {id:1, adress:'Green street 16B, 13412', vendor: 'Vendor1', total:'643', date:'12/11/2022'},
  {id:1, adress:'Green street 16B, 13412', vendor: 'Vendor1', total:'643', date:'12/11/2022'},
  {id:1, adress:'Green street 16B, 13412', vendor: 'Vendor1', total:'643', date:'12/11/2022'},
  {id:1, adress:'Green street 16B, 13412', vendor: 'Vendor1', total:'643', date:'12/11/2022'},
  {id:1, adress:'Green street 16B, 13412', vendor: 'Vendor1', total:'643', date:'12/11/2022'},
  {id:1, adress:'Green street 16B, 13412', vendor: 'Vendor1', total:'643', date:'12/11/2022'},
  {id:1, adress:'Green street 16B, 13412', vendor: 'Vendor1', total:'643', date:'12/11/2022'},
  {id:1, adress:'Green street 16B, 13412', vendor: 'Vendor1', total:'643', date:'12/11/2022'},
  {id:1, adress:'Green street 16B, 13412', vendor: 'Vendor1', total:'643', date:'12/11/2022'},
  {id:1, adress:'Green street 16B, 13412', vendor: 'Vendor1', total:'643', date:'12/11/2022'},
  {id:1, adress:'Green street 16B, 13412', vendor: 'Vendor1', total:'643', date:'12/11/2022'},
  {id:1, adress:'Green street 16B, 13412', vendor: 'Vendor1', total:'643', date:'12/11/2022'},
  {id:1, adress:'Green street 16B, 13412', vendor: 'Vendor1', total:'643', date:'12/11/2022'},
  {id:1, adress:'Green street 16B, 13412', vendor: 'Vendor1', total:'643', date:'12/11/2022'}]

  constructor() { }
}
