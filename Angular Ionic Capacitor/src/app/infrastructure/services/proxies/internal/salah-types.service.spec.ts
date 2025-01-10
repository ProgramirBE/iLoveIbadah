import { TestBed } from '@angular/core/testing';

import { SalahTypesService } from './salah-types.service';

describe('SalahTypesService', () => {
  let service: SalahTypesService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SalahTypesService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
