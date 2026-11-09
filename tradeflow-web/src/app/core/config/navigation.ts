import { NavSection } from "../models/navigation/nav-section";

export const NAVIGATION: NavSection[] = [
  {
    title: 'Dashboards',
    items: [
      { label: 'Sales Dashboard', icon: 'fa-solid fa-chart-line', route: '/dashboard/sales' },
      { label: 'Inventory Dashboard', icon: 'fa-solid fa-boxes-stacked', route: '/dashboard/inventory' },
    ],
  },
  {
    title: 'Masters',
    items: [
      { label: 'Categories', icon: 'fa-solid fa-tags', route: '/masters/categories' },
      { label: 'Units', icon: 'fa-solid fa-ruler', route: '/masters/units' },
      { label: 'Tax Rates', icon: 'fa-solid fa-percent', route: '/masters/tax-rates' },
      { label: 'Warehouses', icon: 'fa-solid fa-warehouse', route: '/masters/warehouses' },
      { label: 'Products', icon: 'fa-solid fa-box', route: '/masters/products' },
      { label: 'Customers', icon: 'fa-solid fa-user-tie', route: '/masters/customers' },
      { label: 'Suppliers', icon: 'fa-solid fa-truck-field', route: '/masters/suppliers' },
      { label: 'Employees', icon: 'fa-solid fa-id-badge', route: '/masters/employees' },
    ],
  },
  {
    title: 'Transactions',
    items: [
      { label: 'Purchase Orders', icon: 'fa-solid fa-cart-flatbed', route: '/transactions/purchase-orders' },
      { label: 'Sales Invoices', icon: 'fa-solid fa-file-invoice', route: '/transactions/sales-invoices' },
      { label: 'Customer Receipts', icon: 'fa-solid fa-hand-holding-dollar', route: '/transactions/receipts' },
      { label: 'Stock Adjustments', icon: 'fa-solid fa-scale-balanced', route: '/transactions/stock-adjustments' },
    ],
  },
  {
    title: 'Reports',
    items: [
      { label: 'Sales Register', icon: 'fa-solid fa-file-lines', route: '/reports/sales' },
      { label: 'Purchase Register', icon: 'fa-solid fa-file-import', route: '/reports/purchases' },
      { label: 'Stock Summary', icon: 'fa-solid fa-cubes', route: '/reports/stock' },
      { label: 'Outstanding (Ageing)', icon: 'fa-solid fa-hourglass-half', route: '/reports/outstanding' },
    ],
  },
];