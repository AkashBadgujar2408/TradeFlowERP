import { Service, signal } from '@angular/core';

@Service()
export class LayoutService {
      /** Desktop: sidebar shows icons only. */
    readonly collapsed = signal(false);
    /** Mobile: sidebar slides in over the content. */
    readonly mobileOpen = signal(false);

    toggleSidebar(): void{
        if (window.innerWidth < 992){
            this.mobileOpen.update((open) => !open);
        }
        else {
            this.collapsed.update((collapsed) => !collapsed);
        }
    }
}
