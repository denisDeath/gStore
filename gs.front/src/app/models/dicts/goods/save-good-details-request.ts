import {Good} from "./good";

export class SaveGoodDetailsRequest {
  good: Good;

  constructor(good: Good) {
    this.good = good;
  }
}
