import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-log-in-page',
  templateUrl: './log-in-page.component.html',
  styleUrls: ['./log-in-page.component.css']
})
export class LogInPageComponent {
  constructor(private dialogRef: MatDialogRef<LogInPageComponent>) { }

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
}
