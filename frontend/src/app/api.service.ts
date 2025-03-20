import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  private apiUrl = 'http://3.82.162.128:5004/api/hello'; // Make sure this is correct

  constructor(private http: HttpClient) {}

  getHelloMessage(): Observable<string> {
    return this.http.get(this.apiUrl, { responseType: 'text' }); // Ensure responseType is 'text'
  }
}
