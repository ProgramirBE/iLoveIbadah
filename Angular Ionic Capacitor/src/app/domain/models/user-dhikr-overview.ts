export class UserDhikrOverview {
  id!: number;
  userAccountId!: number;
  totalPerformed!: number;
  lastPerformedAt!: Date;

  // Add other user properties as needed

  constructor(data: Partial<UserDhikrOverview>) {
    Object.assign(this, data);
  }

  static fromApiResponse(response: any): UserDhikrOverview {
    return new UserDhikrOverview(response);
  }
}
