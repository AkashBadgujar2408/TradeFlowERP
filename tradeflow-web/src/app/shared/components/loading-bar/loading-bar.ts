import { Component, inject } from '@angular/core';
import { LoadingService } from '../../../core/services/loading-service';

@Component({
  imports: [],
  selector: 'app-loading-bar',
  styleUrl: './loading-bar.css',
  template: `
    <div class="loading-bar" [class.active]="loading.isLoading()"></div>
  `,
})
export class LoadingBar {
  protected readonly loading = inject(LoadingService);
}
