import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VendorsSearchComponent } from './vendors-search.component';

describe('VendorsSearchComponent', () => {
  let component: VendorsSearchComponent;
  let fixture: ComponentFixture<VendorsSearchComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ VendorsSearchComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(VendorsSearchComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
