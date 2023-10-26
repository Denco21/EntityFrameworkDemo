using DataAccessLibrary.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace EntityFrameworkSampleUI
{
	public class Program
	{
		static void Main(string[] args)
		{

			//CreatePerson();
			//ReadAllPeople();



			//ReadById(7);

			//FindPersonByName("Jonny", "Carlsson");

			//UpdatePersonFirstName(8, "John");

			//ReadAllPeople();

			//RemoveUserById(8);
			//ReadAllPeople();

			Console.WriteLine();


			Console.WriteLine("**************************************");
            Console.WriteLine(                                              );

            Console.WriteLine("End of program exercise EntityFramework");
            Console.ReadLine();
		}



		private static void CreatePerson()
		{
			var p = new People();

			{
				
				p.FirstName = "Jonny";
				p.LastName = "Carlsson";
			
			};

			p.HomeAddresses.Add(new HomeAddress
			{
				City = "Stockholm",
				StreetAddress = "Storgatan 1",
				State = "Sweden",
				ZipCode = "12345",
				Addresses = "Home"
				
			});

			p.Employers.Add(new EmployersAddress
			{
				City = "Stockholm",
				StreetAddress = "Adamsgatan 1",
				ZipCode = "44215",
				State = "Sweden",
				Addresses = "Work",
				CompanyName = "Samsung"
			});

			using( var db = new PeopleContext())
			{
				db.Peoples.Add(p);
				db.SaveChanges();
			}
		}

		private static void ReadAllPeople()
		{
			using ( var db = new PeopleContext())
			{
				var people = db.Peoples.ToList();

				foreach (var p in people)
				{

					Console.WriteLine($"{p.Id} {p.FirstName} {p.LastName}");

				}
			}
		}


		private static void ReadById(int id)
		{
			using (var db = new PeopleContext())
			{
				var person = db.Peoples
					.Include(p => p.HomeAddresses)
					.Include(p => p.Employers)
					
					.FirstOrDefault(x => x.Id == id);


				if (person != null)
				{

					Console.WriteLine($"ID:{person.Id} {person.FirstName} {person.LastName}");

					foreach (var address in person.HomeAddresses)
					{
						Console.WriteLine($"Lives at:{address.StreetAddress} {address.City} {address.State} {address.ZipCode} ({address.Addresses} address)");
					}

					foreach (var address in person.Employers)
					{
						Console.WriteLine($"Works at:{address.StreetAddress} {address.City} {address.State} {address.ZipCode},Company:{address.CompanyName} ({address.Addresses} address)");
					} 
				}
				else
				{
                    Console.WriteLine($"Ingen person med ID: {id} hittades.");
                }
			}
			

		}

		private static void FindPersonByName(string firstName, string lastName)
		{
			using (var db = new PeopleContext())
			{
				var person = db.Peoples.FirstOrDefault(x => x.FirstName == firstName && x.LastName == lastName);
			

			if (person != null)
			{
                Console.WriteLine($"Personen hittades: {person.Id} - {person.FirstName} {person.LastName} ");
            }

                else
                {
                    Console.WriteLine($"Ingen person med namnet: {firstName} {lastName} hittades.");
                }

            }
		}

		private static void UpdatePersonFirstName(int id, string firstName)
		{
			
			using (var db = new PeopleContext())
			{
				var person = db.Peoples.FirstOrDefault(x => x.Id == id);

				if (person != null)
				{
					person.FirstName = firstName;
					db.SaveChanges();
				}
			}


		}

		private static void RemoveUserById(int id)
		{
			using (var db = new PeopleContext())
			{
				var person = db.Peoples
					.Include(p => p.HomeAddresses)
					.Include(p => p.Employers)
                  .Where(x => x.Id == id).First();

				if (person != null)
				{
					db.Peoples.Remove(person);
					db.SaveChanges();
				}
			}
		}
	}
}