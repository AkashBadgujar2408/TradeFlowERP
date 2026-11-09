import { Service, signal } from '@angular/core';

export interface ConfirmRequest{
    title: string;
    message: string;
    confirmText: string;
    variant: 'primary' | 'danger' | 'warning';
}

@Service()
export class ConfirmService {
    private resolve?: (answer: boolean) => void;
    readonly request = signal<ConfirmRequest | null>(null);

    ask(options: Partial<ConfirmRequest> & {title: string }): Promise<boolean>{
        this.resolve?.(false); // a previous dialog that is still open counts as "cancel"
        this.request.set({ message: '', confirmText: 'Confirm', variant: 'primary', ...options });
        return new Promise<boolean>((resolve) => (this.resolve = resolve));
    }

    askDelete(name: string): Promise<boolean> {
        return this.ask({
        title: `Delete ${name}?`,
        message: 'This action cannot be undone.',
        confirmText: 'Delete',
        variant: 'danger',
        });
    }

    close(answer: boolean): void {
        this.resolve?.(answer);
        this.resolve = undefined;
        this.request.set(null);
    }
}