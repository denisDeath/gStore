import {GoodCategory} from './good-category';

export class GetEntityDetailsRequest {

  entityId: number;

  constructor(entityId: number) {
    this.entityId = entityId;
  }
}
