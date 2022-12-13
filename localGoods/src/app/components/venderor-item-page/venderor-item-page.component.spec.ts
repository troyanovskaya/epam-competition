import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VenderorItemPageComponent } from './venderor-item-page.component';

describe('VenderorItemPageComponent', () => {
  let component: VenderorItemPageComponent;
  let fixture: ComponentFixture<VenderorItemPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ VenderorItemPageComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(VenderorItemPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
