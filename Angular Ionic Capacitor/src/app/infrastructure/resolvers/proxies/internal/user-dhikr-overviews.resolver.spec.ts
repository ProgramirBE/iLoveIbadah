import { TestBed } from '@angular/core/testing';
import { ResolveFn } from '@angular/router';

import { userDhikrOverviewsResolver } from './user-dhikr-overviews.resolver';

describe('userDhikrOverviewsResolver', () => {
  const executeResolver: ResolveFn<boolean> = (...resolverParameters) => 
      TestBed.runInInjectionContext(() => userDhikrOverviewsResolver(...resolverParameters));

  beforeEach(() => {
    TestBed.configureTestingModule({});
  });

  it('should be created', () => {
    expect(executeResolver).toBeTruthy();
  });
});
