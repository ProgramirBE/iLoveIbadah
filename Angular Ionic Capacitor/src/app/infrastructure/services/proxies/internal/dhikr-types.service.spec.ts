import { TestBed } from '@angular/core/testing';

import { DhikrTypesService } from './dhikr-types.service';

describe('DhikrTypesService', () => {
  let service: DhikrTypesService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(DhikrTypesService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
