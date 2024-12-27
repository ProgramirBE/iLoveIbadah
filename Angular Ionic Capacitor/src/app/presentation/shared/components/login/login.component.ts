import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { UserAccountsService } from 'src/app/infrastructure/services/proxies/internal/useraccounts.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent {
  isLoginMode = true; // True for login, false for register
  loginForm: FormGroup;

  constructor(
    private fb: FormBuilder,
    private router: Router,
    private useraccountsService: UserAccountsService
  ) {
    this.loginForm = this.fb.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required]],
    });
  }

  onLogin() {
    if (this.loginForm.valid) {
      const { email, password } = this.loginForm.value;
      this.useraccountsService
        .login({ email: email, passwordHash: password })
        .subscribe({
          next: (response) => {
            console.log('Login successful');
          },
          error: (error) => {
            console.error('Login failed', error);
            // Handle login error (e.g., show error message)
          },
          complete: () => {
            console.log('Login process completed');
            this.router.navigate(['/home']);
          },
        });
    }
  }

  toggleMode() {
    this.isLoginMode = !this.isLoginMode; // Switch between login and register
  }
}
