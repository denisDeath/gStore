import {GoodCategory} from "./good-category";

export class AddEntityResponse {
  addedEntityId: number;

  constructor(addedEntityId: number) {
    this.addedEntityId = addedEntityId;
  }
}
