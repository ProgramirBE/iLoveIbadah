import { TestBed } from '@angular/core/testing';

import { UseraccountsService } from './useraccounts.service';

describe('UseraccountsService', () => {
  let service: UseraccountsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(UseraccountsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
