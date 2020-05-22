export interface AuthenticationToken {
    raw: string;
    iss: string;
    name: string;
    email: string;
    exp: number;
}