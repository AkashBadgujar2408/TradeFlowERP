import { InjectionToken } from "@angular/core";
import { AppSettings } from "../models/Common/app-settings";

const APP_Settings_Prod : AppSettings = {
    isProduction: false,
    appName: 'TradeFlow ERP',
    version: 'v1.0.0',
    apiBaseUrl: 'https://api.tradeflowerp.com/api',
    currency: 'INR',
    locale: 'en-IN',
    storagePrefix: 'tradeFlow.'
}

export const APP_SETTINGS = new InjectionToken<AppSettings>('APP_SETTINGS', {
    providedIn: 'root',
    factory: () => APP_Settings_Prod
});