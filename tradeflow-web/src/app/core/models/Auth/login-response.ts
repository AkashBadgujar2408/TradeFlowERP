import { LoggedInUser } from "./loggedin-user";

export interface LoginResponse {
    token: string,
    user: LoggedInUser
}