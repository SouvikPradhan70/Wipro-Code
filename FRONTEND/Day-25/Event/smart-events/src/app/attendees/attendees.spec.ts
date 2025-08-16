import { TestBed } from '@angular/core/testing';

import { Attendees } from './attendees';

describe('Attendees', () => {
  let service: Attendees;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(Attendees);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
