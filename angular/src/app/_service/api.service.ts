import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  root = 'https://localhost:5001/api/';
  constructor(private http: HttpClient) {
    this.http = http;
  }

  authorized_id(){
    return this.http.post(this.root + 'authorize', {username: 'string', password: 'string'}, {withCredentials: true, observe: 'response'}).toPromise().then(res =>{
      console.log(res);
    })
  }

  auth(user: any){
    let observable =  this.post('authorize', user);
    observable.subscribe(next => {
      
    })
  }

  // object + body
  // object + id + body
  get(object: string, param1?: any, param2?: any) {
    // Argument Transformation -> ...
    if (typeof param1 === 'number') {
      const id = param1;
      const body = param2;
      return this.http.get(this.root + object + '/' + id, body);
    } else {
      const body = param1;
      if (typeof param2 !== 'undefined') {
        throw Error('ApiService:get type mismatch');
      }
      return this.http.get(this.root + object, body);
    }
  }

  // object + body
  // object + id + body
  post(object: string, param1?: any, param2?: any) {
    // Argument Transformation -> ...
    if (typeof param1 === 'number') {
      const id = param1;
      const body = param2;
      return this.http.post(this.root + object + '/' + id, body, {withCredentials: true});
    } else {
      const body = param1;
      if (typeof param2 !== 'undefined') {
        throw Error('ApiService:get type mismatch');
      }
      return this.http.post(this.root + object, body, {withCredentials: true});
    }
  }

}
