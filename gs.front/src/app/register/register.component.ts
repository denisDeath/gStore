import { Component, OnInit } from '@angular/core';
import {AuthService} from '../auth.service';
import {Organization} from '../models/organization';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  Organization: Organization;

  constructor(private authService: AuthService) { }

  ngOnInit() {
    this.Organization = new Organization();
  }

  Register() {
    this.authService.Register(this.Organization)
      .subscribe(response => console.log(response));
  }
}
