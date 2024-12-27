export class ProfilePictureType {
  id!: number;
  blobFileId!: number;
  createdBy!: number;

  // Add other user properties as needed

  constructor(data: Partial<ProfilePictureType>) {
    Object.assign(this, data);
  }

  static fromApiResponse(response: any): ProfilePictureType {
    return new ProfilePictureType(response);
  }
}
