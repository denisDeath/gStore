import {Good} from './good';

export class AddGoodResponse {
  addedEntityId: number;

  constructor(addedEntityId: number) {
    this.addedEntityId = addedEntityId;
  }
}
