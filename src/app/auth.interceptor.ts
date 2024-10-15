import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpInterceptor, HttpEvent } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CreateUserService } from './Service/User/create-user.service';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {
    constructor(private createUserService: CreateUserService) { }
  
    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
      const authToken = this.createUserService.getToken()  
      const authReq = req.clone({
        setHeaders: {
          Authorization: authToken
        }
      });
      return next.handle(authReq);
    }
  }
