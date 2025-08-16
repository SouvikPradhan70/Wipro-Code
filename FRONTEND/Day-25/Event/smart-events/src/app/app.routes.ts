import { Routes } from '@angular/router';

export const routes: Routes = [
    { path: '', pathMatch: 'full', redirectTo: 'events' },
  {
    path: 'events',
    loadComponent: () => import('./events/event-list/event-list')
      .then(m => m.EventList)
  },
  {
    path: 'events/create',
    loadComponent: () => import('./events/event-create/event-create')
      .then(m => m.EventCreate)
  },
  {
    path: 'events/:id',
    loadComponent: () => import('./events/event-detail/event-detail')
      .then(m => m.EventDetail)
  },
  {
    path: 'attendees',
    loadComponent: () => import('./attendees/attendee-list/attendee-list')
      .then(m => m.AttendeeList)
  },
  {
    path: 'attendees/:id',
    loadComponent: () => import('./attendees/attendee-detail/attendee-detail')
      .then(m => m.AttendeeDetail)
  },
  { path: '**', redirectTo: 'events' }
];
