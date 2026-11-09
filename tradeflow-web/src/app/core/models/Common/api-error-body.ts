
/*
 * Our API wraps every successful response in the same "envelope":
 *
 *   { "success": true, "message": "Category created.", "data": { ...the real payload... } }
 *
 * and every error in:
 *
 *   { "success": false, "message": "Validation failed.", "errors": { "code": ["Code already exists."] } }
 */

export interface ApiErrorBody {
    success: false;
    message: string;
    /** Field errors keyed by the path of the field, e.g. "code" or "items.0.quantity". */
    errors?: Record<string, string[]>;
}