export class Good {

  id: number;
  name: string;
  description: string;
  imageUris: string[];
  barcode: string;
  vendorCode: string;
  unit: string;

  constructor() {
    this.id = 0;
    this.name = "";
    this.description = "";
    this.imageUris = [];
    this.barcode = "";
    this.vendorCode = "";
    this.unit = "";
  }
}
