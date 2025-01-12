import { TestBed } from '@angular/core/testing';
import { ResolveFn } from '@angular/router';

import { userSalahActivitiesResolver } from './user-salah-activities.resolver';

describe('userSalahActivitiesResolver', () => {
  const executeResolver: ResolveFn<boolean> = (...resolverParameters) => 
      TestBed.runInInjectionContext(() => userSalahActivitiesResolver(...resolverParameters));

  beforeEach(() => {
    TestBed.configureTestingModule({});
  });

  it('should be created', () => {
    expect(executeResolver).toBeTruthy();
  });
});
