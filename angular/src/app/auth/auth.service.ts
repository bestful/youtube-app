import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { User, Video } from '../model'
import { ApiService } from '../service'
import { Observable } from 'rxjs';
import { ToastrService } from 'ngx-toastr';
import { AccountService } from '../account/account.service';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  status: boolean;
  hashkey: string;
  user: User;

  constructor(private api: ApiService, private account: AccountService, private toastr: ToastrService, private router: Router) {
  }

  error_lambda: any = error => {
    if (error.status > 0) {
      this.toastr.error(error.error);
    } else {
      this.toastr.error('Connection error!');
    }
  }

  authorize(user: User) {
    return this.api.post("authorize", user).subscribe(
      next => {
        this.account.updateAccount();
        this.router.navigateByUrl('favor');
      },
      this.error_lambda
    );
  }

  register(user: User) {
    return this.api.post('register', user).subscribe(
      next => this.toastr.success("User with name " + user.username + " successfully registered"),
      this.error_lambda
    );
  }


}
