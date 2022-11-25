import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-vendors-adverb',
  templateUrl: './vendors-adverb.component.html',
  styleUrls: ['./vendors-adverb.component.css']
})
export class VendorsAdverbComponent implements OnInit {
  listArray: string[] = ['Choose your location', 'Find your vendor',
'Fill your basket', 'Pay for your order', 'Wait in anticipation for your yummies!']

  constructor() { }

  ngOnInit(): void {
  }

}
