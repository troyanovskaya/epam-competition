import { Component, OnInit } from '@angular/core';
import { BasketService } from 'src/app/services/basket.service';
import { VisibilityService } from 'src/app/services/visibility.service';
import { MatDialog } from '@angular/material/dialog';
import { LogInPageComponent } from '../log-in-page/log-in-page.component';
import { SignUpPageComponent } from '../sign-up-page/sign-up-page.component';

@Component({
  selector: 'app-auth-pannel',
  templateUrl: './auth-pannel.component.html',
  styleUrls: ['./auth-pannel.component.css']
})
export class AuthPannelComponent {
  logoName: string = 'local.goods';
  userInfoHidden:boolean = true;

  constructor(private dialogRef: MatDialog, public visibility: VisibilityService, public basketService:BasketService) { }

  openLogInPage() {
    this.dialogRef.open(LogInPageComponent, {
      height: '50%',
      width: '40%',
    },
    );
  }
  openSignUpPage(){
    this.dialogRef.open(SignUpPageComponent, {
      height: '60%',
      width: '50%',
    },
    );
  }

}
