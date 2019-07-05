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
    this.authorized_id();
  }

// tslint:disable-next-line: variable-name
  _authorized_id = -1;

    authorized_id(){
    this.get('account').subscribe(
      next => {
        this._authorized_id = (next as any).id;
        // console.log(this._authorized_id);
      },
      error => {
        this._authorized_id = -1;
      }
    );
  }

  authorized(){
    if (this._authorized_id < 0) {
      return false;
    } else {
      return true;
    }
  }

  auth(user: any){
    const observable =  this.post('authorize', user);
    observable.subscribe(next => {

    });
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

  delete(object: string, id: Number) {
      return this.http.delete(this.root + object + id);
  }

  put(object: string, id: Number, body: any) {
    return this.http.delete(this.root + object + id, body);
  }

}
