using DoctorAppointmentDemo.Data.Interfaces;
using DoctorAppointmentDemo.Data.Repositories;
using DoctorAppointmentDemo.Domain.Entities;
using DoctorAppointmentDemo.Service.Extensions;
using DoctorAppointmentDemo.Service.Interfaces;
using DoctorAppointmentDemo.Service.ViewModels;

namespace DoctorAppointmentDemo.Service.Services
{
	public class DoctorService : IDoctorService
	{
		private readonly IDoctorRepository _doctorRepository;

		public DoctorService(string appSettings, ISerializationService serializationService)
		{
			_doctorRepository = new DoctorRepository(appSettings, serializationService);
		}

		public Doctor Create(Doctor doctor)
		{
			return _doctorRepository.Create(doctor);
		}

		public bool Delete(int id)
		{
			return _doctorRepository.Delete(id);
		}

		public Doctor? Get(int id)
		{
			return _doctorRepository.GetById(id);
		}

		public IEnumerable<DoctorViewModel> GetAll()
		{
			var doctors = _doctorRepository.GetAll();
			var doctorViewModels = doctors.Select(x => x.ConvertTo());
			return doctorViewModels;
		}

		public Doctor Update(int id, Doctor doctor)
		{
			return _doctorRepository.Update(id, doctor);
		}
	}
}
