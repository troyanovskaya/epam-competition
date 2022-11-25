import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-row-of-discounts',
  templateUrl: './row-of-discounts.component.html',
  styleUrls: ['./row-of-discounts.component.css']
})
export class RowOfDiscountsComponent implements OnInit {
  arrOfItems: {name: string, curPrice:number, pastPrice:number, id:number}[]=[
    {name: 'Item1', curPrice:100, pastPrice:150, id:1},
    {name: 'Item2', curPrice:100, pastPrice:150, id:2},
    {name: 'Item3', curPrice:100, pastPrice:150, id:3},
    {name: 'Item4', curPrice:100, pastPrice:150, id:4},
    {name: 'Item5', curPrice:100, pastPrice:150, id:5},
    {name: 'Item6', curPrice:100, pastPrice:150, id:6},
    {name: 'Item7', curPrice:100, pastPrice:150, id:7},
    {name: 'Item8', curPrice:100, pastPrice:150, id:8},
    {name: 'Item9', curPrice:100, pastPrice:150, id:9},
    {name: 'Item10', curPrice:100, pastPrice:150, id:10}
  ]

  constructor() { }

  ngOnInit(): void {
  }

}
