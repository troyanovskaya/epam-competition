import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VendorOrdersComponent } from './vendor-orders.component';

describe('VendorOrdersComponent', () => {
  let component: VendorOrdersComponent;
  let fixture: ComponentFixture<VendorOrdersComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ VendorOrdersComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(VendorOrdersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
