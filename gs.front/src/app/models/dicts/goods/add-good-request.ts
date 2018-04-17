import {Good} from './good';

export class AddGoodRequest {
  entityToAdd: Good;

  constructor(entityToAdd: Good) {
    this.entityToAdd = entityToAdd;
  }
}
