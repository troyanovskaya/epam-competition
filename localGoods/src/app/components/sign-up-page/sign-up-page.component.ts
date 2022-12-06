import { Component, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { HttpRequestService } from '../http-request.service';
import { Observable, pluck } from 'rxjs';
import { City, Country } from '../country.model';

@Component({
  selector: 'app-sign-up-page',
  templateUrl: './sign-up-page.component.html',
  styleUrls: ['./sign-up-page.component.css']
})
export class SignUpPageComponent {

  currentDate: string = (new Date()).toISOString().replace('/', '-').slice(0, 10);

  cities: Array<City> = [];

  selectedCityId!: string;

  validationForm = new FormGroup({
    email: new FormControl('', [
      Validators.required,
      Validators.email
    ]),
    firstName: new FormControl('', [
      Validators.required,
    ]),
    lastName: new FormControl('', [
      Validators.required
    ]),
    date: new FormControl(this.currentDate, [
      Validators.required
    ]),
    phone: new FormControl('', [
      Validators.required
    ]),
    password: new FormControl('', [
      Validators.required,
      Validators.minLength(8),
    ]),
    city: new FormControl('', [
      Validators.required
    ]),
    confirmation: new FormControl('', [
      Validators.required,
      Validators.minLength(8),
    ]),
  })

  constructor(private dialogRef: MatDialogRef<SignUpPageComponent>, private http: HttpRequestService) { }

  ngOnInit() {
    this.http.getCountries().subscribe((countriesList: Array<Country>) => {
      countriesList.forEach((country) => {
        this.cities.push(...country.cities);
      })
    });
    console.log(this.cities)
  }

  closeWindow() {
    this.dialogRef.close();
  }

  createAccount() {
    this.http.post('/Auth/signup', {
      email: this.validationForm.value.email,
      firstName: this.validationForm.value.firstName,
      lastName: this.validationForm.value.lastName,
      birthDate: this.validationForm.value.date,
      phoneNumber: this.validationForm.value.phone,
      password: this.validationForm.value.password,
      cityId: this.selectedCityId
    }).subscribe()
  }

  selectCity() {
    this.selectedCityId = this.cities.find(city => city.name == this.validationForm.value.city)!.id;
    console.log(this.selectedCityId)
  }
}
