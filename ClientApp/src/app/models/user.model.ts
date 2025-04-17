export class User {
  constructor(
    public id: string,
    public username: string,
    public email: string,
    public password: string,
    public role: 'Customer' | 'Admin',
    public fullName: string,
    public address: string,
    public phoneNumber: string,
    public dateOfBirth: string, // Keep as ISO string when sending to/from API
  ) {}
}
