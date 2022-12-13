import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { HttpRequestService } from 'src/app/services/http-request.service';
import { NotifierService } from 'src/app/services/notifier.service';

@Component({
  selector: 'app-password-recovery',
  templateUrl: './password-recovery.component.html',
  styleUrls: ['./password-recovery.component.css']
})
export class PasswordRecoveryComponent implements OnInit {
  email: string = "";
  token: string = "";
  passwordRecoveryForm!: FormGroup;
  submitted: boolean = false;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private fb: FormBuilder,
    private httpRequestService: HttpRequestService,
    private notifier: NotifierService) { }

  ngOnInit(): void {
    this.route.queryParams.subscribe(params => {
      this.email = params['email']
      this.token = params['token']
    })

    this.createForm();
  }

  createForm(){
    this.passwordRecoveryForm = this.fb.group({
      password: [null, [Validators.required, Validators.minLength(8),
        Validators.pattern("(?=[A-Za-z0-9@#$%^&+!=]+$)^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[@#$%^&+!=])(?=.{8,}).*$")]],
      confirmPassword: [null, [Validators.required, Validators.minLength(8),
        Validators.pattern("(?=[A-Za-z0-9@#$%^&+!=]+$)^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[@#$%^&+!=])(?=.{8,}).*$")]]
    })
  }

  get password(){
    return this.passwordRecoveryForm.get('password');
  }

  get confirmPassword(){
    return this.passwordRecoveryForm.get('confirmPassword');
  }

  onSubmit(){
    this.submitted = true;

    if (this.passwordRecoveryForm.invalid) return;

    if (this.password!.value != this.confirmPassword!.value){
      this.notifier.showNotification("Password don't match", 'ERROR');
      return;
    }

    const model = {token: this.token, email: this.email, password: this.password!.value}

    this.httpRequestService.resetPassword(model).subscribe(p => {
      this.router.navigateByUrl('/');
      this.notifier.showNotification('Password was reset', 'SUCCESS')
    }, err => this.notifier.showNotification(err.error.message, 'ERROR'));
  }
}
