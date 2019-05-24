import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  root = 'http://localhost:59003/api/';
  constructor(private http: HttpClient) {
    this.http = http;
   }

  getVideoUrl(){
    return this.root + 'users/';
  }

  // object + body
  // object + id + body
  get(object: string, param1 ?: any, param2 ?: any){
    // Object Transformation 

    if(typeof param1 === 'number'){
      let id = param1;
      let body = param2;
      return this.http.get(this.root + object + '/' + id, body);
    }
    else{
      let body = param1;
      if(typeof param2 !== 'undefined') {
        throw Error('ApiService:get type mismatch');
      }
      return this.http.get(this.root + object, body);
    } 
  }

}
