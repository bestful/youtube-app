import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  root = 'http://localhost:59003/api/'
  constructor(private http: HttpClient) { }

}
