import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AboutUsContainerComponent } from './about-us-container.component';

describe('AboutUsContainerComponent', () => {
  let component: AboutUsContainerComponent;
  let fixture: ComponentFixture<AboutUsContainerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AboutUsContainerComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AboutUsContainerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
