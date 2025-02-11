import { Component } from '@angular/core';
import { RouterLink, RouterOutlet } from '@angular/router';
import { TodoListComponent } from "./pages/todo-list.component";


@Component({
  selector: 'app-root',
  template: `
 
    <main class="container mx-auto">
      <div class="flex gap-4">
      <a routerLink="/" class = "btn btn-primary"> Home </a>
        <a routerLink="todo-list" class = "btn btn-primary"> See my Todo List </a>
        <a  class = "btn btn-primary"> Add an Item to My todo List </a>
      </div>

      <app-todo-list/>
      
      <router-outlet/>
      
    </main>
  `,
  styles: [],
  imports: [RouterLink, RouterOutlet, TodoListComponent],
})
export class AppComponent {}
