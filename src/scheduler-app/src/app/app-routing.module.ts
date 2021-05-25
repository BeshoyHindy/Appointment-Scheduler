import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppointmentsListComponent } from './components/appointments-list/appointments-list.component';
import { AppointmentDetailsComponent } from './components/appointment-details/appointment-details.component';
import { AddAppointmentComponent } from './components/add-appointment/add-appointment.component';

const routes: Routes = [
  { path: '', redirectTo: 'appointments', pathMatch: 'full' },
  { path: 'appointments', component: AppointmentsListComponent },
  { path: 'appointments/:id', component: AppointmentDetailsComponent },
  { path: 'add', component: AddAppointmentComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }