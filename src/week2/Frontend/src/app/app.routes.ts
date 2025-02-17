import { Routes } from '@angular/router';

export const routes: Routes = [
  {
    path: 'banking',
    loadChildren: () =>
      import('./banking/banking.routes').then((r) => r.BANKING_ROUTES),
  },
];
