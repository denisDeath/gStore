export class RemoveRequest {
  idsToRemove: number[];

  constructor(idsToRemove: number[]) {
    this.idsToRemove = idsToRemove;
  }
}
