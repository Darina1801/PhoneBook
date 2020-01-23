using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;

namespace PhoneBook
{
	class Program
	{
		private const string FilePath = "C:\\Users\\Darina\\source\\repos\\PhoneBook\\PhoneBook\\PhoneBook.txt"; 
		static void Main(string[] args)
		{
			Welcome();
		}

		public static void Welcome()
		{
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("Welcome to your personal Phonebook!");
			Console.ForegroundColor = ConsoleColor.Blue;
			Console.WriteLine("To add new contact press - 1");
			Console.WriteLine("To find contact press - 2");
			Console.WriteLine("To display all contacts press - 3");
			Console.WriteLine("To exit press \"Esc\"");
			Console.ForegroundColor = ConsoleColor.White;
			Console.WriteLine("Your choice: ");

			UserAction();
		}

		public static void UserAction()
		{
			ConsoleKey userInput = Console.ReadKey().Key;

			if (userInput == ConsoleKey.Escape)
			{
				return;
			}
			else
			{
				if (userInput == ConsoleKey.D1)
				{
					Console.WriteLine();
					Console.WriteLine("Adding new contact...");
					Console.WriteLine();

					AddNewContact();
				}
				else
				{
					if (userInput == ConsoleKey.D2)
					{
						Console.WriteLine();
						Console.WriteLine("Finding contact...");
						Console.WriteLine();

						FindContact();
					}
					else
					{
						if (userInput == ConsoleKey.D3)
						{
							Console.WriteLine();
							Console.WriteLine("Contacts of Phonebook");
							Console.WriteLine();
							Console.WriteLine(File.ReadAllText(FilePath));
						}
						else
						{
							Console.WriteLine();
							Console.WriteLine("You can use only keys 1, 2, 3 and Esc");
							Console.WriteLine();
							Console.Clear();

							UserAction();
						}
					}
				}
			}
			Console.ReadLine();
		}

		static void AddNewContact()
		{
			Console.Clear();
			Console.ForegroundColor = ConsoleColor.DarkGreen;
			Console.WriteLine("Adding new contact...");
			Console.WriteLine();
			Console.WriteLine("Please Enter user information using following structure: ");
			Console.WriteLine();

			Contact newContact = new Contact();
			AddingNewContactFirstName(newContact);
		}

		static void AddingNewContactFirstName(Contact newContact)
		{
			Console.ForegroundColor = ConsoleColor.Blue;
			Console.WriteLine("First name: ");
			Console.ForegroundColor = ConsoleColor.White;
			string userInputFirstName = Console.ReadLine();
			Console.WriteLine();

			newContact.ContactFirstName = userInputFirstName;
			File.AppendAllText(FilePath, newContact.ContactFirstName + ".");
			AddingNewContactLastName(newContact); 
		}
	
		static void AddingNewContactLastName(Contact newContact)
		{
			Console.ForegroundColor = ConsoleColor.Blue;
			Console.WriteLine("Last name: ");
			Console.ForegroundColor = ConsoleColor.White;
			string userInputLastName = Console.ReadLine();
			Console.WriteLine();

			newContact.ContactLastName = userInputLastName;
			File.AppendAllText(FilePath, newContact.ContactLastName + ".");
			AddingNewContactPhoneNumber(newContact); 
		}

		static void AddingNewContactPhoneNumber(Contact newContact)
		{
			Console.ForegroundColor = ConsoleColor.Blue;
			Console.WriteLine("Phone number: ");
			Console.ForegroundColor = ConsoleColor.White;
			string userInputPhoneNumber = Console.ReadLine();
			Console.WriteLine();

			newContact.ContactPhoneNumber = userInputPhoneNumber;
			File.AppendAllText(FilePath, newContact.ContactPhoneNumber + ".");
			AddingNewContactSecondPhoneNumber(newContact); 
		}

		static void AddingNewContactSecondPhoneNumber(Contact newContact)
		{
			Console.ForegroundColor = ConsoleColor.DarkGreen;
			Console.WriteLine("Would you like to add second number to your new contact?");
			Console.WriteLine("1 - Yes");
			Console.WriteLine("2 - No");
			Console.ForegroundColor = ConsoleColor.White;
			Console.WriteLine();
			ConsoleKey userChoice = Console.ReadKey().Key;
			Console.WriteLine();

			if (userChoice == ConsoleKey.D1)
			{
				Console.ForegroundColor = ConsoleColor.Blue;
				Console.WriteLine("Second phone number: ");
				Console.ForegroundColor = ConsoleColor.White;
				string userInputPhoneNumber2 = Console.ReadLine();
				Console.WriteLine();

				newContact.ContactPhoneNumber2 = userInputPhoneNumber2;
				File.AppendAllText(FilePath, newContact.ContactPhoneNumber2 + ".");
				AddingNewContactEmaill(newContact); 
			}
			else
			{
				if (userChoice == ConsoleKey.D2)
				{
					AddingNewContactEmaill(newContact); 
				}
				else
				{
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine("You can use only keys 1 and 2!");
					Console.WriteLine();
					AddingNewContactSecondPhoneNumber(newContact);
				}
			}
		}

