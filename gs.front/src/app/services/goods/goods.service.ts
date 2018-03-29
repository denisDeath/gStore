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

@Injectable()
export class GoodsService {

  private getGoodsUrl = environment.apiServerAddress + '/api/resellers/goods/list/getGoods';
  private addGoodsUrl = environment.apiServerAddress + '/api/resellers/goods/list/addGood';
  private getGoodDetailsUrl = environment.apiServerAddress + '/api/resellers/goods/list/getGoodDetails';

  constructor(private http: HttpClient,
              private authService: AuthService) { }

  public GetGoods(): Observable<GetGoodsResponse> {
    return this.http.post<GetGoodsResponse>(this.getGoodsUrl, {}, this.authService.GetHttpOptions()).pipe(
      catchError(this.authService.handleError<GetGoodsResponse>('GetGoods'))
    );
  }

  public AddGood(request: AddGoodRequest): Observable<AddGoodResponse> {
    return this.http.post<AddGoodRequest>(this.addGoodsUrl, request, this.authService.GetHttpOptions()).pipe(
      catchError(this.authService.handleError<AddGoodRequest>('AddGood'))
    );
  }

  public GetGoodDetails(request: GetGoodDetailsRequest): Observable<GetGoodDetailsResponse> {
    return this.http.post<GetGoodDetailsRequest>(this.getGoodDetailsUrl, request, this.authService.GetHttpOptions()).pipe(
      catchError(this.authService.handleError<GetGoodDetailsRequest>('GetGoodDetails'))
    );
  }

  public SaveGoodDetails(good: Good): Observable {
    return of();
  }
}
