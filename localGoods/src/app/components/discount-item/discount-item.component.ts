import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-discount-item',
  templateUrl: './discount-item.component.html',
  styleUrls: ['./discount-item.component.css']
})
export class DiscountItemComponent implements OnInit {
  @Input() item:{name: string, curPrice:number, pastPrice:number, id:number} = {name: '', curPrice:0, pastPrice:0, id:0}

  constructor() { }

  ngOnInit(): void {
  }

}
