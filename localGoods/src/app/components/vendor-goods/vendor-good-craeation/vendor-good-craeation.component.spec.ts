import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VendorGoodCraeationComponent } from './vendor-good-craeation.component';

describe('VendorGoodCraeationComponent', () => {
  let component: VendorGoodCraeationComponent;
  let fixture: ComponentFixture<VendorGoodCraeationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ VendorGoodCraeationComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(VendorGoodCraeationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
