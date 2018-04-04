import { Injectable } from '@angular/core';
import {AuthService} from "../../../auth/auth.service";
import {Observable} from "rxjs/Observable";
import {of} from "rxjs/observable/of";
import {any} from "codelyzer/util/function";
import {GoodsIncomingInfo} from "../../../../models/docs/store/goodsIncoming/goods-incoming-info";
import {GoodsIncomingListResponse} from "../../../../models/docs/store/goodsIncoming/goods-incoming-list-response";
import {HttpClient} from "@angular/common/http";
import {environment} from "../../../../../environments/environment";

@Injectable()
export class GoodsIncomingService {

  private getDocumentsUrl = environment.apiServerAddress + '/api/resellers/docs/goodsIncoming/list';

  constructor(private http: HttpClient,
              private authService: AuthService) { }

  public GetDocuments(): Observable<GoodsIncomingListResponse> {
    return of<GoodsIncomingListResponse>(
      new GoodsIncomingListResponse([
        new GoodsIncomingInfo(0, new Date(), 'store', 'supplier'),
        new GoodsIncomingInfo(1, new Date(), 'store 2', 'supplier 2')
      ]));
  }

}
