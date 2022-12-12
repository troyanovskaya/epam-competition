import { TestBed } from '@angular/core/testing';

import { PublishedOrderService } from './published-order.service';

describe('PublishedOrderService', () => {
  let service: PublishedOrderService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PublishedOrderService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
