import { Component, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { HttpRequestService } from '../../services/http-request.service';
import { catchError, of, tap } from 'rxjs';
import { City, Country } from '../country.model';
import { LocalStorageService } from 'src/app/local-storage.service';


@Component({
  selector: 'app-sign-up-page',
  templateUrl: './sign-up-page.component.html',
  styleUrls: ['./sign-up-page.component.css']
})
export class SignUpPageComponent {
  cities: Array<City> = [];

  selectedCityId!: string;

  validationForm = new FormGroup({
    email: new FormControl('', [
      Validators.required,
      Validators.email
    ]),
    firstName: new FormControl('', [
      Validators.required,
      Validators.pattern('[A-Za-z]{1,32}')
    ]),
    lastName: new FormControl('', [
      Validators.required,
      Validators.pattern('[A-Za-z]{1,32}')
    ]),
    phone: new FormControl('', [
      Validators.required,
      Validators.pattern("^([+]?[\s0-9]+)?(\d{3}|[(]?[0-9]+[)])?([-]?[\s]?[0-9])+$")
    ]),
    password: new FormControl('', [
      Validators.required,
      Validators.minLength(8),
      Validators.pattern("^(?=.*[0-9])(?=.*[A-Z])(?!.* ).{8,}$"),
      Validators.maxLength(20)
    ]),
    city: new FormControl('', [
      Validators.required
    ]),
    confirmation: new FormControl('', [
      Validators.required,
      Validators.minLength(8),
      Validators.pattern("^(?=.*[0-9])(?=.*[A-Z])(?!.* ).{8,}$"),
      Validators.maxLength(20)
    ]),
  })

  constructor(
    private dialogRef: MatDialogRef<SignUpPageComponent>,
    private http: HttpRequestService,
    private localStorageService: LocalStorageService) { }

  ngOnInit() {
    this.http.getCountries().subscribe((countriesList: Array<Country>) => {
      countriesList.forEach((country) => {
        this.cities.push(...country.cities);
      })
    this.selectedCityId = this.cities[0].id;
    });
  }

  closeWindow() {
    this.dialogRef.close();
  }

  createAccount() {
    this.http.post('/Auth/signup', {
      email: this.validationForm.value.email,
      firstName: this.validationForm.value.firstName,
      lastName: this.validationForm.value.lastName,
      phoneNumber: this.validationForm.value.phone,
      password: this.validationForm.value.password,
      cityId: this.selectedCityId
    }).pipe(
      tap(token =>{
        this.localStorageService.setItemToStorage('user', token.toString());
        this.dialogRef.close();
        return; 
      }),
      catchError(err => {
        alert(err.error.message)
        return of('');
      })
    ).subscribe()
  }

  selectCity() {
    this.selectedCityId = this.cities.find(city => city.name == this.validationForm.value.city)!.id;
  }
}
