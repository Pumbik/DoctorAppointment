using DoctorAppointmentDemo.Data.Interfaces;
using DoctorAppointmentDemo.Service.Services;
using DoctorAppointmentDemo.Data.Configuration;
using DoctorAppointmentDemo.Domain.Entities;
using DoctorAppointmentDemo.Service.Interfaces;


namespace DoctorAppointmentDemo
{
	public class DoctorAppointment
	{
		private readonly IDoctorService _doctorService;

		public DoctorAppointment(string appSettings, ISerializationService serializationService)
		{
			_doctorService = new DoctorService(appSettings, serializationService);
		}

		public void Menu()
		{
			Console.WriteLine("Актуальний список лікарів: ");
			var docs = _doctorService.GetAll();

			foreach (var doc in docs)
			{
				Console.WriteLine(doc.Name);
			}
			//_doctorService.Delete(2);


			//Console.WriteLine("Adding doctor: ");

			//var newDoctor = new Doctor
			//{
			//    Name = "Ivan",
			//    Surname = "Kullishov",
			//    Experience = 20,
			//    DoctorType = Domain.Enums.DoctorTypes.Dermatologist,
			//};

			//_doctorService.Create(newDoctor);

			Console.WriteLine("Актуальний список лікарів: ");
			docs = _doctorService.GetAll();

			foreach (var doc in docs)
			{
				Console.WriteLine($"Doctor: {doc.Name} {doc.Surname}");
				Console.WriteLine($"Doctor types: {doc.DoctorType}\n");
			}
		}
	}

	public static class Program
	{
		public static void Main()
		{
			Console.WriteLine("Оберіть формат збереження даних:");
			foreach (var format in Enum.GetValues(typeof(SaveFormat)))
			{
				Console.WriteLine($"{(int)format}. {format}");
			}
			Console.Write("Ваш вибір: ");

			string? choice = Console.ReadLine();
			SaveFormat selectedFormat;

			while (true)
			{
				if (int.TryParse(choice, out int selectedValue) && Enum.IsDefined(typeof(SaveFormat), selectedValue))
				{
					selectedFormat = (SaveFormat)selectedValue;
					break;
				}
				else
				{
					Console.WriteLine("Невірний вибір. Спробуйте ще раз:");
					choice = Console.ReadLine();
				}
			}

			DoctorAppointment? doctorAppointment = null;

			switch (selectedFormat)
			{
				case SaveFormat.JSON:
					doctorAppointment = new DoctorAppointment(Constants.JsonAppSettingsPath, new JsonDataSerializerServices());
					break;

				case SaveFormat.XML:
					doctorAppointment = new DoctorAppointment(Constants.XmlAppSettingsPath, new XmlDataSerializerServices());
					break;
			}

			Console.WriteLine($"Вибрано формат: {selectedFormat}");

			//doctorAppointment.Menu();
		}
	}
}