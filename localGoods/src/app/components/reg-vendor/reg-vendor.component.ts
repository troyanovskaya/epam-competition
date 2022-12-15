import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, NgForm, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { DeliveryMethod } from 'src/app/schema/deliveryMethod.model';
import { PaymentMethod } from 'src/app/schema/paymentMethod.model';
import { HttpRequestService } from 'src/app/services/http-request.service';
import { NotifierService } from 'src/app/services/notifier.service';
import { UserService } from 'src/app/services/user.service';
import { VisibilityService } from 'src/app/services/visibility.service';

@Component({
  selector: 'app-reg-vendor',
  templateUrl: './reg-vendor.component.html',
  styleUrls: ['./reg-vendor.component.css']
})
export class RegVendorComponent implements OnInit {
  form!: FormGroup;
  submitted: boolean = false;

  allPaymentMethods!: PaymentMethod[];
  chosenPaymentMethodIds: any = [];

  allDeliveryMethods!: DeliveryMethod[];
  chosenDeliveryMethodIds: any = [];

  createVendor(){
    this.userService.userRole = 'VENDOR';
    this.visibilityService.isVendorRegVisible = false;
  }

  constructor(public visibilityService:VisibilityService,
    public userService:UserService,
    public httpRequestService: HttpRequestService,
    private fb: FormBuilder,
    private notifier: NotifierService,
    private router: Router) { }

  ngOnInit(): void {
    this.httpRequestService.getPayMeth().subscribe(pm => {
      this.allPaymentMethods = pm;
    }, err => console.log(err));

    this.httpRequestService.getDelMeth().subscribe(dm => {
      this.allDeliveryMethods = dm;
    }, err => console.log(err));

    this.createForm();
  }

  createForm(){
    this.form = this.fb.group({
      name: [null, [Validators.required,
        Validators.minLength(5)]],
      viberNumber: [null, [Validators.required,
        Validators.pattern("^([+]?[\s0-9]+)?(\d{3}|[(]?[0-9]+[)])?([-]?[\s]?[0-9])+$")]],
      telegramName: [null, [Validators.required]],
      instagramName: [null, [Validators.required]]
    })
  }

  get name(){
    return this.form.get('name');
  }

  get viberNumber(){
    return this.form.get('viberNumber');
  }

  get telegramName(){
    return this.form.get('telegramName');
  }

  get instagramName(){
    return this.form.get('instagramName');
  }

  get paymentMethods(){
    return this.form.get('paymentMethods');
  }

  get deliveryMethods(){
    return this.form.get('deliveryMethods');
  }

  onPaymentMethodChange(event: any, id: string){
    if (event.currentTarget.checked){
      this.chosenPaymentMethodIds.push({paymentMethodId: id});
    }
    else{
      const index = this.chosenPaymentMethodIds.map((pm: { paymentMethodId: any; }) => pm.paymentMethodId).indexOf(id);
      if (index > -1){
        this.chosenPaymentMethodIds.splice(index, 1);
      }
    }
  }

  onDeliveryMethodChange(event: any, id: string){
    if (event.currentTarget.checked){
      this.chosenDeliveryMethodIds.push({deliveryMethodId: id, information: 'no info'});
    }
    else{
      const index = this.chosenDeliveryMethodIds.map((dm: { deliveryMethodId: any; }) => dm.deliveryMethodId).indexOf(id);
      if (index > -1){
        this.chosenDeliveryMethodIds.splice(index, 1);
      }
    }
  }

  onSubmit(){
    this.submitted = true;

    if (this.chosenPaymentMethodIds.length == 0){
      this.notifier.showNotification('Please choose at least one payment method', 'ERROR');
      return;
    }

    if (this.chosenDeliveryMethodIds.length == 0){
      this.notifier.showNotification('Please choose at least one delivery method', 'ERROR');
      return;
    }

    if (this.form.invalid) return;

    const model = {
      name: this.name!.value,
      viberNumber: this.viberNumber!.value,
      telegramName: this.telegramName!.value,
      instagramName: this.instagramName!.value,
      paymentMethods: this.chosenPaymentMethodIds,
      deliveryMethods: this.chosenDeliveryMethodIds
    }

    this.httpRequestService.createVendor(model).subscribe(v => {
      this.userService.userRole = 'VENDOR';
      this.notifier.showNotification("You've become a vendor", 'SUCCESS');
      this.router.navigateByUrl('/');
    }, err => {
      this.notifier.showNotification(err.error.message, 'ERROR');
      console.log(err);
    });
  }
}
