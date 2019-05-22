import { Injectable } from '@angular/core';
import { HttpClient } from 'selenium-webdriver/http';
import {User, Video} from '../model'
import {ApiService} from '../service'

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  status: boolean;
  hashkey: string;
  user: User;
  
  constructor(private api: ApiService) { 
    
   }

   login(u: User){
    
   }


}
