import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GoodComponent } from './good.component';

describe('GoodComponent', () => {
  let component: GoodComponent;
  let fixture: ComponentFixture<GoodComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GoodComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(GoodComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
