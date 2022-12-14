import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BasketPanelComponent } from './basket-panel.component';

describe('BasketPanelComponent', () => {
  let component: BasketPanelComponent;
  let fixture: ComponentFixture<BasketPanelComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BasketPanelComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(BasketPanelComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
