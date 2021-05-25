namespace Scheduler.Domain.Commands.Validations
{
    public class RemoveAppointmentCommandValidation : AppointmentValidation<RemoveAppointmentCommand>
    {
        public RemoveAppointmentCommandValidation()
        {
            ValidateId();
        }
    }
}