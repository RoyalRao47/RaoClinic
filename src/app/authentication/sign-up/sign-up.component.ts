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
import { AppComponent } from '../../app.component';
import { CreateUserService } from '../../Service/User/create-user.service';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Component({
  selector: 'app-sign-up',
  standalone: true,
  imports: [AppComponent, ReactiveFormsModule, CommonModule, NgClass],
  templateUrl: './sign-up.component.html',
  styleUrl: './sign-up.component.css',
  providers: [CreateUserService],
})
export class SignUpComponent implements OnInit {
  registerForm!: FormGroup;
  userSubmitted: boolean = false;
  userDataRespo: any;
  userDataList: any;
  userModel: any = {};
  querySuccess: boolean = false;
  errorMessage: string = '';
  successMessage: string = '';
  constructor(
    private fb: FormBuilder,
    private router: Router,
    private createUserService: CreateUserService
  ) {}

  ngOnInit() {
    this.registerForm = this.fb.group(
      {
        usertype: [null, [Validators.required]],
        name: [
          null,
          [Validators.required, Validators.min(1), Validators.max(15)],
        ],
        email: [null, [Validators.required, Validators.email]],
        mobile: [
          null,
          [
            Validators.required,
            Validators.pattern('^((\\+91-?)|0)?[0-9]{10}$'),
            Validators.minLength(10),
            Validators.maxLength(10),
          ],
        ],
        password: [
          '',
          [Validators.required, Validators.min(6), Validators.max(15)],
        ],
        confirmpassword: [
          '',
          [Validators.required, Validators.min(6), Validators.max(15)],
        ],
      },
      {
        validator: this.passwordMatchValidator,
      }
    );
  }

  get f(): { [key: string]: AbstractControl } {
    return this.registerForm.controls;
  }

  onLogin(): void {
    this.router.navigate(['']);
  }

  onSubmit(): void {
    debugger;
    console.log(JSON.stringify(this.registerForm.value));
    this.userSubmitted = true;
    if (this.registerForm.invalid) {
      console.log('invalid');
      return;
    }
   

    this.userModel.UserID = 0;
    this.userModel.name = this.registerForm.value.name;
    this.userModel.email = this.registerForm.value.email;
    this.userModel.password = this.registerForm.value.password;
    this.userModel.mobileNo = this.registerForm.value.mobile;
    this.userModel.userTypeId = this.registerForm.value.usertype;

    this.createUserService.submitCreateUser(this.userModel).subscribe({
      next: (response) => {
        console.log('Response from API:', response);
        if (response.status === true) {
          this.successMessage = response.message;
          console.log(response.message);
          this.querySuccess = true;
          this.router.navigate(['']);
        } else {
          this.errorMessage = response.message;
        }
      },
      error: (err) => {
        console.error('SubmitBlog Error from API:', err);
        this.errorMessage = err;
      },
    });
    this.userSubmitted = false;
   
  }

  onReset(): void {}

  passwordMatchValidator(control: AbstractControl): ValidationErrors | null {
    const password = control.get('password');
    const confirmPassword = control.get('confirmpassword');
    // Check if both passwords are present
    if (!password || !confirmPassword) {
      return null; // Return null if controls do not exist yet
    }
    if (password.value !== confirmPassword.value) {
      return { passwordsMismatch: true }; // Return error if passwords do not match
    }
    return null; // Return null if passwords match
  }
}
