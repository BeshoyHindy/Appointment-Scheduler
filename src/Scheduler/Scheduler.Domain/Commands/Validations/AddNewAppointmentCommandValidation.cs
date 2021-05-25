namespace Scheduler.Domain.Commands.Validations
{
    public class AddNewAppointmentCommandValidation : AppointmentValidation<AddNewAppointmentCommand>
    {
        public AddNewAppointmentCommandValidation()
        {
            ValidateName();
            ValidateStartTime();
            ValidateEndTime();
            ValidateEmail();
        }
    }
}