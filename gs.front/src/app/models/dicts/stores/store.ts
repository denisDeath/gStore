// склад/магазин
export class Store {

  id: number;
  name: string;
  description: string;
  address: string;

  // является ли магазином
  isShop: boolean;

  constructor() {
    this.id = 0;
    this.name = '';
    this.description = '';
    this.address = '';
    this.isShop = false;
  }
}

