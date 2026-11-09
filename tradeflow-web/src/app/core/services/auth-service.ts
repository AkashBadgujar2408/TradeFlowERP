import { computed, inject, Service, signal } from '@angular/core';
import { LoggedInUser } from '../models/Auth/loggedin-user';
import { HttpClient } from '@angular/common/http';
import { StorageService } from './storage-service';
import { Router } from '@angular/router';
import { LoginRequest } from '../models/Auth/login-request';
import { Observable, tap } from 'rxjs';
import { LoginResponse } from '../models/Auth/login-response';
import { APP_SETTINGS } from '../config/app-settings.development';

interface Session {
    token: string;
    user: LoggedInUser;
}

@Service()
export class AuthService {
    private readonly http = inject(HttpClient);
    private readonly storage = inject(StorageService);
    private readonly router = inject(Router);
    private readonly baseApiUrl = inject(APP_SETTINGS).apiBaseUrl;

    private readonly session = signal<Session | null>(this.storage.get<Session>('session'));

    readonly user = computed(() => this.session()?.user ?? null);
    readonly token = computed(() => this.session()?.token ?? null);
    readonly isLoggedIn = computed(() => this.session() !== null);

    login(loginRequest: LoginRequest) : Observable<LoginResponse>{
        return this.http.post<LoginResponse>
        (
            this.baseApiUrl + '/auth/login',
            loginRequest
        ).pipe(
            tap((response) => {
                this.session.set(response);
                this.storage.set('session', response);
            })
        );
    }

    logout() : void {
        this.session.set(null);
        this.storage.remove('session');
        void this.router.navigate(['/login']);
    }
}
