import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { RegisterUser } from '../interfaces/register.interface';
import { Router } from '@angular/router';
import { BASE_API_URL } from '../../common/constants';
import { BehaviorSubject } from 'rxjs';
import { environment } from '../../environments/environment';
import { MatDialogRef } from '@angular/material/dialog';
import { LoginDialogComponent } from '../core/dialogs/login-dialog/login-dialog.component';
import { LoginUser } from '../interfaces/login';
import { RegisterDialogComponent } from '../core/dialogs/register-dialog/register-dialog.component';
import { NotificationService } from './notification.service';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http: HttpClient, private router: Router, private notificationService : NotificationService) { }

  private loggedIn = new BehaviorSubject<boolean>(this.hasToken());

  private hasToken(): boolean {
    return !!localStorage.getItem('jwt');
  }

  isLoggedIn() {
    return this.loggedIn.asObservable();
  }

  sendRegisterForm(userData: RegisterUser, dialog: MatDialogRef<RegisterDialogComponent>){
    return this.http.post(`${environment.apiUrl}/Users/Register`, userData).subscribe((response: any) => {
      if(response.success) {
        dialog.close();
      }

      this.notificationService.show(response.message);
    });
  }

  sendLoginForm(userData: LoginUser, dialog: MatDialogRef<LoginDialogComponent>){
    this.http.post(`${environment.apiUrl}/Users/Login`, userData)
    .subscribe((response: any) => {
      if(response.success) {

        var expires = new Date()
        var sessionObject = {
          expiresAt: expires.setHours(expires.getHours()+12),
          token: response.content
        };

        sessionStorage.setItem('jwt', JSON.stringify(sessionObject))
        this.router.navigate(['/dashboard']);
        this.loggedIn.next(true);
        dialog.close();
      }

      this.notificationService.show(response.message);
    });
  }

  logout(): void {
    sessionStorage.removeItem('jwt');
    this.loggedIn.next(false);
    this.router.navigate(['/home']);
    this.notificationService.show("You are logged out. See you soon (:")
  }
}
