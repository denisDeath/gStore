import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {Organization} from './models/organization';
import {Observable} from 'rxjs/Observable';
import {catchError, tap} from 'rxjs/operators';
import {of} from 'rxjs/observable/of';
import {RegisterResponse} from './models/register-response';
import {environment} from '../environments/environment';
import {Router} from '@angular/router';
import {LoginResponse} from './models/login-response';
import {LoginRequest} from './models/login-request';

@Injectable()
export class AuthService {

  private registerUrl = environment.apiServerAddress + '/api/resellers/registration/RegisterOrganization';
  private loginUrl = environment.apiServerAddress + '/api/auth/Token';

  private loginRoute = '/login';
  private mainRoute = '/main';

  constructor(private http: HttpClient,
              private router: Router) { }

  Register(organization: Organization): Observable<RegisterResponse> {
    const httpOptions = {
      headers: this.getHttpHeaders()
    };
    return this.http.post<RegisterResponse>(this.registerUrl, organization, httpOptions).pipe(
      tap(regResponse => console.log(regResponse)),
      tap(regResponse => this.setAuthSessionKey(regResponse.token)),
      catchError(this.handleError<RegisterResponse>('Register'))
    );
  }

  Login(request: LoginRequest): Observable<LoginResponse> {
    const httpOptions = {
      headers: this.getHttpHeaders()
    };
    return this.http.post<LoginResponse>(this.loginUrl, request, httpOptions).pipe(
      tap(loginResponse => console.log(loginResponse)),
      tap(loginResponse => this.setAuthSessionKey(loginResponse.token)),
      catchError(this.handleError<LoginResponse>('Login'))
    );
  }

  Logout() {
    this.clearAuthKey();
    this.RedirectToLoginPage();
  }

  RedirectToLoginPage() {
    console.log('RedirectToLoginPage');
    if (!this.IsAuthenticated()) {
      console.log('going to RedirectToLoginPage');
      this.router.navigate([this.loginRoute]);
    }
  }

  RedirectToMainPage() {
    console.log('RedirectToMainPage');
    if (this.IsAuthenticated()) {
      this.router.navigate([this.mainRoute]);
    }
  }

  private IsAuthenticated(): boolean {
    console.log('IsAuthenticated');
    const sessionToken = sessionStorage.getItem('token');
    console.log(sessionToken !== null && sessionToken !== undefined);
    return sessionToken !== null && sessionToken !== undefined;
  }

  private setAuthSessionKey(value: string) {
    sessionStorage.setItem('token', value);
  }

  private clearAuthKey() {
    sessionStorage.removeItem('token');
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
