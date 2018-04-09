import { TestBed, inject } from '@angular/core/testing';

import { GoodCategoriesService } from './good-categories.service';

describe('GoodCategoriesService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [GoodCategoriesService]
    });
  });

  it('should be created', inject([GoodCategoriesService], (service: GoodCategoriesService) => {
    expect(service).toBeTruthy();
  }));
});
