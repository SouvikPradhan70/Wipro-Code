import { bootstrapApplication } from '@angular/platform-browser';
import { AppComponent } from './app/app';
import { provideRouter } from '@angular/router';
import { routes } from './app/routes'; // adjust path if needed

bootstrapApplication(AppComponent, {
  providers: [provideRouter(routes)]
})
.catch(err => console.error(err));
