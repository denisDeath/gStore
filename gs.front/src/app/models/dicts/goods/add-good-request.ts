import {Good} from './good';

export class AddGoodRequest {
  goodToAdd: Good;

  constructor(goodToAdd: Good) {
    this.goodToAdd = goodToAdd;
  }
}
