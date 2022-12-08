import { Token } from '@angular/compiler';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class LocalStorageService {

  constructor() { }

  setItemToStorage(key: string, value:string){
    localStorage.setItem(key, value)
  }
}
