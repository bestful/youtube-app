import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';

import {LoginComponent} from './auth/login/login.component';
import {RegisterComponent} from './auth/register/register.component';

// Components
import {CredentialComponent} from './account/credential/credential.component';
import {FavorComponent} from './account/favor/favor.component';
import {WelcomeComponent} from './welcome/welcome.component';
import {AppComponent} from './app.component';

// Angular modules
import {HttpClientModule, HttpClient} from '@angular/common/http';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import { FormsModule } from '@angular/forms';


// 3d-party modules and services
import {ToastrModule} from 'ngx-toastr';
import { ApiService } from './service';
import {ToastrService} from 'ngx-toastr';
import { AutofocusDirective } from './_directive/autofocus.directive';
import {NgCircleProgressModule} from 'ng-circle-progress';




@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterComponent,
    CredentialComponent,
    FavorComponent,
    WelcomeComponent,
    AutofocusDirective
  ],
  imports: [
    BrowserModule,
    FormsModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    HttpClientModule,
    ToastrModule.forRoot(),
    NgCircleProgressModule.forRoot({
      backgroundStrokeWidth: 0,
      radius: 20,
      space: -6,
      maxPercent: 1000,
      unitsFontWeight: "500",
      outerStrokeGradient: true,
      outerStrokeWidth: 10,
      outerStrokeColor: "#4882c2",
      outerStrokeGradientStopColor: "#53a9ff",
      // outerStrokeLinecap: "square",
      innerStrokeColor: "#ff0909",
      innerStrokeWidth: 3,
      title: "UI",
      titleFontSize: "22",
      titleFontWeight: "500",
      // animateTitle: false,
      // animationDuration: 200,
      // showSubtitle: false,
      // showUnits: false,
      // showBackground: false,
      clockwise: false,
      // startFromZero: false
    })
  ],
  providers: [HttpClient, ApiService, ToastrService],
  bootstrap: [AppComponent]
})
export class AppModule { }
