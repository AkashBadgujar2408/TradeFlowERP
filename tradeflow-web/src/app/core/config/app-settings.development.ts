import { InjectionToken } from "@angular/core";
import { AppSettings } from "../models/Common/app-settings";

const APP_Settings_Dev : AppSettings = {
    isProduction: false,
    appName: 'TradeFlow ERP (DEVELOPMENT)',
    version: 'v1.0.0',
    apiBaseUrl: 'http://localhost:5029/api',
    currency: 'INR',
    locale: 'en-IN',
    storagePrefix: 'tradeFlowDev.'
}

export const APP_SETTINGS = new InjectionToken<AppSettings>('APP_SETTINGS', {
    providedIn: 'root',
    factory: () => APP_Settings_Dev
});