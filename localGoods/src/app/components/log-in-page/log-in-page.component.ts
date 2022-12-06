import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { MatDialogRef, MatDialog } from '@angular/material/dialog';
import { SignUpPageComponent } from '../sign-up-page/sign-up-page.component';
import { HttpRequestService } from '../http-request.service';

@Component({
  selector: 'app-log-in-page',
  templateUrl: './log-in-page.component.html',
  styleUrls: ['./log-in-page.component.css']
})

export class LogInPageComponent {

  constructor(private dialogRef: MatDialogRef<LogInPageComponent>, 
              private signUpDialogRef: MatDialog,
              private http:HttpRequestService) { }

  validationForm = new FormGroup({
    email: new FormControl(''),
    password: new FormControl('')
  })

  checkUser() {
    console.log(this.http.post("auth/login",this.validationForm.value));
  }

  closeWindow() {
    this.dialogRef.close()
  }

  openSignUp(){    
    this.dialogRef.close()
    this.signUpDialogRef.open(SignUpPageComponent, {
      height: '60%',
      width: '50%',
    },
    );
  }
}
