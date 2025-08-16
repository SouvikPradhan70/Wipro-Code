import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, catchError, throwError } from 'rxjs';

export interface EventItem {
  id?: string | number;  // 🔑 can be string or number
  title: string;
  date: string; // ISO yyyy-mm-dd
  location: string;
  price: number;
  capacity: number;
  attendeesCount: number;
  description: string;
}

@Injectable({
  providedIn: 'root'
})
export class Events {
  private http = inject(HttpClient);
  private base = "http://localhost:3000/events";

  getEvents(): Observable<EventItem[]> {
    return this.http.get<EventItem[]>(this.base).pipe(
      catchError(() => throwError(() => new Error('Failed to load events')))
    );
  }

  getEvent(id: string | number): Observable<EventItem> {
    return this.http.get<EventItem>(`${this.base}/${id}`).pipe(
      catchError(() => throwError(() => new Error('Event not found')))
    );
  }

  createEvent(evt: EventItem): Observable<EventItem> {
    return this.http.post<EventItem>(this.base, evt).pipe(
      catchError(() => throwError(() => new Error('Failed to create event')))
    );
  }

  incrementAttendees(id: string | number, current: number) {
    return this.http.patch<EventItem>(`${this.base}/${id}`, { attendeesCount: current + 1 }).pipe(
      catchError(() => throwError(() => new Error('Failed to register')))
    );
  }
}
