import { Component, computed, input } from '@angular/core';
import { toObservable, toSignal } from '@angular/core/rxjs-interop';
import { AbstractControl } from '@angular/forms';
import { map, of, startWith, switchMap } from 'rxjs';
import { firstErrorMessage } from '../../../core/helpers/validation-errors';

@Component({
  imports: [],
  selector: 'app-field-error',
  styleUrl: './field-error.css',
  template: `
    @if(message(); as text) {
      <div class="field-error"><i class="fa-solid fa-circle-exclamation"></i> {{ text }}</div>
    }`,
})
export class FieldError {
  readonly control = input.required<AbstractControl | null>();
  readonly label = input('This field');

  private readonly errors = toSignal(
    toObservable(this.control).pipe(
      switchMap((control) => 
        control
          ? control.events.pipe(
            startWith(null),
            map(() => (control.invalid && control.touched ? control.errors : null)),
          )
          : of(null),
      )
    ),
    { initialValue : null }
  );

   protected readonly message = computed(() => firstErrorMessage(this.errors(), this.label()));
}
