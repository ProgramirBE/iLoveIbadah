import { TestBed } from '@angular/core/testing';
import { ResolveFn } from '@angular/router';

import { dhikrTypesResolver } from './dhikr-types.resolver';

describe('dhikrTypesResolver', () => {
  const executeResolver: ResolveFn<boolean> = (...resolverParameters) => 
      TestBed.runInInjectionContext(() => dhikrTypesResolver(...resolverParameters));

  beforeEach(() => {
    TestBed.configureTestingModule({});
  });

  it('should be created', () => {
    expect(executeResolver).toBeTruthy();
  });
});
