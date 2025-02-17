import { Component, ChangeDetectionStrategy, inject } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { BankService } from '../services/bank.service';

@Component({
  selector: 'app-banking-deposit',
  changeDetection: ChangeDetectionStrategy.OnPush,
  imports: [ReactiveFormsModule],
  template: `
    <form [formGroup]="form" (ngSubmit)="doDeposit()">
      <div class="form-control">
        <label for="amount" class="label"
          >Amount of Deposit
          <input
            formControlName="amount"
            class="input input-bordered input-md"
            type="number"
            id="amount"
          />
        </label>
        <button type="submit" class="btn btn-primary">Make Deposit</button>
      </div>
    </form>
  `,
  styles: ``,
})
export class DepositComponent {
  service = inject(BankService);
  form = new FormGroup({
    amount: new FormControl<number>(0, { nonNullable: true }),
  });

  doDeposit() {
    // do the deposit here.
    this.service.deposit(this.form.controls.amount.value);
  }
}
