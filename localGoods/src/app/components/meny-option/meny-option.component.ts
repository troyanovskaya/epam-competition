import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-meny-option',
  templateUrl: './meny-option.component.html',
  styleUrls: ['./meny-option.component.css']
})
export class MenyOptionComponent implements OnInit {
  @Input() option:string = '';
  isActive:boolean = false;

  constructor() { }

  ngOnInit(): void {
  }

}
