using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Scheduler.Application.Interfaces;
using Scheduler.Application.ViewModels;

namespace Scheduler.Service.Api.Controllers
{
    [Route("[controller]")]
    public class AppointmentController : BaseApiController
    {
        private readonly IAppointmentAppService _appointmentAppService;

        public AppointmentController(IAppointmentAppService appointmentAppService)
        {
            _appointmentAppService = appointmentAppService;
        }

        [HttpGet]
        public async Task<IEnumerable<AppointmentViewModel>> Get()
        {
            return await _appointmentAppService.GetAll();
        }

        [HttpGet("/{id:guid}")]
        public async Task<AppointmentViewModel> Get(Guid id)
        {
            return await _appointmentAppService.GetById(id);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AppointmentViewModel appointmentViewModel)
        {
            return !ModelState.IsValid ? Response(ModelState) : Response(await _appointmentAppService.Add(appointmentViewModel));
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] AppointmentViewModel appointmentViewModel)
        {
            return !ModelState.IsValid ? Response(ModelState) : Response(await _appointmentAppService.Update(appointmentViewModel));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Response(await _appointmentAppService.Delete(id));
        }


    }
}
