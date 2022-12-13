import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CategoriesStatus } from '../schema/categoriesStatus.model';
import { Category } from '../schema/category.model';
import { HttpRequestService } from './http-request.service';

@Injectable({
  providedIn: 'root'
})
export class CategoriesService {
  categories: Category[] = [];
  listOfChosen:string[] = [];

  constructor(private http: HttpRequestService) {
    this.http.getCategories()
    .subscribe( res => this.categories = res);
   }
}
