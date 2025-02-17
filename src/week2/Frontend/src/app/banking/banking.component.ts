import { CurrencyPipe } from '@angular/common';
import {
  Component,
  ChangeDetectionStrategy,
  signal,
  inject,
} from '@angular/core';
import { RouterLink, RouterOutlet } from '@angular/router';
import { BankService } from './services/bank.service';
import { StatusComponent } from './components/status.component';
import { BankStore } from './services/bank.store';

@Component({
  selector: 'app-banking',
  changeDetection: ChangeDetectionStrategy.OnPush,

  imports: [CurrencyPipe, RouterOutlet, RouterLink],
  template: `
    <div>
      <p>
        Your Checking Balance is {{ store.currentBalance() | currency }}
        <a routerLink="deposit" class="btn btn-xs btn-secondary"
          >Make a Deposit</a
        >
        <a routerLink="withdrawal" class="btn btn-xs btn-secondary"
          >Make a Withdrawal</a
        >
      </p>
      <div>
        <router-outlet />
      </div>
    </div>
  `,
  styles: ``,
})
export class BankingComponent {
  store = inject(BankStore);
}
