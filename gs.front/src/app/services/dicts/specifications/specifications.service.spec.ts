import { TestBed, inject } from '@angular/core/testing';

import { SpecificationsService } from './specifications.service';

describe('SpecificationsService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [SpecificationsService]
    });
  });

  it('should be created', inject([SpecificationsService], (service: SpecificationsService) => {
    expect(service).toBeTruthy();
  }));
});
