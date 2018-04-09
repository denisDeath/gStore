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
import {GoodsService} from './services/dicts/goods/goods.service';
import { GoodEditComponent } from './dicts/good-edit/good-edit.component';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { TokenInterceptor } from './interceptors/token.interceptor';
import { StoresComponent } from './dicts/stores/stores.component';
import { StoreEditComponent } from './dicts/store-edit/store-edit.component';
import {StoresService} from "./services/dicts/stores/stores.service";
import {Store} from "./models/dicts/stores/store";
import { GoodCategoryEditComponent } from './dicts/good-category-edit/good-category-edit.component';
import { GoodCategoriesComponent } from './dicts/good-categories/good-categories.component';
import {GoodCategoriesService} from './services/dicts/good-categories/good-categories.service';

@NgModule({
  declarations: [
    AppComponent,
    RegisterComponent,
    MainComponent,
    LoginComponent,
    SettingsComponent,
    GoodsComponent,
    GoodEditComponent,
    GoodCategoriesComponent,
    GoodCategoryEditComponent,
    StoresComponent,
    StoreEditComponent,
    GoodCategoryEditComponent,
    GoodCategoriesComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    NgbModule.forRoot()
  ],
  providers: [
    AuthService,
    GoodsService,
    GoodCategoriesService,
    StoresService,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: TokenInterceptor,
      multi: true
    }
  ],
  bootstrap: [AppComponent],
  entryComponents: [GoodEditComponent, StoreEditComponent, GoodCategoryEditComponent]
})
export class AppModule { }
