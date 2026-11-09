import { inject, Service } from '@angular/core';
import { APP_SETTINGS } from '../config/app-settings.development';

@Service()
export class StorageService {
    private readonly prefix = inject(APP_SETTINGS).storagePrefix;

    get<T>(key: string) : T | null {
        try{
            const raw = localStorage.getItem(this.prefix + key);
            return raw == null ? null : JSON.parse(raw) as T;
        }
        catch {
            return null;
        }
    }

    set(key: string, value: unknown) : void{
        try{
            localStorage.setItem(this.prefix + key, JSON.stringify(value));
        }
        catch {
        // Storage unavailable - keep working with in-memory state.
        }
    }

    remove(key: string): void {
        try{
            localStorage.removeItem(this.prefix + key);
        }
        catch {
            // ignore
        }
    }
}
