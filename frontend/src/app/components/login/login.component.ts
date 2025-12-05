import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  standalone: false,
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss'
})
export class LoginComponent {
  email: string = '';
  password: string = '';
  isLoading: boolean = false;
  rememberMe: boolean = false;
  showPassword: boolean = false;

  constructor(private router: Router) {}

  onSubmit() {
    if (this.email && this.password) {
      this.isLoading = true;
      setTimeout(() => {
        localStorage.setItem('userEmail', this.email);
        this.router.navigate(['/home']);
      }, 1000);
    }
  }

  togglePasswordVisibility() {
    this.showPassword = !this.showPassword;
  }
}
