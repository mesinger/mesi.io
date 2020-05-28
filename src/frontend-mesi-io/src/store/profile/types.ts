export interface User {
  name: string;
  email: string;
}

export interface ProfileState {
  token: string;
  user: User | undefined;
  status: AuthenticationStatus;
}

export enum AuthenticationStatus {
  Authenticated,
  Anonymous,
  Error,
}
