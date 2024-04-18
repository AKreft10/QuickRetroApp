import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../../services/authservice.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.scss'
})
export class NavbarComponent {
  isLoggedIn$: Observable<boolean> = this.authService.isLoggedIn();

 constructor(private authService : AuthService){}

  logout(): void {
    this.authService.logout();
  }
}
