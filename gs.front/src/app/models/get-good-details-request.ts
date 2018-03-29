import {Good} from "./good";

export class GetGoodDetailsRequest {

  goodId: number;

  constructor(goodId: number) {
    this.goodId = goodId;
  }
}
