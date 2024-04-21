import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './features/home/home.component';
import { DashboardComponent } from './features/dashboard/dashboard.component';
import { RetrospectiveBoardComponent } from './features/retrospective-board/retrospective-board.component';

const routes: Routes = [
  {path: '', redirectTo: '/home', pathMatch:'full'},
  {path: 'home', component: HomeComponent},
  {path: 'dashboard', component: DashboardComponent},
  {path: 'createNewRetro', component: RetrospectiveBoardComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
