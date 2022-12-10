import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/services/user.service';
import { VisibilityService } from 'src/app/services/visibility.service';

@Component({
  selector: 'app-reg-vendor',
  templateUrl: './reg-vendor.component.html',
  styleUrls: ['./reg-vendor.component.css']
})
export class RegVendorComponent implements OnInit {

  constructor(public visibilityService:VisibilityService, public userService:UserService) { }

  ngOnInit(): void {
  }

}
