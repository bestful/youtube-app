import { Injectable } from '@angular/core';
import { ApiService } from '../service';
import { ToastrService } from 'ngx-toastr';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  
  constructor(private api : ApiService, private toastr: ToastrService) { }

  favourites(){
    this.api.get('item').subscribe(
      next => {
        return next;
      },
      error => this.toastr.error(error.error)
    );
  }

  account(){
    this.api.get('account').subscribe(
      next => {
        console.log(next);
      }
    );
  }
}
