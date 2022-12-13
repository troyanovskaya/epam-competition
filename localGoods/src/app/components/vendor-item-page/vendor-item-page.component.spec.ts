import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VendorItemPageComponent } from './vendor-item-page.component';

describe('VendorItemPageComponent', () => {
  let component: VendorItemPageComponent;
  let fixture: ComponentFixture<VendorItemPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ VendorItemPageComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(VendorItemPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
