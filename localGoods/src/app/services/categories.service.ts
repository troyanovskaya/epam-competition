import { Injectable } from '@angular/core';
import { Category } from '../schema/category.model';
import { HttpRequestService } from './http-request.service';

@Injectable({
  providedIn: 'root'
})
export class CategoriesService {
  categories: Category[] = [];

  constructor(private http: HttpRequestService) {
    this.http.getCategories()
    .subscribe( res => this.categories = res);
   }
}
