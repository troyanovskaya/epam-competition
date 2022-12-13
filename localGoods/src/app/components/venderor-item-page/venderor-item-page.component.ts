import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-venderor-item-page',
  templateUrl: './venderor-item-page.component.html',
  styleUrls: ['./venderor-item-page.component.css']
})
export class VenderorItemPageComponent implements OnInit {

  products!: Array<Object>;
  constructor() { }

  ngOnInit(): void {
  }

}
