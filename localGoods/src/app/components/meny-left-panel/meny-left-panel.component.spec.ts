import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MenyLeftPanelComponent } from './meny-left-panel.component';

describe('MenyLeftPanelComponent', () => {
  let component: MenyLeftPanelComponent;
  let fixture: ComponentFixture<MenyLeftPanelComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MenyLeftPanelComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MenyLeftPanelComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
