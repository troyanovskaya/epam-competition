import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VendorGoodItemComponent } from './vendor-good-item.component';

describe('VendorGoodItemComponent', () => {
  let component: VendorGoodItemComponent;
  let fixture: ComponentFixture<VendorGoodItemComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ VendorGoodItemComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(VendorGoodItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
