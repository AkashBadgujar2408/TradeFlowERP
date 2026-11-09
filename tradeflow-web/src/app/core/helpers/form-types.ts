import { FormControl } from "@angular/forms";

declare global {
  type FormControls<T> = {
    [K in keyof T]: FormControl<T[K]>;
  };
}

export {};