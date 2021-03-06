import { Injectable, Inject } from '@angular/core';
import { People } from '../models/people';
import { HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class PeopleService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
  }

  getPeople(): Observable<People[]> {
    return this.http.get<People[]>(this.baseUrl + 'people').pipe(
      catchError((error) => {
        console.log(error);
        return of([]); 
      })
    );
  }
}
