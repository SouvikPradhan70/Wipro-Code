import { Component, inject } from '@angular/core';
import { NgIf } from '@angular/common';
import { ActivatedRoute } from '@angular/router';
import { Attendees, Attendee } from '../attendees';

@Component({
  selector: 'app-attendee-detail',
  imports: [NgIf],
  template: `
    <div class="wrap" *ngIf="attendee">
      <h3>{{ attendee.name }}</h3>
      <p>{{ attendee.email }}</p>
      <p>Event #{{ attendee.eventId }}</p>
      <p>Registered: {{ attendee.registeredAt }}</p>
    </div>
  `,
  styles: [`.wrap{border:1px solid #ddd; padding:1rem; border-radius:12px;}`]
})
export class AttendeeDetail {
  private route = inject(ActivatedRoute);
  private svc = inject(Attendees);
  attendee?: Attendee;

  constructor() {
    const id = Number(this.route.snapshot.paramMap.get('id'));
    this.svc.getAttendee(id).subscribe(a => this.attendee = a);
  }

}
