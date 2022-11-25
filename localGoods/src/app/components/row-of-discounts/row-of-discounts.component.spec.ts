import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RowOfDiscountsComponent } from './row-of-discounts.component';

describe('RowOfDiscountsComponent', () => {
  let component: RowOfDiscountsComponent;
  let fixture: ComponentFixture<RowOfDiscountsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RowOfDiscountsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(RowOfDiscountsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
