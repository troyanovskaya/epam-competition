import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { MatDialogRef, MatDialog } from '@angular/material/dialog';
import { SignUpPageComponent } from '../sign-up-page/sign-up-page.component';
import { HttpRequestService } from '../../services/http-request.service';
import { catchError, of} from 'rxjs';

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
    this.http.post("/Auth/login",{email: this.validationForm.value.email, password: this.validationForm.value.password})
    .pipe(
      catchError(err => {
        alert(err.error.message)
        return of('');
      })
    )
    .subscribe()
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
