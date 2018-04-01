import {Store} from "./store";

export class AddStoreRequest {
  store: Store;

  constructor(goodToAdd: Store) {
    this.store = goodToAdd;
  }
}
