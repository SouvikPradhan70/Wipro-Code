import { Routes } from '@angular/router';
import { HomeComponent } from './home/home';

export const routes: Routes = [
  { path: '', component: HomeComponent },
  {
    path: 'destinations',
    loadComponent: () =>
      import('./destination/destination')
        .then(m => m.DestinationComponent)
  },
  { path: '**', redirectTo: '' }
];
