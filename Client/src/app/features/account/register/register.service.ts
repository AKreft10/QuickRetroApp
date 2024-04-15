import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { RegisterUser } from './register.interface';

@Injectable({
  providedIn: 'root'
})
export class RegisterService {

  baseUrl = 'https://localhost:44395/api/Users/Register';

  constructor(private http: HttpClient) { }

  sendRegisterForm(userData: RegisterUser){
    return this.http.post(this.baseUrl, userData);
  }
}
