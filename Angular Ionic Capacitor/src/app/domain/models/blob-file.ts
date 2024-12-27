export class BlobFile {
  id!: number;
  uri!: string;
  fullName!: string;
  extension!: string;
  size!: number;
  createdBy!: number;

  // Add other user properties as needed

  constructor(data: Partial<BlobFile>) {
    Object.assign(this, data);
  }

  static fromApiResponse(response: any): BlobFile {
    return new BlobFile(response);
  }
}
