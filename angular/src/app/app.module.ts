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
import {NgCircleProgressModule, CircleProgressOptions} from 'ng-circle-progress';
import {NgxSmartModalModule} from 'ngx-smart-modal';


const circleProgressOptions: CircleProgressOptions = {
  'radius': 60,
  'space': -10,
  'outerStrokeGradient': true,
  'outerStrokeWidth': '13',
  'outerStrokeColor': '#4882c2',
  'outerStrokeGradientStopColor': '#53a9ff',
  'innerStrokeColor': '#e7e8ea',
  'innerStrokeWidth': 10,
  // "title": "UI",
  // "subtitle" : "",
  'titleFontSize': '21',
  'subtitleFontSize': '33',
  'animateTitle': false,
  'animationDuration': '0',
  'showTitle': false,
  'showUnits': false,
  'showBackground': false,
  'clockwise': false,
  'startFromZero': false
} as any;


@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterComponent,
    CredentialComponent,
    FavorComponent,
    WelcomeComponent,
    AutofocusDirective,
  ],
  imports: [
    BrowserModule,
    FormsModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    HttpClientModule,
    ToastrModule.forRoot(),
    NgxSmartModalModule.forRoot(),
    NgCircleProgressModule.forRoot({
      radius: 60,
      space: -10,
      outerStrokeGradient: true,
      outerStrokeWidth: 13,
      outerStrokeColor: '#4882c2',
      outerStrokeGradientStopColor: '#53a9ff',
      innerStrokeColor: '#e7e8ea',
      innerStrokeWidth: 10,
      // "title": "UI",
      // subtitle : 'auto',
      titleFontSize: '21',
      subtitleFontSize: '33',
      animateTitle: false,
      animationDuration: 0,
      showTitle: true,
      showSubtitle: false,
      showUnits: false,
      showBackground: false,
      clockwise: false,
      startFromZero: false
    })
  ],
  providers: [HttpClient, ApiService, ToastrService],
  bootstrap: [AppComponent]
})
export class AppModule { }
