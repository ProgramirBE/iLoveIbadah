export class UserDhikrActivity {
  id!: number;
  userAccountId!: number;
  dhikrTypeId!: number;
  performedOn!: Date;
  lastPerformedAt!: Date;
  totalPerformed!: number;

  // Add other user properties as needed

  constructor(data: Partial<UserDhikrActivity>) {
    Object.assign(this, data);
  }

  static fromApiResponse(response: any): UserDhikrActivity {
    return new UserDhikrActivity(response);
  }
}
