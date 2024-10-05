using Doctor_Appointment.Dtos.Patient;
using Doctor_Appointment.Models;

namespace Doctor_Appointment.Service.Abstract
{
    public interface IPatientService
   
        {
            Task<int> CreateAsync(CreatePatientDto createPatientDto);
            Task<IEnumerable<Patient>> FindAllAsync();
            Task<Patient> FindOneAsync(int id);
            Task RemoveAsync(int id);
            Task<int> UpdateAsync(int id, UpdatePatientDto updatePatientDto);
        }
    }

