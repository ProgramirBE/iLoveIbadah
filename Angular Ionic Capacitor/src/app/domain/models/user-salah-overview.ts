export class UserSalahOverview {
  id!: number;
  userAccountId!: number;
  totalTracked!: number;
  lastTrackedAt!: Date;

  // Add other user properties as needed

  constructor(data: Partial<UserSalahOverview>) {
    Object.assign(this, data);
  }

  static fromApiResponse(response: any): UserSalahOverview {
    return new UserSalahOverview(response);
  }
}
