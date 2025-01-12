import { TestBed } from '@angular/core/testing';

import { DhikrTypeService } from './dhikr-type.service';

describe('DhikrTypeService', () => {
  let service: DhikrTypeService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(DhikrTypeService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
