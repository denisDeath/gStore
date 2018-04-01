export class RemoveGoodsRequest {
  idsToRemove: number[];

  constructor(idsToRemove: number[]) {
    this.idsToRemove = idsToRemove;
  }
}
