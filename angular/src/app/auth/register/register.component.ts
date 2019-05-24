import { Component, OnInit, Input } from '@angular/core';
import { User } from 'src/app/model';
import { NgForm, NgModel } from '@angular/forms';
import {AuthService} from '../auth.service'

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  @Input()
  user: User;

  constructor(private auth: AuthService) { }

  ngOnInit() {
    this.user = new User();
  }

  onRegister(){
    this.auth.register(User);
  }

}
