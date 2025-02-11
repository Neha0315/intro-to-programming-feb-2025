import { Component, ChangeDetectionStrategy, signal, resource} from "@angular/core";
import { DatePipe } from "@angular/common";
import { TodoListItem } from "../models";

@Component({
    selector : 'app-todo-list',
    changeDetection: ChangeDetectionStrategy.OnPush,
    imports: [DatePipe],
    template: `
    
    @for (item of itemsResource.value(); track item.id) {
<div class="card bg-base-100 w-96 shadow-xl">
<div class="card-body">
<h2 class="card-title">{{ item.description }}</h2>
<p>You Added this on{{ item.createdOn | date}}</p>
<div class="card-actions justify-end">
            @if (item.completed === false) {
<button class="btn btn-primary">Mark Completed</button>
            } @else {
<p>You Completed This Item On {{ item.completedOn | date}}</p>
<button class="btn btn-primary">Remove From List</button>
            }
</div>
</div>
</div>

@if (itemsResource.error()) {
<p>Could Not Load Your Data For Reasons. Sorry.</p>
    }
        }`,
    styles: ``,

})

export class TodoListComponent
{
    // items = signal<TodoListItem[]>([
    //     {
    //       id: '99',
    //       completed: false,
    //       createdOn: '2025-02-11T20:58:47.300Z',
    //       description: 'Shovel Snow',
    //     },
    //     {
    //       id: '100',
    //       completed: true,
    //       createdOn: '2025-02-11T20:58:47.300Z',
    //       description: 'Make Tacos',
    //       completedOn: '2025-02-11T20:58:47.300Z',
    //     },
    //   ]);


    itemsResource = resource({
        loader: () => fetch('http://localhost:1337/todos').then((r) => r.json()),
      });
}

