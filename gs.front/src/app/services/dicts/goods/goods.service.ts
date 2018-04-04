import { Injectable } from '@angular/core';
import {Observable} from "rxjs/Observable";
import {Good} from "../../../models/dicts/goods/good";
import {of} from "rxjs/observable/of";
import {environment} from "../../../../environments/environment";
import {HttpClient} from "@angular/common/http";
import {AuthService} from "../../auth/auth.service";
import {catchError, tap} from "rxjs/operators";
import {RegisterResponse} from "../../../models/register-response";
import {GetGoodsResponse} from "../../../models/dicts/goods/get-goods-response";
import {AddGoodRequest} from "../../../models/dicts/goods/add-good-request";
import {AddGoodResponse} from "../../../models/dicts/goods/add-good-response";
import {GetGoodDetailsResponse} from "../../../models/dicts/goods/get-good-details-response";
import {GetGoodDetailsRequest} from "../../../models/dicts/goods/get-good-details-request";
import {RemoveGoodsRequest} from "../../../models/dicts/goods/remove-goods-request";
import {SaveGoodDetailsRequest} from "../../../models/dicts/goods/save-good-details-request";

@Injectable()
export class GoodsService {

  private getGoodsUrl = environment.apiServerAddress + '/api/resellers/goods/documents/getGoods';
  private addGoodsUrl = environment.apiServerAddress + '/api/resellers/goods/documents/addGood';
  private removeGoodsUrl = environment.apiServerAddress + '/api/resellers/goods/documents/removeGoods';
  private getGoodDetailsUrl = environment.apiServerAddress + '/api/resellers/goods/documents/getGoodDetails';
  private saveGoodDetailsUrl = environment.apiServerAddress + '/api/resellers/goods/documents/saveGoodDetails';

  constructor(private http: HttpClient,
              private authService: AuthService) { }

  public GetGoods(): Observable<GetGoodsResponse> {
    return this.http.post<GetGoodsResponse>(this.getGoodsUrl, {}).pipe(
      catchError(this.authService.handleError<GetGoodsResponse>('GetGoods'))
    );
  }

  public AddGood(request: AddGoodRequest): Observable<AddGoodResponse> {
    return this.http.post<AddGoodResponse>(this.addGoodsUrl, request).pipe(
      catchError(this.authService.handleError<AddGoodResponse>('AddGood'))
    );
  }

  public RemoveGoods(request: RemoveGoodsRequest): Observable<any> {
    return this.http.post<RemoveGoodsRequest>(this.removeGoodsUrl, request).pipe(
      catchError(this.authService.handleError<RemoveGoodsRequest>('RemoveGoods'))
    );
  }

  public GetGoodDetails(request: GetGoodDetailsRequest): Observable<GetGoodDetailsResponse> {
    return this.http.post<GetGoodDetailsResponse>(this.getGoodDetailsUrl, request).pipe(
      catchError(this.authService.handleError<GetGoodDetailsResponse>('GetGoodDetails'))
    );
  }

  public SaveGoodDetails(request: SaveGoodDetailsRequest): Observable<any> {
    return this.http.post(this.saveGoodDetailsUrl, request).pipe(
      catchError(this.authService.handleError<any>('SaveGoodDetails'))
    );
  }
}
