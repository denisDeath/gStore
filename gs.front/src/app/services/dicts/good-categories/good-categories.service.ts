import { Injectable } from '@angular/core';
import {environment} from '../../../../environments/environment';
import {catchError} from 'rxjs/operators';
import {Observable} from 'rxjs/Observable';
import {AuthService} from '../../auth/auth.service';
import {HttpClient} from '@angular/common/http';
import {GetEntitiesResponse} from '../../../models/dicts/good-categories/get-entities-response';
import {AddEntityResponse} from '../../../models/dicts/good-categories/add-entity-response';
import {AddEntityRequest} from '../../../models/dicts/good-categories/add-entity-request';
import {RemoveEntitiesRequest} from '../../../models/dicts/good-categories/remove-entities-request';
import {GetEntityDetailsRequest} from '../../../models/dicts/good-categories/get-entity-details-request';
import {GetEntityDetailsResponse} from '../../../models/dicts/good-categories/get-entity-details-response';
import {SaveEntityDetailsRequest} from '../../../models/dicts/good-categories/save-entity-details-request';

@Injectable()
export class GoodCategoriesService {
  private getAllUrl = environment.apiServerAddress + '/api/resellers/goodCategories/list/getAll';
  private addUrl = environment.apiServerAddress + '/api/resellers/goodCategories/list/add';
  private removeUrl = environment.apiServerAddress + '/api/resellers/goodCategories/list/remove';
  private getDetailsUrl = environment.apiServerAddress + '/api/resellers/goodCategories/list/getDetails';
  private saveDetailsUrl = environment.apiServerAddress + '/api/resellers/goodCategories/list/save';

  constructor(private http: HttpClient,
              private authService: AuthService) { }

  public GetAll(): Observable<GetEntitiesResponse> {
    return this.http.post<GetEntitiesResponse>(this.getAllUrl, {}).pipe(
      catchError(this.authService.handleError<GetEntitiesResponse>('GetAllCategories'))
    );
  }

 public Add(request: AddEntityRequest): Observable<AddEntityResponse> {
    return this.http.post<AddEntityResponse>(this.addUrl, request).pipe(
      catchError(this.authService.handleError<AddEntityResponse>('AddCategory'))
    );
  }

  public Remove(request: RemoveEntitiesRequest): Observable<any> {
    return this.http.post<RemoveEntitiesRequest>(this.removeUrl, request).pipe(
      catchError(this.authService.handleError<RemoveEntitiesRequest>('RemoveGoodCategories'))
    );
  }

  public GetDetails(request: GetEntityDetailsRequest): Observable<GetEntityDetailsResponse> {
    return this.http.post<GetEntityDetailsResponse>(this.getDetailsUrl, request).pipe(
      catchError(this.authService.handleError<GetEntityDetailsResponse>('GetGoodCategoryDetails'))
    );
  }

  public Save(request: SaveEntityDetailsRequest): Observable<any> {
    return this.http.post(this.saveDetailsUrl, request).pipe(
      catchError(this.authService.handleError<any>('SaveGoodCategoryDetails'))
    );
  }
}
