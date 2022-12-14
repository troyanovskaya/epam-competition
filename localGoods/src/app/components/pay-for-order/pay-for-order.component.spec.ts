import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PayForOrderComponent } from './pay-for-order.component';

describe('PayForOrderComponent', () => {
  let component: PayForOrderComponent;
  let fixture: ComponentFixture<PayForOrderComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PayForOrderComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PayForOrderComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
