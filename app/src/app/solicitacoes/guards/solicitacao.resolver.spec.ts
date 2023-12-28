import { TestBed } from '@angular/core/testing';
import { ResolveFn } from '@angular/router';

import { solicitacaoResolver } from './solicitacao.resolver';

describe('solicitacaoResolver', () => {
  const executeResolver: ResolveFn<boolean> = (...resolverParameters) => 
      TestBed.runInInjectionContext(() => solicitacaoResolver(...resolverParameters));

  beforeEach(() => {
    TestBed.configureTestingModule({});
  });

  it('should be created', () => {
    expect(executeResolver).toBeTruthy();
  });
});
