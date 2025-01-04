using DoctorAppointmentDemo.Domain.Entities;

namespace DoctorAppointmentDemo.Data.Interfaces
{
	public interface IAppointmentRepository
	{
		Appointment GetAllByDoctor(Doctor doctor);

		Appointment GetAllByPatients(Patient patient);
	}
}
