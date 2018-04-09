import {GoodCategory} from "./good-category";

export class AddEntityRequest {
  entityToAdd: GoodCategory;

  constructor(entityToAdd: GoodCategory) {
    this.entityToAdd = entityToAdd;
  }
}
