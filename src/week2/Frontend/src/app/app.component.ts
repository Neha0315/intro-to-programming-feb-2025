import { Component } from '@angular/core';
import { RouterLink, RouterOutlet } from '@angular/router';
import { NavBarComponent } from './components/nav-bar.component';

@Component({
  selector: 'app-root',
  template: `
    <app-nav-bar />
    <main class="container mx-auto">
      <div>
        <a routerLink="" class="btn btn-accent">Home</a>
        <a routerLink="banking" class="btn btn-accent">Do Some Banking</a>
      </div>
      <router-outlet />
    </main>
  `,
  styles: [],
  imports: [RouterOutlet, RouterLink, NavBarComponent],
})
export class AppComponent {}
