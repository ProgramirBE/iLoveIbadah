import { TestBed } from '@angular/core/testing';

import { UserdhikractivitiesService } from './userdhikractivities.service';

describe('UserdhikractivitiesService', () => {
  let service: UserdhikractivitiesService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(UserdhikractivitiesService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
