import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {User, Video} from '../model'
import {ApiService} from '../service'
import { Observable } from 'rxjs';
import { ToastrService } from 'ngx-toastr';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  status: boolean;
  hashkey: string;
  user: User;

  constructor(private api: ApiService, private toastr : ToastrService) {
   }

   authorize(user: User) {
    return this.api.post("authorize", user).subscribe(
      next => 1,
      error => this.toastr.error(error.error)
    )
   }

   register(user: User) {
    return this.api.post('register', user).subscribe(
        next => this.toastr.success("User with name " + user.username + " successfully registered"),
        error => this.toastr.error(error.error)
      );
   }


}
