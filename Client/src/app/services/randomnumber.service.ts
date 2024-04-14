import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RandomnumberService {

  constructor(private http: HttpClient) { }

  baseUrl = 'https://localhost:44395/api/RandomNumber/RandomNumber';

  getRandomNumber() : Observable<any> 
  {
    return this.http.get(this.baseUrl);
  }


}
