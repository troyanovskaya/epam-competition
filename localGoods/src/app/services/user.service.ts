import { Injectable } from '@angular/core';
import { UserRole } from '../schema/UserRole';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  user = {name:'UserName', surname:'UserSurname', dateOfBirth:'16/03/2000', country:'Ukraine', city:'Kyiv',
  adress: 'Green street, 16B, 74221', phoneNumber:'0951232168', email:'user@gmail.com'};
  userRole: UserRole = 'VENDOR';

  constructor() { }
}
