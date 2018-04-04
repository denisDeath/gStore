import { Injectable } from '@angular/core';
import {AuthService} from "../../../auth/auth.service";
import {Observable} from "rxjs/Observable";
import {of} from "rxjs/observable/of";
import {any} from "codelyzer/util/function";

@Injectable()
export class GoodsIncomingService {

  constructor(private auth: AuthService) { }

  public GetDocuments(): Observable<any> {
    return of<any>(
      {
        documents: [
          {
            id: 0,
            date: new Date(),
            store: 'test store',
            supplier: 'test supplier'
          }
        ]
      });
  }

}
