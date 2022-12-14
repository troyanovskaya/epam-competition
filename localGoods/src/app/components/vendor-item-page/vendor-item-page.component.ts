import { ChangeDetectorRef, Component, OnChanges, OnInit, SimpleChanges } from '@angular/core';
import { tap } from 'rxjs';
import { Good } from 'src/app/schema/good.model';
import { Vendor } from 'src/app/schema/vendor.model';
import { HttpRequestService } from 'src/app/services/http-request.service';
import { ShareDataService } from 'src/app/services/share-data.service';

@Component({
  selector: 'app-vendor-item-page',
  templateUrl: './vendor-item-page.component.html',
  styleUrls: ['./vendor-item-page.component.css']
})
export class VendorItemPageComponent implements OnInit {

  products: Good[] = [];
  vendor!: Vendor;
  // vendorId!: string;

  constructor(private http: HttpRequestService,
    private shareDataService: ShareDataService) { }

  ngOnInit() {
    this.vendor = this.shareDataService.getVendor();
    // this.vendorId = this.vendor.id;
    this.getProducts()
  }

  getProducts() {
    if(this.vendor){
      this.http.getVendorProducts(this.vendor.id).subscribe((productsList: Good[]) => {
        productsList.forEach((product) => {
          this.products.push(product);
        })
      })
    }
    
  }

}



