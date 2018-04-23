import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {NgbModule} from '@ng-bootstrap/ng-bootstrap';

import { AppComponent } from './app.component';
import { RegisterComponent } from './components/common/register/register.component';
import { AppRoutingModule } from './app-routing.module';
import { MainComponent } from './components/common/main/main.component';
import {HttpClientModule} from '@angular/common/http';
import {FormsModule} from '@angular/forms';
import {AuthService} from './services/auth/auth.service';
import { LoginComponent } from './components/common/login/login.component';
import { SettingsComponent } from './components/common/settings/settings.component';
import { GoodsComponent } from './components/dicts/goods/list/goods.component';
import {GoodsService} from './services/dicts/goods/goods.service';
import { GoodEditComponent } from './components/dicts/goods/good-edit/good-edit.component';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { TokenInterceptor } from './interceptors/token.interceptor';
import { StoresComponent } from './components/dicts/stores/list/stores.component';
import { StoreEditComponent } from './components/dicts/stores/store-edit/store-edit.component';
import {StoresService} from './services/dicts/stores/stores.service';
import { GoodCategoryEditComponent } from './components/dicts/good-categories/good-category-edit/good-category-edit.component';
import { GoodCategoriesComponent } from './components/dicts/good-categories/list/good-categories.component';
import {GoodCategoriesService} from './services/dicts/good-categories/good-categories.service';
import {SettingsService} from './services/settings/settings.service';
import { GoodsIncomingListComponent } from './components/docs/store/goods-incoming-list/goods-incoming-list.component';
import {GoodsIncomingService} from './services/docs/store/goodsIncoming/goods-incoming.service';
import { DictPanelComponent } from './components/common/dict-panel/dict-panel.component';
import {SpecificationsListComponent} from "./components/dicts/specifications/list/specifications-list.component";
import {SpecificationsService} from "./services/dicts/specifications/specifications.service";

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
    SettingsComponent,
    GoodsIncomingListComponent,
    SpecificationsListComponent,
    DictPanelComponent
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
    SpecificationsService,
    GoodCategoriesService,
    StoresService,
    SettingsService,
    GoodsIncomingService,
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
