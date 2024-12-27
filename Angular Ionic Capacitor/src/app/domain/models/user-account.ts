export class UserAccount {
  id!: number;
  uniqueId!: string;
  fullName!: string;
  email!: string;
  profilePictureTypeId!: number;
  //passwordHash!: string; stays in database!
  emailConfirmed!: boolean;
  currentLocation!: string;
  totalWarnings!: number;
  isPermanentlyBanned!: boolean;

  // Add other user properties as needed

  constructor(data: Partial<UserAccount>) {
    Object.assign(this, data);
  }

  static fromApiResponse(response: any): UserAccount {
    return new UserAccount(response);
  }
}
