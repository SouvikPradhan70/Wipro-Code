import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, catchError, throwError } from 'rxjs';
import { Component, EventEmitter, Output, Input } from '@angular/core';
import { FormsModule, NgForm } from '@angular/forms';
import { NgIf } from '@angular/common';

@Component({
  selector: 'app-attendee-register',
  standalone: true,
  imports: [FormsModule, NgIf],
  styles: [`
    form { display:grid; gap:.5rem; }
    input { padding:.45rem .6rem; border:1px solid #ddd; border-radius:10px; }
    .err { color:#c00; font-size:.85rem; }
  `],
  template: `
    <form #f="ngForm" (ngSubmit)="submit(f)" novalidate>
      <label>Name
        <input name="name" [(ngModel)]="model.name" required>
        <span *ngIf="f.submitted && !model.name" class="err">Required</span>
      </label>

      <label>Email
        <input name="email" [(ngModel)]="model.email" required email>
        <span *ngIf="f.submitted && (!model.email || f.controls['email']?.errors?.['email'])" class="err">
          Valid email required
        </span>
      </label>

      <button type="submit">Register</button>
    </form>
  `
})
export class AttendeeRegisterComponent {
  @Input() eventId!: number | string;   // ✅ accept string | number
  @Output() register = new EventEmitter<{ name: string; email: string }>();

  model = { name: '', email: '' };

  submit(f: NgForm) {
    if (!f.valid) return;
    this.register.emit({ ...this.model });
    f.resetForm();
  }
}

// ✅ Attendee interface
export interface Attendee {
  id?: number;
  name: string;
  email: string;
  eventId: number | string;   // ✅ allow both
  registeredAt: string; // ISO
}

@Injectable({
  providedIn: 'root'
})
export class Attendees {
  private http = inject(HttpClient);
  private base = "http://localhost:3000/attendees";

  getAttendees(): Observable<Attendee[]> {
    return this.http.get<Attendee[]>(this.base).pipe(
      catchError(() => throwError(() => new Error('Failed to load attendees')))
    );
  }

  getAttendee(id: number | string): Observable<Attendee> {   // ✅ allow both
    return this.http.get<Attendee>(`${this.base}/${id}`).pipe(
      catchError(() => throwError(() => new Error('Attendee not found')))
    );
  }

  register(att: Attendee): Observable<Attendee> {
    return this.http.post<Attendee>(this.base, att).pipe(
      catchError(() => throwError(() => new Error('Failed to register attendee')))
    );
  }

  byEvent(eventId: number | string): Observable<Attendee[]> {   // ✅ allow both
    return this.http.get<Attendee[]>(`${this.base}?eventId=${eventId}`).pipe(
      catchError(() => throwError(() => new Error('Failed to load event attendees')))
    );
  }
}
