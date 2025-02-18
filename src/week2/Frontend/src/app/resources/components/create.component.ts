import { JsonPipe } from '@angular/common';
import { Component, ChangeDetectionStrategy } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-resources-create',
  changeDetection: ChangeDetectionStrategy.OnPush,
  imports: [ReactiveFormsModule, JsonPipe], // this is going to be replaced "sometime soon" with a signals based forms module.
  template: `
    <p>Create a New Resource</p>
    <pre>{{ form.value | json }}</pre>
    <form [formGroup]="form" class="w-1/3" (ngSubmit)="addItem()">
      <div class="form-control">
        <label for="title" class="label"
          >Title:

          <input
            type="text"
            id="title"
            class="input input-bordered"
            formControlName="title"
          />
        </label>
      </div>
      <div class="form-control">
        <label for="description" class="label"
          >Description:

          <textarea
            id="description"
            class="input input-bordered"
            formControlName="description"
          ></textarea>
        </label>
      </div>
      <div class="form-control">
        <label for="link" class="label"
          >Link:

          <input
            type="url"
            id="link"
            class="input input-bordered"
            formControlName="link"
          />
        </label>
      </div>
      <div class="form-control">
        <label for="linkText" class="label"
          >Link Text:

          <input
            type="text"
            id="linkText"
            class="input input-bordered"
            formControlName="linkText"
          />
        </label>
      </div>
      <div class="form-control">
        <label for="tags" class="label"
          >Tags:

          <input
            type="text"
            id="tags"
            class="input input-bordered"
            formControlName="tags"
          />
        </label>
      </div>
      <button type="submit" class="btn btn-primary">Add This Item</button>
    </form>
  `,
  styles: ``,
})
export class CreateComponent {
  form = new FormGroup({
    title: new FormControl<string>('', { nonNullable: true }),
    description: new FormControl<string>('', { nonNullable: true }),
    link: new FormControl<string>('', { nonNullable: true }),
    linkText: new FormControl<string>('', { nonNullable: true }),
    tags: new FormControl<string>('', { nonNullable: true }),
  });

  addItem() {
    // only do this if it is valid, follows all the rules, etc.
    // send it to our API to add it.
    console.log(this.form.value);
  }
}
