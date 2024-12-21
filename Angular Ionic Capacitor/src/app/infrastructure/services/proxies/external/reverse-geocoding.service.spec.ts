import { TestBed } from '@angular/core/testing';

import { ReverseGeocodingService } from './reverse-geocoding.service';

describe('ReverseGeocodingService', () => {
  let service: ReverseGeocodingService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ReverseGeocodingService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
