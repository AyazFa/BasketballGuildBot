import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { AuthorizationService } from '../../services/authorization.service';
import { Router, RouterModule } from '@angular/router';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [ReactiveFormsModule, RouterModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss'
})
export class LoginComponent implements OnInit {
  loginForm!: FormGroup

  constructor(
    private router: Router,
    private authorizationService: AuthorizationService) {
  }

  submitLogin() {
    this.authorizationService.login(this.loginForm.value).subscribe({
      next: () => this.router.navigate(['persons']),
      error: (err) => alert(err.message)
    });
  }

  ngOnInit(): void {
    this.loginForm = new FormGroup({
      'email': new FormControl('', [Validators.required, Validators.email]),
      'password': new FormControl('', 
      [
        Validators.required, 
        Validators.pattern(/^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$/)
      ])
    });

    if (this.authorizationService.isLoggedIn()){
      this.router.navigate(['persons'])
    }
  }
}
