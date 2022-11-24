import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AuthPannelComponent } from './auth-pannel.component';

describe('AuthPannelComponent', () => {
  let component: AuthPannelComponent;
  let fixture: ComponentFixture<AuthPannelComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AuthPannelComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AuthPannelComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
