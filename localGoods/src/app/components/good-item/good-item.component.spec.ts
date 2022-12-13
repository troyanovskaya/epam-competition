import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GoodItemComponent } from './good-item.component';

describe('GoodItemComponent', () => {
  let component: GoodItemComponent;
  let fixture: ComponentFixture<GoodItemComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GoodItemComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(GoodItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
