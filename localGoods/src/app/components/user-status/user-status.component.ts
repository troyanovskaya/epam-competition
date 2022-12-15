import { Component, OnInit } from '@angular/core';
import { OrderInProcessService } from 'src/app/services/order-in-process.service';

@Component({
  selector: 'app-user-status',
  templateUrl: './user-status.component.html',
  styleUrls: ['./user-status.component.css']
})
export class UserStatusComponent implements OnInit {

  constructor(public orderInProcessService: OrderInProcessService) { }

  ngOnInit(): void {
  }

}
