import { Component, OnInit } from '@angular/core';
import { OrderHistoryService } from 'src/app/services/order-history.service';
import { OrderInProcessService } from 'src/app/services/order-in-process.service';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-user-info',
  templateUrl: './user-info.component.html',
  styleUrls: ['./user-info.component.css']
})
export class UserInfoComponent implements OnInit {
  // profile:boolean = true;
  // status:boolean = false;
  // history:boolean = false;

  // activeProfile(){
  //   this.profile = true;
  //   this.status = false;
  //   this.history = false;
  // }
  // activeStatus(){
  //   this.profile = false;
  //   this.status = true;
  //   this.history = false;
  // }
  // activeHistory(){
  //   this.profile = false;
  //   this.status = false;
  //   this.history = true;
  // }
  constructor(public userService:UserService) { }

  ngOnInit(): void {
  }

}
