import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { HttpRequestService } from 'src/app/services/http-request.service';
import { NotifierService } from 'src/app/services/notifier.service';

@Component({
  selector: 'app-send-email-confirmation',
  templateUrl: './send-email-confirmation.component.html',
  styleUrls: ['./send-email-confirmation.component.css']
})
export class SendEmailConfirmationComponent implements OnInit {
  form!: FormGroup;
  submitted: boolean = false;

  constructor(private fb: FormBuilder,
    private httpRequestService: HttpRequestService,
    private router: Router,
    private notifier: NotifierService,
    private dialogRef: MatDialogRef<SendEmailConfirmationComponent>) { }

  ngOnInit(): void {
    this.createForm();
  }

  createForm(){
    this.form = this.fb.group({
      'email':[null, [Validators.required, Validators.email]]
    });
  }

  get email(){
    return this.form.get('email');
  }

  onSubmit(){
    this.submitted = true;
    if (this.form.invalid){
      return;
    }

    this.httpRequestService.sendEmailConfirmationLink(this.email!.value).subscribe(e => {
      this.notifier.showNotification('Email confirmation link was successfully sent!', 'SUCCESS');
      this.dialogRef.close();
    }, err => this.notifier.showNotification(err.error.message, 'ERROR'));
  }
}
