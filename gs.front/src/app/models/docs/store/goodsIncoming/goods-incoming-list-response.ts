import {GoodsIncomingInfo} from './goods-incoming-info';

export class GoodsIncomingListResponse {
  documents: GoodsIncomingInfo[];

  constructor(documents: GoodsIncomingInfo[]) {
    this.documents = documents;
  }
}
