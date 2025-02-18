import { ChangeDetectionStrategy, Component } from '@angular/core';
import { RouterLink, RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-resources',
  changeDetection: ChangeDetectionStrategy.OnPush,
  imports: [RouterLink, RouterOutlet],
  template: `
    <p>Developer Resources</p>
    <a routerLink="create" class="btn btn-primary">Add A Resource</a>
    <a routerLink="list" class="btn btn-primary">List Of Resources</a>
    <router-outlet />
  `,
  styles: ``,
})
export class ResourcesComponent {}
