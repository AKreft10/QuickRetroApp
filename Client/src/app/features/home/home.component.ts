import { Component } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss'
})
export class HomeComponent {
  arleadyHaveAnAccount : boolean = false;

  receiveData(data: boolean) {
    this.arleadyHaveAnAccount = !this.arleadyHaveAnAccount;
  }

  loginMode(){
    this.arleadyHaveAnAccount = true;
  }

  registerMode() {
    this.arleadyHaveAnAccount = false;
  }
}
