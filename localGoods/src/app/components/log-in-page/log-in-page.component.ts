import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { MatDialogRef, MatDialog } from '@angular/material/dialog';
import { SignUpPageComponent } from '../sign-up-page/sign-up-page.component';

@Component({
  selector: 'app-log-in-page',
  templateUrl: './log-in-page.component.html',
  styleUrls: ['./log-in-page.component.css']
})
export class LogInPageComponent {
  constructor(private dialogRef: MatDialogRef<LogInPageComponent>, private signUpDialogRef: MatDialog) { }

  validationForm = new FormGroup({
    email: new FormControl(''),
    password: new FormControl('')
  })

  logger() {
    console.log(this.validationForm.value)
  }

  closeWindow() {
    this.dialogRef.close()
  }

  openSignUp(){    
    this.dialogRef.close()
    this.signUpDialogRef.open(SignUpPageComponent, {
      height: '50%',
      width: '40%',
    },
    );
  }
}
