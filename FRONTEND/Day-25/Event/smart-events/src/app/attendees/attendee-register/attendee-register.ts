import { Component, EventEmitter, Output } from '@angular/core';
import { FormsModule, NgForm } from '@angular/forms';
import { NgIf } from '@angular/common';

@Component({
  selector: 'app-attendee-register',
  standalone: true,
  imports: [FormsModule, NgIf],
  template: `
    <form #f="ngForm" (ngSubmit)="submit(f)">
      <label>
        Name:
        <input name="name" [(ngModel)]="model.name" required />
      </label>
      <span *ngIf="f.submitted && !model.name" class="err">Name required</span>
      <br />

      <label>
        Email:
        <input name="email" [(ngModel)]="model.email" required email />
      </label>
      <span *ngIf="f.submitted && (!model.email || f.controls['email']?.errors?.['email'])" class="err">
        Valid email required
      </span>
      <br />

      <button type="submit">Register</button>
    </form>
  `,
  styles: [`.err { color: red; font-size: 0.9em; }`]
})
export class AttendeeRegister {
  @Output() register = new EventEmitter<{ name: string; email: string }>();

  model = { name: '', email: '' };

  submit(f: NgForm) {
    if (f.valid) {
      this.register.emit({ ...this.model });
      this.model = { name: '', email: '' };
      f.resetForm();
    }
  }
}
