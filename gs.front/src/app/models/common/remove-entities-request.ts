export class RemoveEntitiesRequest {
  idsToRemove: number[];

  constructor(idsToRemove: number[]) {
    this.idsToRemove = idsToRemove;
  }
}
