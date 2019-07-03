import { Component } from '@angular/core';

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
}
