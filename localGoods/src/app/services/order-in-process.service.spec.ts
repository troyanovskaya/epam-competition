import { TestBed } from '@angular/core/testing';

import { OrderInProcessService } from './order-in-process.service';

describe('OrderInProcessService', () => {
  let service: OrderInProcessService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(OrderInProcessService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
