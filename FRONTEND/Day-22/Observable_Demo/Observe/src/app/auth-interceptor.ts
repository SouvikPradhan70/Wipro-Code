import { HttpInterceptorFn } from '@angular/common/http';
import { tap } from 'rxjs';


export const authInterceptor: HttpInterceptorFn = (req, next) => {
  console.log('Outgoing request to:', req.url);

  const authReq = req.clone({
    setHeaders: {
      Authorization: 'Bearer faketoken123'
    }
  });

  return next(authReq).pipe(
    tap({
      next: (event) => console.log('Response received:', event),
      error: (error) => console.error('Error occurred:', error)
    })
  );
};
