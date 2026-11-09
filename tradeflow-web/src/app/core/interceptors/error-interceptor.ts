import { HttpErrorResponse, HttpInterceptorFn } from '@angular/common/http';
import { inject } from '@angular/core';
import { AuthService } from '../services/auth-service';
import { ApiErrorBody } from '../models/Common/api-error-body';
import { ToastService } from '../services/toast-service';
import { catchError, throwError } from 'rxjs';

export const errorInterceptor: HttpInterceptorFn = (req, next) => {
  const auth = inject(AuthService);
  const toast = inject(ToastService);

  return next(req).pipe(
    catchError((error: unknown) => {
      if (error instanceof HttpErrorResponse){
        if (error.status === 401){
          auth.logout();
          toast.warning('Your session has ended. Please sign in again.');
        }
        else {
          toast.error(errorMessage(error));
        }
      }
      return throwError(() => error);
    }
    )
  );
};

export function errorMessage(error: HttpErrorResponse): string {
  if (error.status === 0){
    return 'Cannot reach the server. Check your connection.';
  }
  const body = error.error as ApiErrorBody | null;
  return body?.message ?? `Request failed (${error.status}).`;
}