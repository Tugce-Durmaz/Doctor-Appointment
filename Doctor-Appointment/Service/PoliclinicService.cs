using Doctor_Appointment.Dtos.Policlinic;
using Doctor_Appointment.Exceptions;
using Doctor_Appointment.Models;
using Doctor_Appointment.Repositories;
using Doctor_Appointment.Service.Abstract;

namespace Doctor_Appointment.Service
{
    public class PoliclinicService : IPoliclinicService
    {

        private readonly IRepository<Policlinic> _policlinicRepository;
        private readonly IRepository<Doctor> _doctorRepository;

        public PoliclinicService(IRepository<Policlinic> policlinicRepository, IRepository<Doctor> doctorRepository)
        {
            _policlinicRepository = policlinicRepository;
            _doctorRepository = doctorRepository;
        }

        public async Task<int> AddDoctorAsync(int id, int doctorId)
        {
            var policlinic = await _policlinicRepository.FindByIdAsync(id, new[] { "Doctors" });
            if (policlinic == null)
            {
                throw new NotFoundException("Policlinic not found!");
            }

            var doctor = await _doctorRepository.FindByIdAsync(doctorId);
            if (doctor == null)
            {
                throw new NotFoundException("Doctor not found!");
            }

            if (policlinic.Doctors == null)
            {
                policlinic.Doctors = new List<Doctor>();
            }

            policlinic.Doctors.Add(doctor);
            await _policlinicRepository.UpdateAsync(policlinic);
            return policlinic.Id;
        }


        public async Task<int> CreateAsync(CreatePoliclinicDto createPoliclinicDto)
        {
            var policlinic = new Policlinic
            {
                // DTO'dan alınan verilere göre Policlinic nesnesini oluşturun
                Name = createPoliclinicDto.Name,
                // Diğer gerekli alanlar burada ayarlanabilir
            };

            await _policlinicRepository.AddAsync(policlinic);
            return policlinic.Id; // Veya gerekli dönüş türünü ayarlayın
        }

        public async Task<IEnumerable<Policlinic>> FindAllAsync()
        {
            return await _policlinicRepository.GetAllAsync(new[] { "Doctors" });
        }

        public async Task<Policlinic> FindOneAsync(int id)
        {
            var policlinic = await _policlinicRepository.FindByIdAsync(id, new[] { "Doctors" });
            if (policlinic == null)
            {
                throw new NotFoundException("Policlinic not found!");
            }

            return policlinic;
        }

      

        public async Task RemoveAsync(int id)
        {
            var policlinic = await _policlinicRepository.FindByIdAsync(id);
            if (policlinic == null)
            {
                throw new NotFoundException("Policlinic not found!");
            }

            await _policlinicRepository.RemoveAsync(policlinic);
        }


        public async Task<int> RemoveDoctorAsync(int id, int doctorId)
        {
            var policlinic = await _policlinicRepository.FindByIdAsync(id, new[] { "Doctors" });
            if (policlinic == null)
            {
                throw new NotFoundException("Policlinic not found!");
            }

            var doctor = await _doctorRepository.FindByIdAsync(doctorId);
            if (doctor == null)
            {
                throw new NotFoundException("Doctor not found!");
            }

            policlinic.Doctors.Remove(doctor);
            await _policlinicRepository.UpdateAsync(policlinic);
            return policlinic.Id;
        }

        public async Task<int> UpdateAsync(int id, UpdatePoliclinicDto updatePoliclinicDto)
        {
            var policlinic = await _policlinicRepository.FindByIdAsync(id);
            if (policlinic == null)
            {
                throw new NotFoundException("Policlinic not found!");
            }

            policlinic.Name = updatePoliclinicDto.Name;
            // Diğer güncellemeleri burada yapın

            await _policlinicRepository.UpdateAsync(policlinic);
            return policlinic.Id;
        }
    }
}