import { TestBed } from '@angular/core/testing';

import { PublishedGoodsService } from './published-goods.service';

describe('PublishedGoodsService', () => {
  let service: PublishedGoodsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PublishedGoodsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
