import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {CUSTOM_ELEMENTS_SCHEMA} from '@angular/core'
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import {MatButtonModule} from '@angular/material/button';
import {MatInputModule} from '@angular/material/input';
import {MatCardModule} from '@angular/material/card';
import {MatDividerModule} from '@angular/material/divider';
import { MatFormFieldModule } from '@angular/material/form-field';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HomeComponent } from './features/home/home.component';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import {MatToolbarModule} from '@angular/material/toolbar'
import { JwtInterceptor } from './core/interceptors/JwtInterceptor';
import { DashboardComponent } from './features/dashboard/dashboard.component';
import { NavbarComponent } from './features/shared/navbar/navbar.component';
import { MatDialogModule } from '@angular/material/dialog';
import { AuthService } from './services/authservice.service';
import { LoginDialogComponent } from './core/dialogs/login-dialog/login-dialog.component';
import { RegisterDialogComponent } from './core/dialogs/register-dialog/register-dialog.component';
import {MatGridListModule} from '@angular/material/grid-list';
import { MatIconModule } from '@angular/material/icon';
import { RetrospectiveTemplateComponent } from './features/retrospective-template/retrospective-template.component';
import { DragDropModule } from '@angular/cdk/drag-drop';
import { CardContentDialogComponent } from './features/retrospective-template/dialogs/card-content-dialog/card-content-dialog.component';
import { EditCardDialogComponent } from './features/retrospective-template/dialogs/edit-dialog/edit-dialog.component';
import { SettingsBarComponent } from './features/retrospective-template/settings-bar/settings-bar.component';
import { SetColumnsDialogComponent } from './features/retrospective-template/dialogs/set-columns-dialog/set-columns-dialog.component';
import { MatSliderModule } from '@angular/material/slider';
import { SetBackgroundDialogComponent } from './features/retrospective-template/dialogs/set-background-dialog/set-background-dialog.component';
import { ImageListItemComponent } from './features/shared/image-list-item/image-list-item.component';
import { RetrospectiveBoardComponent } from './features/retrospective-board/retrospective-board.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    DashboardComponent,
    NavbarComponent,
    LoginDialogComponent,
    RegisterDialogComponent,
    RetrospectiveTemplateComponent,
    CardContentDialogComponent,
    EditCardDialogComponent,
    SettingsBarComponent,
    SetColumnsDialogComponent,
    SetBackgroundDialogComponent,
    ImageListItemComponent,
    RetrospectiveBoardComponent
  ],
  imports: [
    HttpClientModule,
    FormsModule,
    BrowserModule,
    AppRoutingModule,
    MatInputModule,
    MatButtonModule,
    MatCardModule,
    MatFormFieldModule,
    ReactiveFormsModule,
    MatToolbarModule,
    MatDividerModule,
    MatDialogModule,
    MatGridListModule,
    MatIconModule,
    DragDropModule,
    MatSliderModule
  ],
  providers: [
    provideAnimationsAsync(),
    {provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true}
  ],
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
  bootstrap: [AppComponent]
})
export class AppModule { }
