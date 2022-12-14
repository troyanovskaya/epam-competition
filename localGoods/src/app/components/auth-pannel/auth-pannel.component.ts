import { Component, OnInit } from '@angular/core';
import { BasketService } from 'src/app/services/basket.service';
import { VisibilityService } from 'src/app/services/visibility.service';
import { MatDialog } from '@angular/material/dialog';
import { LogInPageComponent } from '../log-in-page/log-in-page.component';
import { SignUpPageComponent } from '../sign-up-page/sign-up-page.component';
import { UserService } from 'src/app/services/user.service';
import { Location } from '@angular/common';


@Component({
  selector: 'app-auth-pannel',
  templateUrl: './auth-pannel.component.html',
  styleUrls: ['./auth-pannel.component.css']
})
export class AuthPannelComponent {
  logoName: string = 'local.goods';
  userInfoHidden:boolean = true;

  constructor(private dialogRef: MatDialog, public visibility: VisibilityService, public basketService:BasketService,
    public userService:UserService, private _location: Location,) { }

  openLogInPage() {
    this.dialogRef.open(LogInPageComponent, {
      height: '50%',
      width: '40%',
      panelClass: 'custom-dialog-container'
    },
    );
  }

  openSignUpPage(){
    this.dialogRef.open(SignUpPageComponent, {
      height: '60%',
      width: '50%',
      panelClass: 'custom-dialog-container'
    },
    );
  }

  signOut(){
    localStorage.removeItem('user');
    this.userService.isAutorized = false;
  }

}
