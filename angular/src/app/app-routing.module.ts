import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { LoginComponent } from './auth/login/login.component';
import { RegisterComponent } from './auth/register/register.component';
import { CredentionalComponent } from './account/credentional/credentional.component';
import { FavorComponent } from './account/favor/favor.component';
import { WelcomeComponent } from './welcome/welcome.component';


const routes: Routes = [
  { path: '', pathMatch: 'full', redirectTo: 'welcome' },
  { path: 'welcome', component: WelcomeComponent,  data: { title: 'My Calendar' }},
  // Authorization
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  // Account
  { path: 'credentional', component: CredentionalComponent },
  { path: 'favor', component: FavorComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
