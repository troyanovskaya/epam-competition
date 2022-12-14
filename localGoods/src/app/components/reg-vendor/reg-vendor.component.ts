import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, NgForm, Validators } from '@angular/forms';
import { DeliveryMethod } from 'src/app/schema/deliveryMethod.model';
import { PaymentMethod } from 'src/app/schema/paymentMethod.model';
import { VendorRegister } from 'src/app/schema/vendorRegister.model';
import { HttpRequestService } from 'src/app/services/http-request.service';
import { UserService } from 'src/app/services/user.service';
import { VisibilityService } from 'src/app/services/visibility.service';

@Component({
  selector: 'app-reg-vendor',
  templateUrl: './reg-vendor.component.html',
  styleUrls: ['./reg-vendor.component.css']
})
export class RegVendorComponent implements OnInit {
  startErrs = {companyEr:false, paymentEr:false, deliveryEr:false, phoneEr:false, messengerEr:false, mediaEr:false};
  errs = {companyEr:false, paymentEr:false, deliveryEr:false, phoneEr:false, messengerEr:false, mediaEr:false};
  deliveryMethods:DeliveryMethod[] = [];
  paymentMethods: PaymentMethod[] = [];
  messengers:string[] = ['viber', 'whatsapp', 'telegram'];
  media:string[] = ['facebook', 'instagram'];
  phoneDigitsEr:boolean = false;
  // form:FormGroup = new FormGroup({payment: new FormControl<string>('', [
  //   Validators.required]),
  //   company: new FormControl<string>('', [
  //     Validators.required]),
  //   delivery: new FormControl<string>('', [
  //     Validators.required]),
  //   email: new FormControl<string>('', [
  //     Validators.required]),
  //   phone: new FormControl<string>('', [
  //     Validators.required]),
  //   messenger: new FormControl<string>('', [
  //     Validators.required]),
  //   media: new FormControl<string[]>([], [
  //     Validators.required]),
  // });
  digits_only(str:string){
    return [...str].every(c => '0123456789+'.includes(c));
  }
  Show(Form: NgForm): void {
    this.phoneDigitsEr = false;
    if(this.errs.companyEr) this.errs.companyEr = false;
    if(this.errs.paymentEr) this.errs.paymentEr = false;
    if(this.errs.deliveryEr) this.errs.deliveryEr = false;
    if(this.errs.phoneEr) this.errs.phoneEr = false;
    if(this.errs.messengerEr) this.errs.messengerEr = false;
    if(this.errs.mediaEr) this.errs.mediaEr = false;
    if(Form.value.company.length<5){
      this.errs.companyEr = true;
    }
    if(Form.value.phone.length<11 || Form.value.phone.length>15){
      this.errs.phoneEr = true;
    }
    if(!this.digits_only(Form.value.phone)) this.phoneDigitsEr = true;
    let del = 0;
    let pay = 0;
    let mes = 0;
    let social = 0;
    for (let i =0; i<this.deliveryMethods.length; i++){
      if(Form.value[this.deliveryMethods[i].name]===true){
        del++;
      }
    }
    if(del===0){
      this.errs.deliveryEr = true;
    }
    for (let i =0; i<this.paymentMethods.length; i++){
      if(Form.value[this.paymentMethods[i].name]===true){
        pay++;
      }
    }
    if(pay===0){
      this.errs.paymentEr = true;
    }
    for (let i =0; i<this.media.length; i++){
      if(Form.value[this.media[i]]===true){
        social++;
      }
    }
    if(social===0){
      this.errs.mediaEr = true;
    }
    for (let i =0; i<this.messengers.length; i++){
      if(Form.value[this.messengers[i]]===true){
        mes++;
      }
    }
    if(mes===0){
      this.errs.messengerEr = true;
    }
    if(Object.values(this.errs).reduce((past, cur) => past&&!cur, true)&&!this.phoneDigitsEr){
      this.createVendor();
    }

  }
  createVendor(){
    this.userService.userRole = 'VENDOR';
    this.visibilityService.isVendorRegVisible = false;
    // let vendor: VendorRegister =
    //console.log(this.form.controls);
  }

  constructor(public visibilityService:VisibilityService, public userService:UserService,
    public httpRequestService: HttpRequestService) { }

  ngOnInit(): void {
    this.httpRequestService.getDelMeth().subscribe( res => this.deliveryMethods = res);
    this.httpRequestService.getPayMeth().subscribe( res => this.paymentMethods = res);
  }

}
