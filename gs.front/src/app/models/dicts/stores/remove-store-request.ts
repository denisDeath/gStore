export class RemoveStoreRequest {
  idsToRemove: number[];

  constructor(idsToRemove: number[]) {
    this.idsToRemove = idsToRemove;
  }
}
