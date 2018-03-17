import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {Organization} from './models/organization';
import {Observable} from 'rxjs/Observable';
import {catchError} from 'rxjs/operators';
import {of} from 'rxjs/observable/of';
import {RegisterResponse} from './models/register-response';

@Injectable()
export class AuthService {

  private registerUrl = 'http://localhost:5000/api/resellers/registration/RegisterOrganization';

  constructor(private http: HttpClient) { }

  Register(organization: Organization): Observable<RegisterResponse> {
    const httpOptions = {
      headers: this.getHttpHeaders()
    };
    return this.http.post<RegisterResponse>(this.registerUrl, organization, httpOptions).pipe(
      catchError(this.handleError<RegisterResponse>('Register'))
    );
  }

  private handleError<T> (operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {

      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead

      // TODO: better job of transforming error for user consumption
      console.log(`${operation} failed: ${error.message}`);

      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }

  private getHttpHeaders(): HttpHeaders {
    const result = new HttpHeaders();
    result.append('Content-Type', 'application/json');
    result.append('Access-Control-Allow-Origin', '*');
    return result;
  }
}
