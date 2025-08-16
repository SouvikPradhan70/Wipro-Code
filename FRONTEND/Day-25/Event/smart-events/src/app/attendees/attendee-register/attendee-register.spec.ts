import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AttendeeRegister } from './attendee-register';

describe('AttendeeRegister', () => {
  let component: AttendeeRegister;
  let fixture: ComponentFixture<AttendeeRegister>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AttendeeRegister]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AttendeeRegister);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
