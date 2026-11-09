import { Component, inject, input, signal } from '@angular/core';
import { AuthService } from '../../../core/services/auth-service';
import { Router } from '@angular/router';
import { FormGroup, NonNullableFormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { LoginRequest } from '../../../core/models/Auth/login-request';
import { finalize } from 'rxjs';
import { HttpErrorResponse } from '@angular/common/http';
import { APP_SETTINGS } from '../../../core/config/app-settings.development';
import { FieldError } from '../../../shared/forms/field-error/field-error';
import { errorMessage } from '../../../core/interceptors/error-interceptor';

@Component({
  imports: [ReactiveFormsModule, FieldError],
  selector: 'app-login',
  styleUrl: './login.css',
  templateUrl: './login.html',
})
export class Login {
  private readonly auth = inject(AuthService);
  private readonly router = inject(Router);
  protected readonly appSettings = inject(APP_SETTINGS);

  protected readonly submitting = signal(false);
  protected readonly serverError = signal('');
  protected readonly showPassword = signal(false);

  /** ?returnUrl=... set by authGuard (route query params arrive as inputs too). */
  readonly returnUrl = input<string>('/');

  private readonly formBuilder = inject(NonNullableFormBuilder);
  protected readonly form: FormGroup<FormControls<LoginRequest>> = 
                        this.formBuilder
                        .group({
                            username: ['', [Validators.required, Validators.minLength(6)]],
                            password: ['', [Validators.required, Validators.minLength(6)]],
                        });

  protected submit(): void{
    if (this.form.invalid){
      this.form.markAllAsTouched();
      return;
    }
    this.serverError.set('');
    this.submitting.set(true);

    const request: LoginRequest = this.form.getRawValue();
    this.auth.login(request)
        .pipe(finalize(() => this.submitting.set(false)))
        .subscribe({
          next: () => this.router.navigateByUrl(this.returnUrl() || '/'),
          error: (error: HttpErrorResponse) => this.serverError.set(errorMessage(error))
        });
  }
}
