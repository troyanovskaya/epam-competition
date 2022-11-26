import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-about-us-container',
  templateUrl: './about-us-container.component.html',
  styleUrls: ['./about-us-container.component.css']
})
export class AboutUsContainerComponent implements OnInit {
  headers: string[] = ['Prices are the same as in the store',
  'Wide range of products', 'Careful ordering', 'Prompt home delivery'];
  paragraphs: string[] = ['We offer the same price as the retailer. Moreover, we collect promotional products in one place so that your purchases are profitable.',
  'The entire range of products on the site is the same as in the market. Of the advantages: no need to wander department store - just press a button, because we have all the products are sorted in categories.',
  'Our shoppers (people who collect an order for you) choose only the best products from those offered in the store and follow the rules of the commodity neighborhood. We form an order as for ourselves.',
  'Our logistics department thinks out in detail the courier`s route to your home so that you receive your order on time and without delays.']

  constructor() { }

  ngOnInit(): void {
  }

}
