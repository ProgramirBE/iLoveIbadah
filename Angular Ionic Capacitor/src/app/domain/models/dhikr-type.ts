export class DhikrType {
  id!: number;
  fullName!: string;
  createdBy!: number;

  // Add other user properties as needed

  constructor(data: Partial<DhikrType>) {
    Object.assign(this, data);
  }

  static fromApiResponse(response: any): DhikrType {
    return new DhikrType(response);
  }
}
