import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Good } from 'src/app/schema/good.model';
import { PublishedGoodsService } from 'src/app/services/published-goods.service';
import { VendorGoodCraeationComponent } from './vendor-good-craeation/vendor-good-craeation.component';

@Component({
  selector: 'app-vendor-goods',
  templateUrl: './vendor-goods.component.html',
  styleUrls: ['./vendor-goods.component.css']
})
export class VendorGoodsComponent{

  goods:Good[] = [];
  constructor(public publishedGoodsService: PublishedGoodsService,
    private dialogRef: MatDialog) { }

 openCreationPage(){
  this.dialogRef.open(VendorGoodCraeationComponent, {
    height: '60%',
    width: '50%',
    panelClass: 'custom-dialog-container'
  },
  );
 }

}
