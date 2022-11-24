import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-nav-option',
  templateUrl: './nav-option.component.html',
  styleUrls: ['./nav-option.component.css']
})
export class NavOptionComponent implements OnInit {
  @Input() option!: { name: string; categories: string[]};
  isVisible:boolean = false;

  constructor() { }

  ngOnInit(): void {
  }

}
