// Headers information about GoodsIncoming document to display it in documents documents.
export class GoodsIncomingInfo {

  constructor(id: number, date: Date, store: string, supplier: string) {
    this.id = id;
    this.date = date;
    this.store = store;
    this.supplier = supplier;
  }

  id: number;
  date: Date;
  store: string;
  supplier: string;
}
