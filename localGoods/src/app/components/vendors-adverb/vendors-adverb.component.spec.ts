import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VendorsAdverbComponent } from './vendors-adverb.component';

describe('VendorsAdverbComponent', () => {
  let component: VendorsAdverbComponent;
  let fixture: ComponentFixture<VendorsAdverbComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ VendorsAdverbComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(VendorsAdverbComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
