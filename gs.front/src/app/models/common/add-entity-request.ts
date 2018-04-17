export class AddEntityRequest<T> {
  entityToAdd: T;

  constructor(entityToAdd: T) {
    this.entityToAdd = entityToAdd;
  }
}
