import {Store} from './store';

export class SaveStoreDetailsRequest {
  entity: Store;

  constructor(entity: Store) {
    this.entity = entity;
  }
}
