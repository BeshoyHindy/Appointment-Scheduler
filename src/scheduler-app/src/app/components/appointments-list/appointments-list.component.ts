import { Component, OnInit } from '@angular/core';
import { Appointment } from 'src/app/models/appointment.model';
import { AppointmentService } from 'src/app/services/appointment.service';

@Component({
  selector: 'app-appointments-list',
  templateUrl: './appointments-list.component.html',
  styleUrls: ['./appointments-list.component.scss']
})
export class AppointmentsListComponent implements OnInit {

  appointments?: Appointment[];
  currentAppointment?: Appointment;
  currentIndex = -1;
  name = '';

  constructor(private appointmentService: AppointmentService) { }

  ngOnInit(): void {
    this.retrieveAppointments();
  }

  retrieveAppointments(): void {
    this.appointmentService.getAll()
      .subscribe(
        data => {
          this.appointments = data;
          console.log(data);
        },
        error => {
          console.log(error);
        });
  }

  refreshList(): void {
    this.retrieveAppointments();
    this.currentAppointment = undefined;
    this.currentIndex = -1;
  }

  setActiveAppointment(appointment: Appointment, index: number): void {
    this.currentAppointment = appointment;
    this.currentIndex = index;
  }


}