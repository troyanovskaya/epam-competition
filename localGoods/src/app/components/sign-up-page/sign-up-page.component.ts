import { Component, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { first } from 'rxjs';

@Component({
  selector: 'app-sign-up-page',
  templateUrl: './sign-up-page.component.html',
  styleUrls: ['./sign-up-page.component.css']
})
export class SignUpPageComponent implements OnInit {

  currentDate: string = (new Date()).toISOString().replace('/', '-').slice(0, 10);

  validationForm = new FormGroup({
    firstName: new FormControl('', [
      Validators.required,
    ]),
    lastName: new FormControl('', [
      Validators.required
    ]),
    date: new FormControl(this.currentDate, [
      Validators.required
    ]),
    city: new FormControl('', [
      Validators.required
    ]),
    email: new FormControl('', [
      Validators.required,
      Validators.email
    ]),
    phone: new FormControl('', [
      Validators.required
    ]),
    password: new FormControl('', [
      Validators.required,
      Validators.minLength(8),
      // Validators.pattern("(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{8,}")
    ]),
    confirmation: new FormControl('', [
      Validators.required,
      Validators.minLength(8),
      // Validators.pattern("(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{8,}")
    ]),
  })

  constructor(private dialogRef: MatDialogRef<SignUpPageComponent>) { }

  ngOnInit(): void {
    debugger
  }

  closeWindow() {
    // this.dialogRef.close()
  }

  ngOnChanges() {

  }

  createAccount() {
  }
}
