export class SaveEntityDetailsRequest<T> {
  entity: T;

  constructor(entity: T) {
    this.entity = entity;
  }
}
