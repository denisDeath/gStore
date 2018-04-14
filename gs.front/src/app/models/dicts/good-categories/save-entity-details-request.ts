import {GoodCategory} from './good-category';

export class SaveEntityDetailsRequest {
  entity: GoodCategory;

  constructor(entity: GoodCategory) {
    this.entity = entity;
  }
}
