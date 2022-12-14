import { Component, Input, OnInit } from '@angular/core';
import { UserService } from 'src/app/services/user.service';
import { VisibilityService } from 'src/app/services/visibility.service';

@Component({
  selector: 'app-user-navigation',
  templateUrl: './user-navigation.component.html',
  styleUrls: ['./user-navigation.component.css']
})
export class UserNavigationComponent implements OnInit {
  @Input() active:number = 1;

  constructor(public userService: UserService, public visibilityService:VisibilityService) { }

  ngOnInit(): void {
  }
  openVendorReg(){
    this.visibilityService.isVendorRegVisible = true;
  }

}
