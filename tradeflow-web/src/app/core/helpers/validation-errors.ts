import { ValidationErrors } from "@angular/forms";

/**
 * One place for every validation message. Keys = error keys produced by validators.
 * `label` is the field name ("Email"), `error` is the error's value (e.g. { min: 1, actual: 0 }).
 */
type MessageFn = (label: string, error: any) => string;

const MESSAGES: Record<string, MessageFn> = {
  required: (label) => `${label} is required.`,
  email: () => 'Enter a valid email address.',
  minlength: (label, e) => `${label} must be at least ${e.requiredLength} characters.`,
  maxlength: (label, e) => `${label} cannot be more than ${e.requiredLength} characters.`,
  min: (label, e) => `${label} must be at least ${e.min}.`,
  max: (label, e) => `${label} cannot be more than ${e.max}.`,
  pattern: (label) => `${label} has an invalid format.`,
  phone: () => 'Enter a valid 10-digit mobile number.',
  gstin: () => 'Enter a valid 15-character GSTIN (e.g. 27ABCDE1234F1Z5).',
  pincode: () => 'Enter a valid 6-digit PIN code.',
  whitespace: (label) => `${label} cannot be only spaces.`,
  unique: (label) => `This ${label.toLowerCase()} is already used.`,
  compare: () => 'Sale price cannot be lower than the purchase price.',
  dateRange: () => 'This date cannot be before the start date.',
  minRows: (_label, e) => `Add at least ${e.min} row(s).`,
  maxAmount: (_label, e) => `Cannot be more than ${e.max}.`,
  // Errors that came back from the API (see server-errors.ts) - shown as-is.
  server: (_label, message) => String(message),
};

export function firstErrorMessage(errors: ValidationErrors | null, label: string): string | null {
    if (!errors) return null;
    const key = Object.keys(errors)[0];
    const message = MESSAGES[key];
    return message ? message(label, errors[key]) : `${label} is invalid.`;
}