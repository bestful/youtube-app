import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';

import {LoginComponent} from './auth/login/login.component';
import {RegisterComponent} from './auth/register/register.component';
import {CredentionalComponent} from './account/credentional/credentional.component';
import {FavorComponent} from './account/favor/favor.component';
import {WelcomeComponent} from './welcome/welcome.component';
import {AppComponent} from './app.component'

import {HttpClientModule, HttpClient} from '@angular/common/http';
import { ApiService } from './service';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterComponent,
    CredentionalComponent,
    FavorComponent,
    WelcomeComponent, 
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [HttpClient, ApiService],
  bootstrap: [AppComponent]
})
export class AppModule { }
