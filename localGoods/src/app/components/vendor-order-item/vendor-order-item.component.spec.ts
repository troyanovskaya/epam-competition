import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VendorOrderItemComponent } from './vendor-order-item.component';

describe('VendorOrderItemComponent', () => {
  let component: VendorOrderItemComponent;
  let fixture: ComponentFixture<VendorOrderItemComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ VendorOrderItemComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(VendorOrderItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
