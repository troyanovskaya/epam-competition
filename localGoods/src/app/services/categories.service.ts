import { Injectable } from '@angular/core';
import { Category } from '../schema/category.model';

@Injectable({
  providedIn: 'root'
})
export class CategoriesService {
  categories:Category[]=[];

  constructor() {
    fetch('https://localgoodsapi.azurewebsites.net/api/Categories')
    .then((response) => response.json())
    .then((data) => {this.categories = data});
   }
}
