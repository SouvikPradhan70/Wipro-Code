import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AttendeeDetail } from './attendee-detail';

describe('AttendeeDetail', () => {
  let component: AttendeeDetail;
  let fixture: ComponentFixture<AttendeeDetail>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AttendeeDetail]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AttendeeDetail);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
