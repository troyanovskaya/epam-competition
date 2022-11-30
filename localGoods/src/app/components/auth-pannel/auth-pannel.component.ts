import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { LogInPageComponent } from '../log-in-page/log-in-page.component';

@Component({
  selector: 'app-auth-pannel',
  templateUrl: './auth-pannel.component.html',
  styleUrls: ['./auth-pannel.component.css']
})
export class AuthPannelComponent implements OnInit {
  logoName: string = 'local.goods'

  constructor(private dialogRef: MatDialog) { }

  ngOnInit(): void {
  }

  openLogInPage(){
    this.dialogRef.open(LogInPageComponent, {
      height: '50%',
      width: '40%',
    },
    );
  }

}
