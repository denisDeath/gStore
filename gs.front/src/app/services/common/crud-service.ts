import {HttpClient} from '@angular/common/http';
import {AuthService} from '../auth/auth.service';
import {AddEntityRequest} from '../../models/common/add-entity-request';
import {GetEntitiesResponse} from '../../models/common/get-entities-response';
import {Observable} from 'rxjs/Observable';
import {GetEntityDetailsResponse} from '../../models/common/get-entity-details-response';
import {SaveEntityDetailsRequest} from '../../models/common/save-entity-details-request';
import {AddEntityResponse} from '../../models/common/add-entity-response';
import {catchError} from 'rxjs/operators';
import {GetEntityDetailsRequest} from '../../models/common/get-entity-details-request';
import {RemoveEntitiesRequest} from '../../models/common/remove-entities-request';

export abstract class CrudService<T> {
  protected abstract getAllUrl(): string;
  protected abstract addUrl(): string;
  protected abstract removeUrl(): string;
  protected abstract getDetailsUrl(): string;
  protected abstract saveDetailsUrl(): string;

  protected abstract typeName(): string;

  constructor(protected http: HttpClient,
              protected authService: AuthService) { }

  public getAll(): Observable<GetEntitiesResponse<T>> {
    return this.http.post<GetEntitiesResponse<T>>(this.getAllUrl(), {}).pipe(
      catchError(this.authService.handleError<GetEntitiesResponse<T>>(`GetAll ${this.typeName()}`))
    );
  }

  public add(request: AddEntityRequest<T>): Observable<AddEntityResponse> {
    return this.http.post<AddEntityResponse>(this.addUrl(), request).pipe(
      catchError(this.authService.handleError<AddEntityResponse>(`AddEntity ${this.typeName()}`))
    );
  }

  public remove(request: RemoveEntitiesRequest): Observable<any> {
    return this.http.post<RemoveEntitiesRequest>(this.removeUrl(), request).pipe(
      catchError(this.authService.handleError<RemoveEntitiesRequest>(`RemoveEntities ${this.typeName()}`))
    );
  }

  public getDetails(request: GetEntityDetailsRequest): Observable<GetEntityDetailsResponse<T>> {
    return this.http.post<GetEntityDetailsResponse<T>>(this.getDetailsUrl(), request).pipe(
      catchError(this.authService.handleError<GetEntityDetailsResponse<T>>(`GetDetails ${this.typeName()}`))
    );
  }

  public save(request: SaveEntityDetailsRequest<T>): Observable<any> {
    return this.http.post(this.saveDetailsUrl(), request).pipe(
      catchError(this.authService.handleError<any>(`SaveDetails ${this.typeName()}`))
    );
  }
}
