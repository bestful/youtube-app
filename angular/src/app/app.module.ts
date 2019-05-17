import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { RouteWelocmeComponent } from './route/wellcome/route-welocme/route-welocme.component';
import { RouteWelcomeComponent } from './route/welcome/route-welcome/route-welcome.component';
import { LoginComponent } from './route/auth/login/login.component';
import { RegisterComponent } from './route/auth/register/register.component';
import { AccountComponent } from './account/account.component';

@NgModule({
  declarations: [
    AppComponent,
    RouteWelocmeComponent,
    RouteWelcomeComponent,
    LoginComponent,
    RegisterComponent,
    AccountComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
