import { Routes } from '@angular/router';
import { BankingComponent } from './banking.component';
import { WithdrawalComponent } from './components/withdrawal.component';
import { DepositComponent } from './components/deposit.component';
export const BANKING_ROUTES: Routes = [
  {
    path: '',
    component: BankingComponent,
    children: [
      {
        path: 'withdrawal', // banking/withdrawal
        component: WithdrawalComponent,
      },
      {
        path: 'deposit',
        component: DepositComponent,
      },
    ],
  },
];
