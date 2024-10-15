import { NgModule, Component, Injectable, OnInit } from '@angular/core';
import {
  ReactiveFormsModule,
  AbstractControl,
  FormBuilder,
  FormGroup,
  FormControl,
  Validators,
  ValidatorFn,
  ValidationErrors,
} from '@angular/forms';
import {
  CommonModule,
  NgClass,
  NgIf,
  NgFor,
  DatePipe,
  DOCUMENT,
  isPlatformBrowser,
  formatDate,
} from '@angular/common';
import { Router, Routes } from '@angular/router';
import { CreateUserService } from '../../Service/User/create-user.service';
import { AppComponent } from '../../app.component';

@Component({
  selector: 'app-log-in',
  standalone: true,
  imports: [AppComponent, ReactiveFormsModule, CommonModule, NgClass],
  templateUrl: './log-in.component.html',
  styleUrl: './log-in.component.css',
})
export class LogInComponent implements OnInit {
  loginForm: FormGroup = new FormGroup({
    email: new FormControl(''),
    password: new FormControl(''),
  });
  userSubmitted: boolean = false;
  loginModel: any = {};
  errorMessage: string = '';
  constructor(
    private fb: FormBuilder,
    private createUserService: CreateUserService,
    private router: Router
  ) {}

  ngOnInit() {
    this.loginForm = this.fb.group({
      email: [null, [Validators.required]],
      password: [null, [Validators.required, Validators.minLength(5)]],
    });
  }

  get f(): { [key: string]: AbstractControl } {
    return this.loginForm.controls;
  }

  onCreateUser() {
    this.router.navigate(['/create-user']);
  }

  onSubmit(): void {
    this.userSubmitted = true;
    if (this.loginForm.invalid) {
      console.log('invalid');
      return;
    }
    this.loginModel.username = this.loginForm.value.email;
    this.loginModel.password = this.loginForm.value.password;
    this.createUserService
      .loginUser(this.loginModel)
      .subscribe((res: { status: any; userType: any; message: string }) => {
        if (res.status) {
          if (res.userType == '1') {
            this.router.navigate(['/doctor-dashboard']);
          } 
          else if(res.userType == '2')
          {
            this.router.navigate(['/patient-dashboard']);
          }
          else {
            this.router.navigate(['/']);
          }
        } else {
          this.errorMessage = res.message;
        }
      });
  }
}
