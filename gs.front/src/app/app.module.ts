import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {NgbModule} from '@ng-bootstrap/ng-bootstrap';

import { AppComponent } from './app.component';
import { RegisterComponent } from './register/register.component';
import { AppRoutingModule } from './app-routing.module';
import { MainComponent } from './main/main.component';
import {HttpClientModule} from '@angular/common/http';
import {FormsModule} from '@angular/forms';
import {AuthService} from './services/auth/auth.service';
import { LoginComponent } from './login/login.component';
import { SettingsComponent } from './settings/settings.component';
import { GoodsComponent } from './dicts/goods/goods.component';
import {GoodsService} from "./services/goods/goods.service";
import { GoodEditComponent } from './dicts/good-edit/good-edit.component';

@NgModule({
  declarations: [
    AppComponent,
    RegisterComponent,
    MainComponent,
    LoginComponent,
    SettingsComponent,
    GoodsComponent,
    GoodEditComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    NgbModule.forRoot()
  ],
  providers: [AuthService, GoodsService],
  bootstrap: [AppComponent],
  entryComponents: [GoodEditComponent]
})
export class AppModule { }
