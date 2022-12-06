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
  constructor(public userService:UserService) { }

  ngOnInit(): void {
  }

}
