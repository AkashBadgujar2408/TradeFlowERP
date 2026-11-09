
export interface LoggedInUser {
    id: number,
    username: string;
    fullName: string;
    role: 'Admin' | 'User'
}