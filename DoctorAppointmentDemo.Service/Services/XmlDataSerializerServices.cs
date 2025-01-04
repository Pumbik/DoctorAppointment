using DoctorAppointmentDemo.Data.Interfaces;
using System.Xml.Serialization;

namespace DoctorAppointmentDemo.Service.Services
{
	public class XmlDataSerializerServices : ISerializationService
	{
		public T Deserialize<T>(string path)
		{
			var serializer = new XmlSerializer(typeof(T));

			using (FileStream stream = new FileStream(path, FileMode.OpenOrCreate))
			{
				return (T)serializer.Deserialize(stream);
			}
		}

		public void Serialize<T>(string path, T data)
		{
			var formatter = new XmlSerializer(typeof(T));

			using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
			{
				formatter.Serialize(fs, data);
			}
		}
	}
}
