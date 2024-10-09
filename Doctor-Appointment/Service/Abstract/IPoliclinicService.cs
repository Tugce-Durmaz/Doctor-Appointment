using Doctor_Appointment.Dtos.Policlinic;
using Doctor_Appointment.Models;

namespace Doctor_Appointment.Service.Abstract
{
    public interface IPoliclinicService
    {

            Task<int> CreateAsync(CreatePoliclinicDto createPoliclinicDto);
            Task<IEnumerable<Policlinic>> GetAllAsync();
            Task<Policlinic> FindOneAsync(int id);
            Task<int> UpdateAsync(int id, UpdatePoliclinicDto updatePoliclinicDto);
            Task RemoveAsync(int id);
            Task<int> AddDoctorAsync(int id, int doctorId);
            Task<int> RemoveDoctorAsync(int id, int doctorId);
           

    }
    }

