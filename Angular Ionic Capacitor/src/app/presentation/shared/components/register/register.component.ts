import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { UseraccountsService } from 'src/app/infrastructure/services/proxies/internal/useraccounts.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss'],
})
export class RegisterComponent {
  registerForm: FormGroup;

  constructor(
    private formBuilder: FormBuilder,
    private useraccountsService: UseraccountsService,
    private router: Router
  ) {
    this.registerForm = this.formBuilder.group({
      name: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      password: ['', Validators.required],
    });
  }

  onRegister() {
    if (this.registerForm.valid) {
      const { name, email, password } = this.registerForm.value;
      this.useraccountsService
        .register({
          fullName: name,
          email: email,
          passwordHash: password,
        })
        .subscribe({
          next: (response) => {
            console.log('Registration successful', response);
            // Handle successful registration (e.g., navigate to login page)
          },
          error: (error) => {
            console.error('Registration failed', error);
            // Handle registration error (e.g., show error message)
          },
          complete: () => {
            console.log('Registration process completed');
            this.router.navigate(['/login']);
          },
        });
      // Voeg hier je registratie-logica toe (API-aanroep, etc.)
    }
  }
}
