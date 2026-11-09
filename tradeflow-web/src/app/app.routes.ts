import { Routes } from '@angular/router';

export const routes: Routes = [
    {
        path: 'login',
        title: 'Sign in',
        // canActivate: [guestGuard],
        loadComponent: () => import('./features/auth/login/login').then(c => c.Login)
    }
];
