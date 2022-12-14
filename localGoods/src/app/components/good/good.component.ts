import { Component, Input, OnInit } from '@angular/core';
import { Good } from 'src/app/schema/good.model';
import { ShareDataService } from 'src/app/services/share-data.service';

@Component({
  selector: 'app-good',
  templateUrl: './good.component.html',
  styleUrls: ['./good.component.css']
})
export class GoodComponent implements OnInit {

  @Input() item!: Good;

  constructor(private shareDataService: ShareDataService) { }

  ngOnInit() {
    console.log(this.item)
  }

}


