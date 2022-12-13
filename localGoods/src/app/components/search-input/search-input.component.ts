import { Component, OnInit } from '@angular/core';
import { GoodsService } from 'src/app/services/goods.service';

@Component({
  selector: 'app-search-input',
  templateUrl: './search-input.component.html',
  styleUrls: ['./search-input.component.css']
})
export class SearchInputComponent implements OnInit {
  keyword:string = '';
  sendKeyword(){
    this.goodService.keyword = this.keyword;
  }


  constructor(private goodService:GoodsService) { }

  ngOnInit(): void {
  }

}
