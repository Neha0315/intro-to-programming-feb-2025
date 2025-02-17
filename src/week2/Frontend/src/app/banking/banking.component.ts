import { CurrencyPipe } from '@angular/common';
import {
  Component,
  ChangeDetectionStrategy,
  signal,
  inject,
} from '@angular/core';
import { RouterLink, RouterOutlet } from '@angular/router';
import { BankService } from './services/bank.service';

@Component({
  selector: 'app-banking',
  changeDetection: ChangeDetectionStrategy.OnPush,
  providers: [BankService],
  imports: [CurrencyPipe, RouterOutlet, RouterLink],
  template: `
    <div>
      <p>
        Your Checking Balance is {{ currentBalance() | currency }}
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
  service = inject(BankService);
  currentBalance = this.service.getCurrentBalance();
}
