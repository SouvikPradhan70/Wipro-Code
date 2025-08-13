import { bootstrapApplication } from '@angular/platform-browser';
import { appConfig } from './app/app.config';
import { App } from './app/app';
import { provideHttpClient,withInterceptors } from '@angular/common/http';
import { provideRouter } from '@angular/router';
import { routes } from './app/app.routes'; 
import { authInterceptor } from './app/auth-interceptor';
bootstrapApplication(App,{
  providers:[
    provideHttpClient(
      withInterceptors([authInterceptor])
    ),
    provideRouter(routes)


  ]
});
