import { TestBed, inject } from '@angular/core/testing';

import { GoodsIncomingService } from './goods-incoming.service';

describe('GoodsIncomingService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [GoodsIncomingService]
    });
  });

  it('should be created', inject([GoodsIncomingService], (service: GoodsIncomingService) => {
    expect(service).toBeTruthy();
  }));
});
