import { TestBed } from '@angular/core/testing';
import { ResolveFn } from '@angular/router';

import { salahTypesResolver } from './salah-types.resolver';

describe('salahTypesResolver', () => {
  const executeResolver: ResolveFn<boolean> = (...resolverParameters) => 
      TestBed.runInInjectionContext(() => salahTypesResolver(...resolverParameters));

  beforeEach(() => {
    TestBed.configureTestingModule({});
  });

  it('should be created', () => {
    expect(executeResolver).toBeTruthy();
  });
});
