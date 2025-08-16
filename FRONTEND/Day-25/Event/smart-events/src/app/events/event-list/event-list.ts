import { CurrencyPipe, DatePipe, NgFor, NgIf } from '@angular/common';
import { Component, OnInit, signal } from '@angular/core';
import { RouterLink } from '@angular/router';
import { MonthFilterPipe } from '../../shared/month-filter-pipe';
import { EventDetail } from '../event-detail/event-detail';
import { Events, EventItem } from '../events';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-event-list',
  standalone: true,
  imports: [
    NgIf,
    NgFor,
    RouterLink,
    DatePipe,
    CurrencyPipe,
    MonthFilterPipe,
    EventDetail,
    FormsModule
  ],
  templateUrl: './event-list.html',
  styleUrls: ['./event-list.scss']
})
export class EventList implements OnInit {
  loading = signal(true);
  error = signal<string | null>(null);
  events = signal<EventItem[]>([]);
  selectedEvent = signal<EventItem | null>(null);
  filterMonth: number | null = null;

  constructor(private svc: Events) {}

  ngOnInit(): void {
    this.svc.getEvents().subscribe({
      next: evts => { 
        this.events.set(evts); 
        this.loading.set(false); 
      },
      error: err => { 
        this.error.set(err.message); 
        this.loading.set(false); 
      }
    });
  }

  select(e: EventItem) {
    this.selectedEvent.set(e);
  }

  handleRegister(evtId: number) {
    const e = this.events().find(x => x.id === evtId);
    if (!e || e.id == null) return;

    this.svc.incrementAttendees(e.id, e.attendeesCount).subscribe({
      next: updated => {
        this.events.update(list => list.map(it => it.id === updated.id ? updated : it));
        if (this.selectedEvent() && this.selectedEvent()!.id === updated.id) {
          this.selectedEvent.set(updated);
        }
        alert('Registered! 🎉');
      },
      error: er => alert(er.message)
    });
  }
}
