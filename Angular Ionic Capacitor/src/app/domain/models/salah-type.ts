export class SalahType {
  id!: number;
  fullName!: string;
  createdBy!: number;

  // Add other user properties as needed

  constructor(data: Partial<SalahType>) {
    Object.assign(this, data);
  }

  static fromApiResponse(response: any): SalahType {
    return new SalahType(response);
  }
}
