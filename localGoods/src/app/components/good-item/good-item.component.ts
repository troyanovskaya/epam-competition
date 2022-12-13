import { Component, Input, OnInit } from '@angular/core';
import { Good } from 'src/app/schema/good.model';

@Component({
  selector: 'app-good-item',
  templateUrl: './good-item.component.html',
  styleUrls: ['./good-item.component.css']
})
export class GoodItemComponent implements OnInit {
  @Input() item:Good = {  id: '0', name: '', description: '',
    price: 0, poster: '', discount: 0, vendorId: '0', amount: 0,  unitType: {
    id: '0', name: ''}, categories: [], images: []};

  constructor() { }

  ngOnInit(): void {
  }

}
