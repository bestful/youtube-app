import { Component } from '@angular/core';
import { ApiService } from './service';
import { AccountService } from './account/account.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'Welcome to my youtube)';

  menus = [
    {
      label: 'Login',
      routerLink: '/login',
      auth: false
    },
    {
      label: 'Register',
      routerLink: '/register',
      auth: false
    },
    {
      label: 'Favourites',
      routerLink: '/favor',
      auth: true
    },
    {
      label: 'Credential',
      routerLink: '/credential',
      auth: true
    }
  ];

  constructor(public account: AccountService, private router: Router){
  }

  ngOnInit(){
    this.account.updateAccount();
  }

  authorized(){
    return this.account.authorized;
  }

  logout(){
    this.account.logout();
    this.router.navigateByUrl('login');
  }
}
