import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class OrderInProcessService {
  currentOrders=[{id:1, adress:'Green street 16B, 13412', vendor: 'Vendor1', total:'643', status:'Waiting for approval'},
  {id:1, adress:'Green street 16B, 13412', vendor: 'Vendor1', total:'643', status:'Waiting for approval'},
  {id:1, adress:'Green street 16B, 13412', vendor: 'Vendor1', total:'643', status:'Waiting for approval'},
  {id:1, adress:'Green street 16B, 13412', vendor: 'Vendor1', total:'643', status:'Waiting for approval'},
  {id:1, adress:'Green street 16B, 13412', vendor: 'Vendor1', total:'643', status:'Waiting for approval'}]


  constructor() { }
}
