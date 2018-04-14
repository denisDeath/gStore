export class OrganizationSettings {
  constructor(ownerFirstName: string, ownerLastName: string, ownerPatronymic: string, tradeMark: string,
              fullName: string, address: string, phone: string, inn: string, useVat: boolean) {
    this.ownerFirstName = ownerFirstName;
    this.ownerLastName = ownerLastName;
    this.ownerPatronymic = ownerPatronymic;
    this.tradeMark = tradeMark;
    this.fullName = fullName;
    this.address = address;
    this.phone = phone;
    this.inn = inn;
    this.useVat = useVat;
  }

  ownerFirstName: string;
  ownerLastName: string;
  ownerPatronymic: string;
  tradeMark: string;
  fullName: string;
  address: string;
  phone: string;
  inn: string;
  useVat: boolean;

  public static Empty(): OrganizationSettings {
    return new OrganizationSettings('', '', '', '', '', '',
      '', '', false);
  }
}
