import { Injectable } from '@angular/core';
import { ApiService } from '../service';
import { ToastrService } from 'ngx-toastr';
import { User } from '../model';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  
  constructor(private api : ApiService, private toastr: ToastrService) { }

  // favourites(){
  //   this.api.get('item').subscribe(
  //     next => {
  //       return next;
  //     },
  //     error => this.toastr.error(error.error)
  //   );
  // }

  user: User;
  id: Number;
  authorized: boolean;

  updateAccount(){
    this.api.get('account').subscribe(
      next => {
        this.user = next as any as User;
        this.id = (next as any).id;
        this.authorized = true;
      },
      error => this.authorized = false
    );
  }

  logout(){
    this.api.get('logout').toPromise().then(
      () => this.updateAccount()
    );
  }

  error_lambda: any = error => {
    if (error.status > 0) {
      this.toastr.error(error.error);
    } else {
      this.toastr.error('Connection error!');
    }
  }
}
