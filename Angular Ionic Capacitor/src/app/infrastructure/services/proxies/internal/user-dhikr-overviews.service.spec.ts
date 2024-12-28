import { TestBed } from '@angular/core/testing';

import { UserDhikrOverviewsService } from './user-dhikr-overviews.service';

describe('UserDhikrOverviewsService', () => {
  let service: UserDhikrOverviewsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(UserDhikrOverviewsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
