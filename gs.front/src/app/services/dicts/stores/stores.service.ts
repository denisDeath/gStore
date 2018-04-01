import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {AuthService} from "../../auth/auth.service";
import {catchError} from "rxjs/operators";
import {Observable} from "rxjs/Observable";
import {GetStoresResponse} from "../../../models/dicts/stores/get-stores-response";
import {environment} from "../../../../environments/environment";
import {of} from "rxjs/observable/of";
import {Store} from "../../../models/dicts/stores/store";
import {RemoveStoreRequest} from "../../../models/dicts/stores/remove-store-request";
import {GetStoreDetailsRequest} from "../../../models/dicts/stores/get-store-details-request";
import {AddStoreRequest} from "../../../models/dicts/stores/add-store-request";
import {SaveStoreDetailsRequest} from "../../../models/dicts/stores/save-store-details-request";
import {AddGoodResponse} from "../../../models/dicts/goods/add-good-response";
import {AddStoreResponse} from "../../../models/dicts/stores/add-store-response";
import {GetGoodDetailsResponse} from "../../../models/dicts/goods/get-good-details-response";
import {GetStoreDetailsResponse} from "../../../models/dicts/stores/get-store-details-response";

@Injectable()
export class StoresService {

  private getStoresUrl = environment.apiServerAddress + '/api/resellers/stores/get';
  private addStoresUrl = environment.apiServerAddress + '/api/resellers/stores/add';
  private removeUrl = environment.apiServerAddress + '/api/resellers/stores/remove';
  private getDetailsUrl = environment.apiServerAddress + '/api/resellers/stores/getDetails';
  private saveDetailsUrl = environment.apiServerAddress + '/api/resellers/stores/saveDetails';

  constructor(private http: HttpClient,
              private authService: AuthService) { }

  public GetStores(): Observable<GetStoresResponse> {
    return this.http.post<GetStoresResponse>(this.getStoresUrl, {}).pipe(
      catchError(this.authService.handleError<GetStoresResponse>('GetStores'))
    );
  }

  Remove(request: RemoveStoreRequest): Observable<any> {
    return of<any>();
  }

  GetStoreDetails(request: GetStoreDetailsRequest): Observable<GetStoreDetailsResponse> {
    return this.http.post<GetStoreDetailsResponse>(this.getDetailsUrl, request).pipe(
      catchError(this.authService.handleError<GetStoreDetailsResponse>('GetStoreDetails'))
    );
  }

  AddStore(request: AddStoreRequest): Observable<AddStoreResponse> {
    return this.http.post<AddStoreResponse>(this.addStoresUrl, request).pipe(
      catchError(this.authService.handleError<AddStoreResponse>('AddStore'))
    );
  }

  SaveStoreDetails(request: SaveStoreDetailsRequest): Observable<any> {
    return this.http.post(this.saveDetailsUrl, request).pipe(
      catchError(this.authService.handleError<any>('SaveStoreDetails'))
    );
  }
}
