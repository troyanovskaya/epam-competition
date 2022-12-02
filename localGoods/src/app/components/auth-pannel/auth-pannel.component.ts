import { Component, OnInit } from '@angular/core';
import { BasketService } from 'src/app/services/basket.service';
import { VisibilityService } from 'src/app/services/visibility.service';

@Component({
  selector: 'app-auth-pannel',
  templateUrl: './auth-pannel.component.html',
  styleUrls: ['./auth-pannel.component.css']
})
export class AuthPannelComponent implements OnInit {
  logoName: string = 'local.goods';
  userInfoHidden:boolean = true;

  constructor(public visibility: VisibilityService, public basketService:BasketService) { }

  ngOnInit(): void {

  }

}
