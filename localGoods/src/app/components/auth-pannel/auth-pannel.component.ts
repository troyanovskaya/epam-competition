import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-auth-pannel',
  templateUrl: './auth-pannel.component.html',
  styleUrls: ['./auth-pannel.component.css']
})
export class AuthPannelComponent implements OnInit {
  logoName: string = 'local.goods'

  constructor() { }

  ngOnInit(): void {
  }

}
