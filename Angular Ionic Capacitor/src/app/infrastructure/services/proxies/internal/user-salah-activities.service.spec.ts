import { TestBed } from '@angular/core/testing';

import { UserSalahActivitiesService } from './user-salah-activities.service';

describe('UserSalahActivitiesService', () => {
  let service: UserSalahActivitiesService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(UserSalahActivitiesService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
