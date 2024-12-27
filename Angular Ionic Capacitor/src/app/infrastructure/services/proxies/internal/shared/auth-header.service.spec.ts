import { TestBed } from '@angular/core/testing';

import { AuthHeaderService } from './auth-header.service';

describe('AuthHeaderService', () => {
  let service: AuthHeaderService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AuthHeaderService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