		static void AddingNewContactEmaill(Contact newContact)
		{
			Console.ForegroundColor = ConsoleColor.DarkGreen;
			Console.WriteLine("Would you like to add e-mail to your new contact?");
			Console.WriteLine("1 - Yes");
			Console.WriteLine("2 - No");
			Console.ForegroundColor = ConsoleColor.White;
			Console.WriteLine();
			ConsoleKey userChoice = Console.ReadKey().Key;
			Console.WriteLine();

			if (userChoice == ConsoleKey.D1)
			{
				Console.ForegroundColor = ConsoleColor.Blue;
				Console.WriteLine("E-mail: ");
				Console.ForegroundColor = ConsoleColor.White;
				string userInputEmail = Console.ReadLine();
				Console.WriteLine();

				newContact.ContactEmail = userInputEmail;
				File.AppendAllText(FilePath, newContact.ContactEmail + ".");
				AddingNewContactAdress(newContact);
			}
			else
			{
				if (userChoice == ConsoleKey.D2)
				{
					AddingNewContactAdress(newContact); 
				}
				else
				{
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine("You can use only keys 1 and 2!");
					Console.WriteLine();
				}
			}
		}

		static void AddingNewContactAdress(Contact newContact)
		{
			Console.ForegroundColor = ConsoleColor.DarkGreen;
			Console.WriteLine("Would you like to add adress to your new contact?");
			Console.WriteLine("1 - Yes");
			Console.WriteLine("2 - No");
			Console.ForegroundColor = ConsoleColor.White;
			Console.WriteLine();
			ConsoleKey userChoice = Console.ReadKey().Key;
			Console.WriteLine();

			if (userChoice == ConsoleKey.D1)
			{
				Console.ForegroundColor = ConsoleColor.Blue;
				Console.WriteLine("Adress: ");
				Console.ForegroundColor = ConsoleColor.White;
				string userInputAdress = Console.ReadLine();
				Console.WriteLine();

				newContact.ContactAdress = userInputAdress;
				File.AppendAllText(FilePath, newContact.ContactAdress + "." + "\n");

				Console.ForegroundColor = ConsoleColor.Blue;
				Console.WriteLine("Congratulations! You created new contact");
				Console.WriteLine("Would you like to add one more account?");
				Console.WriteLine("1 - Yes");
				Console.WriteLine("2 - No");
				Console.ForegroundColor = ConsoleColor.White;
				Console.WriteLine();
				ConsoleKey userChoice2 = Console.ReadKey().Key;
				Console.WriteLine();

				if (userChoice2 == ConsoleKey.D1)
				{
					AddNewContact();
				}
				else
				{
					if (userChoice2 == ConsoleKey.D2)
					{
						Welcome();
					}
					else
					{
						Console.ForegroundColor = ConsoleColor.Red;
						Console.WriteLine("You can use only keys 1 and 2!");
						Console.WriteLine();
					}
				}
			}
			else
			{
				File.AppendAllText(FilePath, "\n");
				if (userChoice == ConsoleKey.D2)
				{
					Console.ForegroundColor = ConsoleColor.Blue;
					Console.WriteLine("Congratulations! You created new contact");
					Console.WriteLine("Would you like to add one more account?");
					Console.WriteLine("1 - Yes");
					Console.WriteLine("2 - No");
					Console.ForegroundColor = ConsoleColor.White;
					Console.WriteLine();
					ConsoleKey userChoice3 = Console.ReadKey().Key;
					Console.WriteLine();

					if (userChoice3 == ConsoleKey.D1)
					{
						AddNewContact();
					}
					else
					{
						if (userChoice3 == ConsoleKey.D2)
						{
							Welcome();
						}
						else
						{
							Console.ForegroundColor = ConsoleColor.Red;
							Console.WriteLine("You can use only keys 1 and 2!");
							Console.WriteLine();
						}
					}
				}
			}
		}

		static void FindContact()
		{
			Console.ForegroundColor = ConsoleColor.Blue;
			Console.WriteLine("Enter contacts last name to find it: ");
			Console.ForegroundColor = ConsoleColor.White;
			string userInputFindLastName = Console.ReadLine();
			string[] contactsInFile = File.ReadAllLines(FilePath);
			if (contactsInFile.Length == 0)
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("Contact is not found");
			}
			else
			{
				foreach (string contactInFile in contactsInFile.Where(phoneBookContact =>
					phoneBookContact.Contains(userInputFindLastName)))
				{
					Console.ForegroundColor = ConsoleColor.White;
					Console.WriteLine(contactInFile);
				}
			}

			Console.ForegroundColor = ConsoleColor.DarkGreen;
			Console.WriteLine("What would you like to find another contact?");
			Console.WriteLine("1 - Yes");
			Console.WriteLine("2 - No");
			Console.ForegroundColor = ConsoleColor.White;
			Console.WriteLine();
			ConsoleKey userChoice = Console.ReadKey().Key;
			Console.WriteLine();

			if (userChoice == ConsoleKey.D1)
			{
				FindContact();
			}
			else
			{
				if (userChoice == ConsoleKey.D2)
				{
					Welcome();
				}
				else
				{
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine("You can use only keys 1 and 2!");
					Console.WriteLine();
				}
			}
		}
	}
}
