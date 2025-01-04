namespace DoctorAppointmentDemo.Data.Interfaces
{
	public interface ISerializationService
	{
		T Deserialize<T>(string path);

		void Serialize<T>(string path, T data);

	}
}
