import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/model';

import {AuthService} from '../auth.service';
import { ApiService } from 'src/app/service';
import { AccountService } from 'src/app/account/account.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  constructor(private auth: AuthService) { }

  user: User;

  ngOnInit() {
    this.user = new User();
  }

  onLogin(){
    this.auth.authorize(this.user);
  }

}
