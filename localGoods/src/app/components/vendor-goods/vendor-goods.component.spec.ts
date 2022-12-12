import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VendorGoodsComponent } from './vendor-goods.component';

describe('VendorGoodsComponent', () => {
  let component: VendorGoodsComponent;
  let fixture: ComponentFixture<VendorGoodsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ VendorGoodsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(VendorGoodsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
