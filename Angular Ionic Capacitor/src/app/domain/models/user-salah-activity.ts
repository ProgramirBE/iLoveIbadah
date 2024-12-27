export class UserSalahActivity {
  id!: number;
  userAccountId!: number;
  salahTypeId!: number;
  trackedOn!: Date;
  punctualityPercentage!: number;

  // Add other user properties as needed

  constructor(data: Partial<UserSalahActivity>) {
    Object.assign(this, data);
  }

  static fromApiResponse(response: any): UserSalahActivity {
    return new UserSalahActivity(response);
  }
}
