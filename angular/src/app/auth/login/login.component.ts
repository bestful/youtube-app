import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/model';

import {AuthService} from '../auth.service';
import { ApiService } from 'src/app/service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  constructor(private auth: AuthService, private api: ApiService) { }

  user: User;

  ngOnInit() {
    this.user = new User();
    
  }

  onLogin(){
    this.auth.authorize(this.user);
  }

}
