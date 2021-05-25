import { Component, OnInit } from '@angular/core';
import { Appointment } from 'src/app/models/appointment.model';
import { AppointmentService } from 'src/app/services/appointment.service';

@Component({
  selector: 'app-add-appointment',
  templateUrl: './add-appointment.component.html',
  styleUrls: ['./add-appointment.component.scss']
})
export class AddAppointmentComponent implements OnInit {

  appointment: Appointment = {
    name: '',
    email: '',
    phoneNumber: '',
    startTime: new Date(),
    endTime: new Date(),
    date: new Date(),
    notes: ''
  };
  submitted = false;

  constructor(private appointmentService: AppointmentService) { }

  ngOnInit(): void {
  }

  saveAppointment(): void {
    const data = {
      name: this.appointment.name,
      email: this.appointment.email,
      phoneNumber: this.appointment.phoneNumber,
      startTime: this.appointment.startTime,
      endTime: this.appointment.endTime,
      date: this.appointment.date,
      notes: this.appointment.notes
    };

    this.appointmentService.create(data)
      .subscribe(
        response => {
          console.log(response);
          this.submitted = true;
        },
        error => {
          console.log(error);
        });
  }

  newAppointment(): void {
    this.submitted = false;
    this.appointment = {
      name: '',
      email: '',
      phoneNumber: '',
      startTime: new Date(),
      endTime: new Date(),
      date: new Date(),
      notes: ''
    };
  }

}