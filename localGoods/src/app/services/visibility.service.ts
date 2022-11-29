import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class VisibilityService {
  isBasketVisible:boolean = false;

  constructor() { }
}
