import { TestBed } from '@angular/core/testing';

import { GeneralDetailsService } from './general-details.service';

describe('GeneralDetailsService', () => {
  let service: GeneralDetailsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(GeneralDetailsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
