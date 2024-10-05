using Doctor_Appointment.Dtos.Appointment;
using Doctor_Appointment.Models;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Doctor_Appointment.Service.Abstract
{
        public interface IAppointmentService
        {
            Task<int> CreateAsync(CreateAppointmentDto createAppointmentDto);
            Task<IEnumerable<Appointment>> FindAllAsync();
            Task<Appointment> FindOneAsync(int id);
            Task<int> UpdateAsync(int id, UpdateAppointmentDto updateAppointmentDto);
            Task RemoveAsync(int id);
        }
    }

