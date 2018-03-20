import { Component, OnInit } from '@angular/core';
import {AuthService} from '../auth.service';
import {LoginRequest} from '../models/login-request';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  UserPhoneNumber: string;
  Password: string;

  constructor(private authService: AuthService) { }

  ngOnInit() {
    this.authService.RedirectToMainPage();
  }

  Login() {
    this.authService.Login(new LoginRequest(this.UserPhoneNumber, this.Password))
      .subscribe(loginResponse => this.authService.RedirectToMainPage() );
  }

}
