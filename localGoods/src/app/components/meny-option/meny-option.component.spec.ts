import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MenyOptionComponent } from './meny-option.component';

describe('MenyOptionComponent', () => {
  let component: MenyOptionComponent;
  let fixture: ComponentFixture<MenyOptionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MenyOptionComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MenyOptionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
