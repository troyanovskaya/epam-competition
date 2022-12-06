import { Component, Input, OnInit } from '@angular/core';
import {Category} from '../../schema/Category'

@Component({
  selector: 'app-meny-option',
  templateUrl: './meny-option.component.html',
  styleUrls: ['./meny-option.component.css']
})
export class MenyOptionComponent implements OnInit {
  @Input() option:Category = {id: '', name: ''};
  isActive:boolean = false;

  constructor() { }

  ngOnInit(): void {
  }

}
