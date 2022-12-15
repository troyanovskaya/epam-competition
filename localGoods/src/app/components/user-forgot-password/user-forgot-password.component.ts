import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { HttpRequestService } from 'src/app/services/http-request.service';
import { NotifierService } from 'src/app/services/notifier.service';

@Component({
  selector: 'app-user-forgot-password',
  templateUrl: './user-forgot-password.component.html',
  styleUrls: ['./user-forgot-password.component.css']
})
export class UserForgotPasswordComponent implements OnInit {
  form!: FormGroup;
  submitted: boolean = false;

  constructor(private fb: FormBuilder,
    private httpRequestService: HttpRequestService,
    private notifier: NotifierService,
    private dialogRef: MatDialogRef<UserForgotPasswordComponent>) { }

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

    const model = {email: this.email!.value};

    this.httpRequestService.forgotPassword(model).subscribe(e => {
      this.notifier.showNotification('Password recovery link sent!','SUCCESS')
      this.dialogRef.close();
    }, err => {
      console.log(err);
      this.notifier.showNotification(err.error.message, 'ERROR')
    });
  }
}
