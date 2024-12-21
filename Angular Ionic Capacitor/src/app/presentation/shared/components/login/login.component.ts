import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent {
  isLoginMode = true; // True for login, false for register
  loginForm: FormGroup;
  registerForm: FormGroup;

  constructor(private fb: FormBuilder) {
    this.loginForm = this.fb.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required]],
    });

    this.registerForm = this.fb.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required]],
    });
  }

  onLogin() {
    if (this.loginForm.valid) {
      console.log('Login data:', this.loginForm.value);
    }
  }

  onRegister() {
    if (this.registerForm.valid) {
      console.log('Register data:', this.registerForm.value);
    }
  }

  toggleMode() {
    this.isLoginMode = !this.isLoginMode; // Switch between login and register
  }
}
