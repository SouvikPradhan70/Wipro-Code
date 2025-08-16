import { Component,inject  } from '@angular/core';
import { ReactiveFormsModule, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Events } from '../events';
import { NgIf } from '@angular/common';

@Component({
  selector: 'app-event-create',
  imports: [ReactiveFormsModule, NgIf],
  templateUrl: './event-create.html',
  styleUrls: ['./event-create.scss']
})
export class EventCreate {
  fb = inject(FormBuilder);
  svc = inject(Events);
  router = inject(Router);
  error: string | null = null;

  form = this.fb.group({
    title: ['', [Validators.required, Validators.maxLength(80)]],
    date: ['', [Validators.required]],
    location: ['', [Validators.required]],
    price: [0, [Validators.min(0)]],
    capacity: [50, [Validators.required, Validators.min(1)]],
    description: ['']
  });

  submit() {
    if (this.form.invalid) { this.form.markAllAsTouched(); return; }
    const { title, date, location, price, capacity, description } = this.form.value;
    const payload = {
      title: title!,
      date: date!,
      location: location!,
      price: Number(price ?? 0),
      capacity: Number(capacity ?? 1),
      attendeesCount: 0,
      description: description ?? ''
    };
    // min date validation (client-side)
    if (new Date(payload.date) < new Date(new Date().toDateString())) {
      this.error = 'Date must be today or later.';
      return;
    }
    this.svc.createEvent(payload).subscribe({
      next: () => this.router.navigateByUrl('/events'),
      error: er => this.error = er.message
    });
  }

}
