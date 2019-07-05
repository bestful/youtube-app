import { TestBed } from '@angular/core/testing';

import { OembedService } from './oembed.service';

describe('OembedService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: OembedService = TestBed.get(OembedService);
    expect(service).toBeTruthy();
  });
});
