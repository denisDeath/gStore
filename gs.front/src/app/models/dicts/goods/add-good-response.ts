import {Good} from './good';

export class AddGoodResponse {
  addedGoodId: number;

  constructor(addedGoodId: number) {
    this.addedGoodId = addedGoodId;
  }
}
