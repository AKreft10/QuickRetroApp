import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { RegisterUser } from '../features/account/register/register.interface';
import { LoginUser } from '../features/account/login/login/login.interface';
import { Router } from '@angular/router';
import { BASE_API_URL } from '../../common/constants';
import { BehaviorSubject } from 'rxjs';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http: HttpClient, private router: Router) { }

  private loggedIn = new BehaviorSubject<boolean>(this.hasToken());

  private hasToken(): boolean {
    return !!localStorage.getItem('jwt');
  }

  isLoggedIn() {
    return this.loggedIn.asObservable();
  }

  sendRegisterForm(userData: RegisterUser){
    return this.http.post(`${environment.apiUrl}/Users/Register`, userData);
  }

  sendLoginForm(userData: LoginUser){
    this.http.post(`${BASE_API_URL}/Users/Login`, userData)
    .subscribe((response: any) => {
      if(response.success) {
        localStorage.setItem('jwt', response.content)
        this.router.navigate(['/dashboard']);
        this.loggedIn.next(true);
      }
    });
  }

  logout(): void {
    localStorage.removeItem('jwt');
    this.loggedIn.next(false);
    this.router.navigate(['/home']);
  }
}
