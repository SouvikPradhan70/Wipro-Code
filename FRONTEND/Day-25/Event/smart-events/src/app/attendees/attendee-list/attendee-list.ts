import { Component, OnInit, signal, computed } from '@angular/core';
import { NgIf, NgFor, DatePipe } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Attendees, Attendee } from '../attendees';
@Component({
  selector: 'app-attendee-list',
  imports: [NgIf, NgFor, DatePipe, FormsModule],
  templateUrl: './attendee-list.html',
  styleUrl: './attendee-list.scss'
})
export class AttendeeList implements OnInit{
  attendees = signal<Attendee[]>([]);
  loading = signal(true);
  error = signal<string | null>(null);
  q = signal<string>('');

  constructor(private svc: Attendees) {}

  ngOnInit(): void {
    this.svc.getAttendees().subscribe({
      next: data => { this.attendees.set(data); this.loading.set(false); },
      error: err => { this.error.set(err.message); this.loading.set(false); }
    });
  }

  filtered = computed(() => {
    const s = this.q().toLowerCase().trim();
    if (!s) return this.attendees();
    return this.attendees().filter(a => a.name.toLowerCase().includes(s) || a.email.toLowerCase().includes(s));
  });


}
