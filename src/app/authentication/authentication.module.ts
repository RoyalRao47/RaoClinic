import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { provideHttpClient, withInterceptorsFromDi } from '@angular/common/http';
import { CreateUserService } from '../Service/User/create-user.service';
import { AppComponent } from '../app.component';
import { SignUpComponent } from './sign-up/sign-up.component';




@NgModule({
  declarations: [],
  imports: [
    CommonModule,ReactiveFormsModule, SignUpComponent
  ],
  providers: [
    provideHttpClient(),  // Provide HttpClient using the new approach
    CreateUserService,    // Ensure your service is also provided
  ],

})
export class AuthenticationModule { }
