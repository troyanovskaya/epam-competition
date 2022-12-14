import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { Good } from '../schema/good.model';
import { Vendor } from '../schema/vendor.model';

@Injectable({
  providedIn: 'root'
})
export class ShareDataService {

  private vendor!: Vendor;
  private item!: Good;

  getVendor() {
    return this.vendor;
  }

  setVendor(vendor: Vendor) {
    this.vendor = vendor;
    return;
  }
}
