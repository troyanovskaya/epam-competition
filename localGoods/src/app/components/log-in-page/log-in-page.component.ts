import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { MatDialogRef, MatDialog } from '@angular/material/dialog';
import { SignUpPageComponent } from '../sign-up-page/sign-up-page.component';
import { HttpRequestService } from '../../services/http-request.service';
import { catchError, of} from 'rxjs';
import { UserForgotPasswordComponent } from '../user-forgot-password/user-forgot-password.component';

@Component({
  selector: 'app-log-in-page',
  templateUrl: './log-in-page.component.html',
  styleUrls: ['./log-in-page.component.css']
})

export class LogInPageComponent {

  visible: boolean= true;
  changetype: boolean = true;

  constructor(private dialogRef: MatDialogRef<LogInPageComponent>,
              private dialog: MatDialog,
              private http:HttpRequestService) { }

  validationForm = new FormGroup({
    email: new FormControl('', [
      Validators.required,
      Validators.email
    ]),
    password: new FormControl('', [
      Validators.required,
      Validators.minLength(8),
      Validators.pattern("^(?=.*[0-9])(?=.*[A-Z])(?!.* ).{8,}$"),
      Validators.maxLength(20)
    ]),
  })

  checkUser() {
    this.http.checkUser("/Auth/login",
      {
        email: this.validationForm.value.email,
        password: this.validationForm.value.password
      },
      this.dialogRef)
  }

  closeWindow() {
    this.dialogRef.close()
  }

  openSignUp(){
    this.dialogRef.close()
    this.dialog.open(SignUpPageComponent, {
      height: '60%',
      width: '50%',
      panelClass: 'custom-dialog-container'
    },
    );
  }

  onForgotPassword(){
    this.dialog.open(UserForgotPasswordComponent);
  }

  viewPassword(){
    this.visible=!this.visible;
    this.changetype=!this.changetype;
  }
}
