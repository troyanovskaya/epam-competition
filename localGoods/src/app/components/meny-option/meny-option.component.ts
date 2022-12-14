import { Component, Input, OnInit } from '@angular/core';
import { CategoriesService } from 'src/app/services/categories.service';
import { GoodsService } from 'src/app/services/goods.service';
import { LocationService } from 'src/app/services/location.service';
import {Category} from '../../schema/category.model'

@Component({
  selector: 'app-meny-option',
  templateUrl: './meny-option.component.html',
  styleUrls: ['./meny-option.component.css']
})
export class MenyOptionComponent implements OnInit {
  @Input() option:Category = {id: '', name: ''};
  isActive:boolean = false;
  activate(){
    this.isActive=!this.isActive;
    if(this.isActive){
      this.categoryService.listOfChosen.push(this.option.id);
    } else{
      this.categoryService.listOfChosen = this.categoryService.listOfChosen
      .filter( el => el!==this.option.id);
    }
    this.goodService.findGoods(this.locationService.choosenCity.id, this.categoryService.listOfChosen)
  }

  constructor(private categoryService:CategoriesService,
    private goodService:GoodsService,
    private locationService: LocationService) { }

  ngOnInit(): void {
  }
}
