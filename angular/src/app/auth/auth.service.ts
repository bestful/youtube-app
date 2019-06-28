import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {User, Video} from '../model'
import {ApiService} from '../service'

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  status: boolean;
  hashkey: string;
  user: User;

  root = 'http://localhost:44347/api/user/';

  constructor(private api: ApiService) {
   }

   login(u: User) {

   }

   register(user: User) {
    return this.api.post('user', user);
   }


}
