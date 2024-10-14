import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpInterceptor, HttpEvent } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable()
export class MyInterceptor implements HttpInterceptor {
  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    // Add custom logic (e.g., adding headers) here
    const clonedRequest = req.clone({
      setHeaders: {
        'Authorization': '',
      },
    });
    return next.handle(clonedRequest);
  }
}
