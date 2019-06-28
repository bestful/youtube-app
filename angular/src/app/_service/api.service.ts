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
      return this.http.post(this.root + object + '/' + id, body);
    } else {
      const body = param1;
      if (typeof param2 !== 'undefined') {
        throw Error('ApiService:get type mismatch');
      }
      return this.http.post(this.root + object, body);
    }
  }

}
