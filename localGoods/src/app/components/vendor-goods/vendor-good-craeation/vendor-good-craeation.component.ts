import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-vendor-good-craeation',
  templateUrl: './vendor-good-craeation.component.html',
  styleUrls: ['./vendor-good-craeation.component.css']
})
export class VendorGoodCraeationComponent{

  goodForm = new FormGroup({
    name: new FormControl('', [
      Validators.required,
    ]),
    description: new FormControl('', [
      Validators.required,
    ]),
    price: new FormControl(0, [
      Validators.required,
    ]),
    discount: new FormControl(0, [
      Validators.required,
    ]),
    
  })

  createGood(){

  }
}
