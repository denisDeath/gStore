import {Store} from './store';

export class SaveStoreDetailsRequest {
  store: Store;

  constructor(store: Store) {
    this.store = store;
  }
}
