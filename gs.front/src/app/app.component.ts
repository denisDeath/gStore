import { Component } from '@angular/core';
import {AuthService} from './services/auth/auth.service';
import {Router} from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {

  title = 'gStore';

  constructor (private authService: AuthService,
               private router: Router) {

  }

  IsAuthenticated(): boolean {
    return this.authService.IsAuthenticated();
  }

  Logout() {
    this.authService.Logout();
  }

  GetIsActiveClass(route: string): string {
    return route === this.router.url ? 'active' : '';
  }
}
