import {Good} from './good';

export class SaveGoodDetailsRequest {
  entity: Good;

  constructor(entity: Good) {
    this.entity = entity;
  }
}
