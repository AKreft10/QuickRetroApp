import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { RandomnumberService } from '../../../../services/randomnumber.service';
import { LoginUser } from './login.interface';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthService } from '../../../../services/authservice.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent  {

  loginForm: FormGroup;
  @Output() dataEmmiter = new EventEmitter<boolean>(false);

  constructor(private authService : AuthService, private fb: FormBuilder){
    this.loginForm = fb.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', Validators.required],
    })
  }


  onSubmit() {
    var loginFormValue = this.loginForm.value;
    var loginData : LoginUser = {
      email: loginFormValue["email"],
      password: loginFormValue["password"]
    }

    this.authService.sendLoginForm(loginData);
  }


  switchForms() {
    this.dataEmmiter.emit(true)
  }
}