import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { LoadingBar } from './shared/components/loading-bar/loading-bar';
import { ToastContainer } from './shared/components/toast-container/toast-container';
import { ConfirmDialog } from './shared/components/confirm-dialog/confirm-dialog';

@Component({
  imports: [RouterOutlet, LoadingBar, ToastContainer, ConfirmDialog],
  selector: 'app-root',
  template: `
    <app-loading-bar />
    <router-outlet />
    <app-toast-container />
    <app-confirm-dialog />
  `,
})
export class App {
  
}
