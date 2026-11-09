import { Component, inject } from '@angular/core';
import { ToastService, ToastType } from '../../../core/services/toast-service';

const ICONS: Record<ToastType, string> = {
  success: 'fa-circle-check',
  error: 'fa-circle-xmark',
  warning: 'fa-triangle-exclamation',
  info: 'fa-circle-info',
};

@Component({
  imports: [],
  selector: 'app-toast-container',
  styleUrl: './toast-container.css',
  templateUrl: './toast-container.html',
})
export class ToastContainer {
  protected readonly toastService = inject(ToastService);
  protected readonly icons = ICONS;
}
