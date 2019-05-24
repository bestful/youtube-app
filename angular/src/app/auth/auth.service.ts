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

  root = 'http://localhost:59003/api/user/';
  
  constructor(private http: HttpClient) { 
    this.http = http;
   }

   login(u: User){
    
   }

   register(u: User){
    this.http.post(this.root, u);
   }


}
