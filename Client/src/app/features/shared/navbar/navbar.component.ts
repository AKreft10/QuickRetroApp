import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../../services/authservice.service';
import { Observable } from 'rxjs';
import { MatDialog } from '@angular/material/dialog';
import { LoginDialogComponent } from '../../../core/dialogs/login-dialog/login-dialog.component';
import { NoopScrollStrategy } from '@angular/cdk/overlay';
import { RegisterDialogComponent } from '../../../core/dialogs/register-dialog/register-dialog.component';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.scss'
})
export class NavbarComponent {
  isLoggedIn$: Observable<boolean> = this.authService.isLoggedIn();

 constructor(private authService : AuthService, public dialog: MatDialog){}

  logout(): void {
    this.authService.logout();
  }

  openLoginDialog(): void {
    const dialogRef = this.dialog.open(LoginDialogComponent, {
      width: '400px',
      scrollStrategy: new NoopScrollStrategy()
    });
  
    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        console.log('Zalogowano pomyślnie!');
      } else {
        console.log('Dialog zamknięty bez logowania');
      }
    });
  }

  openRegisterDialog(): void {
    const dialogRef = this.dialog.open(RegisterDialogComponent, {
      width: '400px',
      scrollStrategy: new NoopScrollStrategy()
    });
  
    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        console.log('Zarejestrowano pomyślnie!');
      } else {
        console.log('Dialog zamknięty bez rejestracji');
      }
    });
  }
}
