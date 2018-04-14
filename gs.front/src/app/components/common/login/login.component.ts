import { Component, OnInit } from '@angular/core';
import {AuthService} from '../../../services/auth/auth.service';
import {LoginRequest} from '../../../models/login-request';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  UserPhoneNumber: string;
  Password: string;
  isLoading: boolean;

  constructor(private authService: AuthService) { }

  ngOnInit() {
    this.authService.RedirectToMainPage();
    this.isLoading = false;
  }

  Login() {
    this.isLoading = true;
    this.authService.Login(new LoginRequest(this.UserPhoneNumber, this.Password))
      .subscribe(loginResponse => {
        this.authService.RedirectToMainPage();
        this.isLoading = false;
      } );
  }

}
