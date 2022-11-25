import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';

@Component({
  selector: 'app-vendors-search',
  templateUrl: './vendors-search.component.html',
  styleUrls: ['./vendors-search.component.css']
})
export class VendorsSearchComponent implements OnInit {
  country = new FormControl('uk');
  city = new FormControl('London');
  vendors: string[] = ['Vendor1', 'Vendor2', 'Vendor3', 'Vendor4', 'Vendor5',
  'Vendor6', 'Vendor7', 'Vendor8', 'Vendor9', 'Vendor10', 'Vendor11']

  constructor() { }

  ngOnInit(): void {
  }

}
