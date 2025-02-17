import { Component, ChangeDetectionStrategy } from '@angular/core';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-nav-bar',
  changeDetection: ChangeDetectionStrategy.OnPush,
  imports: [RouterLink],
  template: `
    <div>
      <a routerLink="" class="btn btn-accent">Home</a>
      <a routerLink="banking" class="btn btn-accent">Do Some Banking</a>
    </div>
  `,
  styles: ``,
})
export class NavBarComponent {}
