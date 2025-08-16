import { Component, OnInit, Input, inject } from '@angular/core';
import { ActivatedRoute, RouterLink } from '@angular/router';
import { NgIf, NgFor } from '@angular/common';
import { Events, EventItem } from '../events';
import { Attendees, Attendee, AttendeeRegisterComponent } from '../../attendees/attendees';

@Component({
  selector: 'app-event-detail',
  standalone: true,
  imports: [RouterLink, NgIf, NgFor, AttendeeRegisterComponent],
  template: `
    <div *ngIf="event">
      <h2>{{ event.title }}</h2>
      <p>{{ event.date }} – {{ event.location }}</p>
      <p>Price: {{ event.price }}</p>
      <p>Capacity: {{ event.capacity }}</p>
      <p>Attendees: {{ event.attendeesCount }}</p>
      <p>{{ event.description }}</p>

      <h3>Register</h3>
      <app-attendee-register
        [eventId]="event!.id ?? 0"
        (register)="onRegister($event)" />

      <h3>Attendees</h3>
      <ul>
        <li *ngFor="let a of attendees">
          {{ a.name }} ({{ a.email }})
        </li>
      </ul>
    </div>
  `
})
export class EventDetail implements OnInit {
  private route = inject(ActivatedRoute);
  private eventsService = inject(Events);
  private attendeesService = inject(Attendees);

  @Input() event?: EventItem;
  attendees: Attendee[] = [];

  ngOnInit() {
    if (!this.event) {
      const id = Number(this.route.snapshot.paramMap.get('id'));
      this.eventsService.getEvent(id).subscribe(evt => {
        this.event = evt;
        this.loadAttendees();
      });
    } else {
      this.loadAttendees();
    }
  }

  loadAttendees() {
    if (!this.event) return;
    this.attendeesService.byEvent(Number(this.event.id)).subscribe(list => {
      this.attendees = list;
    });
  }

  onRegister(data: { name: string; email: string }) {
    if (!this.event) return;
    const att: Attendee = {
      name: data.name,
      email: data.email,
      eventId: Number(this.event.id),
      registeredAt: new Date().toISOString()
    };
    this.attendeesService.register(att).subscribe(saved => {
      this.attendees.push(saved);
      this.event!.attendeesCount++;
      this.eventsService.incrementAttendees(Number(this.event!.id), this.event!.attendeesCount)
        .subscribe();
    });
  }
}
