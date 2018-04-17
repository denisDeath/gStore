import {Store} from './store';

export class AddStoreRequest {
  entityToAdd: Store;

  constructor(entityToAdd: Store) {
    this.entityToAdd = entityToAdd;
  }
}
