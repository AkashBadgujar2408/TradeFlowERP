import { Component, inject } from '@angular/core';
import { ConfirmService } from '../../../core/services/confirm-service';
import { AutoFocusDirective } from '../../directives/auto-focus-directive';

@Component({
  imports: [AutoFocusDirective],
  selector: 'app-confirm-dialog',
  styleUrl: './confirm-dialog.css',
  templateUrl: './confirm-dialog.html',
  host: { '(document:keydown.escape)': 'confirm.request() && confirm.close(false)' }
})
export class ConfirmDialog {
  protected readonly confirm = inject(ConfirmService);
}