import { TestBed } from '@angular/core/testing';
import { ResolveFn } from '@angular/router';

import { userSalahOverviewsResolver } from './user-salah-overviews.resolver';

describe('userSalahOverviewsResolver', () => {
  const executeResolver: ResolveFn<boolean> = (...resolverParameters) => 
      TestBed.runInInjectionContext(() => userSalahOverviewsResolver(...resolverParameters));

  beforeEach(() => {
    TestBed.configureTestingModule({});
  });

  it('should be created', () => {
    expect(executeResolver).toBeTruthy();
  });
});
