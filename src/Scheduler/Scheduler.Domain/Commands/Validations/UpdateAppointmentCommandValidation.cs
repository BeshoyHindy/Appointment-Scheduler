namespace Scheduler.Domain.Commands.Validations
{
    public class UpdateAppointmentCommandValidation : AppointmentValidation<UpdateAppointmentCommand>
    {
        public UpdateAppointmentCommandValidation()
        {
            ValidateId();
            ValidateName();
            ValidateStartTime();
            ValidateEndTime();
            ValidateEmail();
        }
    }
}