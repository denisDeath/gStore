import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {RegisterComponent} from './register/register.component';
import {MainComponent} from './main/main.component';
import {LoginComponent} from './login/login.component';
import {SettingsComponent} from './settings/settings.component';
import {GoodsComponent} from './dicts/goods/goods.component';
import {StoresComponent} from "./dicts/stores/stores.component";

const routes: Routes = [
  { path: '', redirectTo: 'main', pathMatch: 'full' },
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'main', component: MainComponent },
  { path: 'settings', component: SettingsComponent },
  { path: 'dicts/goods', component: GoodsComponent },
  { path: 'dicts/stores', component: StoresComponent }
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes)
  ],
  exports: [ RouterModule ],
  declarations: []
})
export class AppRoutingModule { }
