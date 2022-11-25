import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LocalVendorsSearchAdverbComponent } from './local-vendors-search-adverb.component';

describe('LocalVendorsSearchAdverbComponent', () => {
  let component: LocalVendorsSearchAdverbComponent;
  let fixture: ComponentFixture<LocalVendorsSearchAdverbComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LocalVendorsSearchAdverbComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(LocalVendorsSearchAdverbComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
