import { Service, signal } from '@angular/core';

export type ToastType = 'success' | 'error' | 'warning' | 'info';

export interface Toast {
    id: number;
    type: ToastType;
    message: string;
}

@Service()
export class ToastService {
    private nextId = 1;
    readonly toasts = signal<Toast[]>([]);

    success(message: string) : void {
        this.show('success', message);
    }

    error(message: string): void {
    this.show('error', message, 6000);
  }

  warning(message: string): void {
    this.show('warning', message);
  }

  info(message: string): void {
    this.show('info', message);
  }

  dismiss(id: number): void {
    this.toasts.update((list) => list.filter((toast) => toast.id !== id));
  }

  private show(type: ToastType, message: string, durationMs = 3500): void {
    const toast: Toast = { id: this.nextId++, type, message };
    this.toasts.update((list) => [...list, toast].slice(-4));
    setTimeout(() => {
        this.dismiss(toast.id);
    }, durationMs);
  }
}
