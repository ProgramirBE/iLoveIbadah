import { TestBed } from '@angular/core/testing';

import { IslamicFinderService } from './islamic-finder.service';

describe('IslamicFinderService', () => {
  let service: IslamicFinderService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(IslamicFinderService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
