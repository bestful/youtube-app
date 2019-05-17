import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  { path: '', pathMatch: 'full', redirectTo: 'welcome' },
  { path: 'welocme', component:  },
  // Authorization
  { path: 'login', component: NameComponent },
  { path: 'register', component: NameComponent },
  // Account
  { path: 'credentional', component: NameComponent },
  { path: 'favor', component: NameComponent },
]; 

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

