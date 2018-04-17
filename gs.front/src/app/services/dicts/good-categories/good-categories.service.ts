import { Injectable } from '@angular/core';
import {AuthService} from '../../auth/auth.service';
import {HttpClient} from '@angular/common/http';
import {CrudService} from '../../common/crud-service';
import {GoodCategory} from '../../../models/dicts/good-categories/good-category';
import {environment} from '../../../../environments/environment';

@Injectable()
export class GoodCategoriesService extends CrudService<GoodCategory> {
  protected getAllUrl() {
    return environment.apiServerAddress + '/api/resellers/goodCategories/list/getAll';
  }
  protected addUrl() {
    return environment.apiServerAddress + '/api/resellers/goodCategories/list/add';
  }
  protected removeUrl() {
    return environment.apiServerAddress + '/api/resellers/goodCategories/list/remove';
  }
  protected getDetailsUrl() {
    return environment.apiServerAddress + '/api/resellers/goodCategories/list/getDetails';
  }
  protected saveDetailsUrl() {
    return environment.apiServerAddress + '/api/resellers/goodCategories/list/save';
  }

  protected typeName() {
    return 'GoodCategory';
  }

  constructor(protected http: HttpClient,
              protected authService: AuthService) {
    super(http, authService);
  }
}
