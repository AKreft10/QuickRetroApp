import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { AuthService } from '../../../services/authservice.service';
import { Router } from '@angular/router';
import { LoginUser } from '../../../interfaces/login';

@Component({
  selector: 'app-login-dialog',
  templateUrl: './login-dialog.component.html',
  styleUrl: './login-dialog.component.scss'
})
export class LoginDialogComponent implements OnInit {
  loginForm!: FormGroup;

  constructor(
    public dialogRef: MatDialogRef<LoginDialogComponent>,
    private authService: AuthService,
    private router : Router
  ) {}

  ngOnInit(): void {
    this.loginForm = new FormGroup({
      email: new FormControl('', [Validators.required, Validators.email]),
      password: new FormControl('', [Validators.required])
    });
  }

  onSubmit(): void {
    if (this.loginForm.valid) {
      var loginFormValue = this.loginForm.value;

      var loginData : LoginUser = {
        email: loginFormValue["email"],
        password: loginFormValue["password"]
      }

      this.authService.sendLoginForm(loginData, this.dialogRef);
    }
  }

  onCancel(): void {
    this.dialogRef.close();
  }
}
