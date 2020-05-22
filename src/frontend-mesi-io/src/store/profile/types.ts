import { AuthenticationToken } from '@/entities/user/AuthenticationToken';

export interface User {
    userName: string;
    email: string;
}

export interface ProfileState {
    user?: User;
    token?: AuthenticationToken;
    loggedIn: boolean;
    loginAttempts: number;
}
