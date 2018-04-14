import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {RegisterComponent} from './components/common/register/register.component';
import {MainComponent} from './components/common/main/main.component';
import {LoginComponent} from './components/common/login/login.component';
import {SettingsComponent} from './components/common/settings/settings.component';
import {GoodsComponent} from './components/dicts/goods/list/goods.component';
import {StoresComponent} from './components/dicts/stores/list/stores.component';
import {GoodsIncomingListComponent} from './components/docs/store/goods-incoming-list/goods-incoming-list.component';
import {GoodCategoriesComponent} from './components/dicts/good-categories/list/good-categories.component';

const routes: Routes = [
  { path: '', redirectTo: 'main', pathMatch: 'full' },
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'main', component: MainComponent },
  { path: 'settings', component: SettingsComponent },
  { path: 'dicts/goods', component: GoodsComponent },
  { path: 'dicts/goodCategories', component: GoodCategoriesComponent },
  { path: 'dicts/stores', component: StoresComponent },
  { path: 'docs/store/goodsIncomingList', component: GoodsIncomingListComponent }
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes)
  ],
  exports: [ RouterModule ],
  declarations: []
})
export class AppRoutingModule { }
