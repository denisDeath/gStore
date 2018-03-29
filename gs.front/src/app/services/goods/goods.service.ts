import { Injectable } from '@angular/core';
import {Observable} from "rxjs/Observable";
import {Good} from "../../models/good";
import {of} from "rxjs/observable/of";
import {environment} from "../../../environments/environment";
import {HttpClient} from "@angular/common/http";
import {AuthService} from "../auth/auth.service";
import {catchError, tap} from "rxjs/operators";
import {RegisterResponse} from "../../models/register-response";
import {GetGoodsResponse} from "../../models/get-goods-response";
import {AddGoodRequest} from "../../models/add-good-request";
import {AddGoodResponse} from "../../models/add-good-response";
import {GetGoodDetailsResponse} from "../../models/get-good-details-response";
import {GetGoodDetailsRequest} from "../../models/get-good-details-request";
import {RemoveGoodsRequest} from "../../models/remove-goods-request";
import {SaveGoodDetailsRequest} from "../../models/save-good-details-request";

@Injectable()
export class GoodsService {

  private getGoodsUrl = environment.apiServerAddress + '/api/resellers/goods/list/getGoods';
  private addGoodsUrl = environment.apiServerAddress + '/api/resellers/goods/list/addGood';
  private removeGoodsUrl = environment.apiServerAddress + '/api/resellers/goods/list/removeGoods';
  private getGoodDetailsUrl = environment.apiServerAddress + '/api/resellers/goods/list/getGoodDetails';
  private saveGoodDetailsUrl = environment.apiServerAddress + '/api/resellers/goods/list/saveGoodDetails';

  constructor(private http: HttpClient,
              private authService: AuthService) { }

  public GetGoods(): Observable<GetGoodsResponse> {
    let options = {
      headers: this.authService.getHttpHeaders()
    };
    return this.http.post<GetGoodsResponse>(this.getGoodsUrl, {}, options).pipe(
      catchError(this.authService.handleError<GetGoodsResponse>('GetGoods'))
    );
  }

  public AddGood(request: AddGoodRequest): Observable<AddGoodResponse> {
    let options = {
      headers: this.authService.getHttpHeaders()
    };
    return this.http.post<AddGoodResponse>(this.addGoodsUrl, request, options).pipe(
      catchError(this.authService.handleError<AddGoodResponse>('AddGood'))
    );
  }

  public RemoveGoods(request: RemoveGoodsRequest): Observable<any> {
    let options = {
      headers: this.authService.getHttpHeaders()
    };
    return this.http.post<RemoveGoodsRequest>(this.removeGoodsUrl, request, options).pipe(
      catchError(this.authService.handleError<RemoveGoodsRequest>('RemoveGoods'))
    );
  }

  public GetGoodDetails(request: GetGoodDetailsRequest): Observable<GetGoodDetailsResponse> {
    let options = {
      headers: this.authService.getHttpHeaders()
    };
    return this.http.post<GetGoodDetailsResponse>(this.getGoodDetailsUrl, request, options).pipe(
      catchError(this.authService.handleError<GetGoodDetailsResponse>('GetGoodDetails'))
    );
  }

  public SaveGoodDetails(request: SaveGoodDetailsRequest): Observable<any> {
    let options = {
      headers: this.authService.getHttpHeaders()
    };
    return this.http.post(this.saveGoodDetailsUrl, request, options).pipe(
      catchError(this.authService.handleError<any>('SaveGoodDetails'))
    );
  }
}
