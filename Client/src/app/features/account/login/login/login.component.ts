import { Component, OnInit } from '@angular/core';
import { RandomnumberService } from '../../../../services/randomnumber.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  constructor(private serv : RandomnumberService){}
  ngOnInit(): void {
    this.getRandomNumber();
  }
  loginData = {
    email: '',
    password: ''
  };
  randomNumber : number | undefined;

  login() {
    console.log(this.loginData);
  }

  getRandomNumber() {
    this.serv.getRandomNumber().subscribe(data => {
      this.randomNumber = data;
    })
  }
}