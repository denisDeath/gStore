import { Component, OnInit } from '@angular/core';
import {AuthService} from '../services/auth/auth.service';
import {Organization} from '../models/organization';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  Organization: Organization;
  registerErrors: string[];

  constructor(private authService: AuthService) { }

  ngOnInit() {
    this.authService.RedirectToMainPage();
    this.Organization = new Organization();
  }

  Register() {
    this.authService.Register(this.Organization)
      .subscribe(response => this.authService.RedirectToMainPage());
  }
}
