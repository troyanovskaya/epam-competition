import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RegVendorComponent } from './reg-vendor.component';

describe('RegVendorComponent', () => {
  let component: RegVendorComponent;
  let fixture: ComponentFixture<RegVendorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RegVendorComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(RegVendorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
