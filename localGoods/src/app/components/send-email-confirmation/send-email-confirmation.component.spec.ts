import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SendEmailConfirmationComponent } from './send-email-confirmation.component';

describe('SendEmailConfirmationComponent', () => {
  let component: SendEmailConfirmationComponent;
  let fixture: ComponentFixture<SendEmailConfirmationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SendEmailConfirmationComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SendEmailConfirmationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
