import { Component, OnInit } from '@angular/core';
import { VisibilityService } from 'src/app/services/visibility.service';

@Component({
  selector: 'app-reg-vendor',
  templateUrl: './reg-vendor.component.html',
  styleUrls: ['./reg-vendor.component.css']
})
export class RegVendorComponent implements OnInit {

  constructor(public visibilityService:VisibilityService) { }

  ngOnInit(): void {
  }

}
