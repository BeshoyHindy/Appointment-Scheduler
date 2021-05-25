import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Appointment } from 'src/app/models/appointment.model';
import { AppointmentService } from 'src/app/services/appointment.service';


@Component({
  selector: 'app-appointment-details',
  templateUrl: './appointment-details.component.html',
  styleUrls: ['./appointment-details.component.scss']
})
export class AppointmentDetailsComponent implements OnInit {

  currentAppointment: Appointment = {
    id:'',
    name: '',
    email: '',
    phoneNumber: '',
    startTime: new Date(),
    endTime: new Date(),
    date: new Date(),
    notes: ''
  };
  message = '';

  constructor(
    private appointmentService: AppointmentService,
    private route: ActivatedRoute,
    private router: Router) { }

  ngOnInit(): void {
    this.message = '';
    this.getAppointment(this.route.snapshot.params.id);
  }

  getAppointment(id: string): void {
    this.appointmentService.get(id)
      .subscribe(
        data => {
          this.currentAppointment = data;
          console.log(data);
        },
        error => {
          console.log(error);
        });
  }

 
  updateAppointment(): void {
    this.appointmentService.update(this.currentAppointment.id, this.currentAppointment)
      .subscribe(
        response => {
          console.log(response);
          this.message = response.message;
        },
        error => {
          console.log(error);
        });
  }

  deleteAppointment(): void {
    this.appointmentService.delete(this.currentAppointment.id)
      .subscribe(
        response => {
          console.log(response);
          this.router.navigate(['/appointments']);
        },
        error => {
          console.log(error);
        });
  }
}