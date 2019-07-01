import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { User, Video } from '../model'
import { ApiService } from '../service'
import { Observable } from 'rxjs';
import { ToastrService } from 'ngx-toastr';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  status: boolean;
  hashkey: string;
  user: User;

  constructor(private api: ApiService, private toastr: ToastrService) {
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
      next => console.log(next),
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
