using System;
using System.Collections.Generic;

namespace LCSRemake
{
	class City
	{
		public string Cityname { get; }
		public List<Location> Locations { get; }

		public City()
		{
			this.Cityname = RandomCityName();
			this.Locations = new List<Location>();
		}

		public string RandomCityName()
		{
			Random random = new Random();

			switch (random.Next(20))
			{
				case 0: return "San Francisco, CA";
				case 1: return "Boston, MA";
				case 2: return "Los Angeles, CA";
				case 3: return "Detroit, MC";
				case 4: return "Cleveland, OH";
				case 5: return "Cincinnati, OH";
				case 6: return "New York, NY";
				case 7: return "Chicago, IL";
				case 8: return "Trenton, NJ";
				case 9: return "Denver, CO";
				case 10: return "Phoenix, AZ";
				case 11: return "Little Rock, AR";
				case 12: return "Houston, TX";
				case 13: return "Dallas, TX";
				case 14: return "Hartford, CT";
				case 15: return "Miami, FL";
				case 16: return "Baton Rouge, LA";
				case 17: return "Seattle, WA";
				case 18: return "Salt Lake City, UT";
				case 19: return "Philadelphia, PA";
			}
			return null;
		}
	}

	public class Location
	{
		public string Name { get; set; }
		public string Shortname { get; set; }
		public string Type { get; set; }
		public bool Needs_car { get; set; }
		public Faction Owner { get; set; }

		public Location(string name, string shortname, string type, bool needcar, Faction owner)
		{
			this.Name = name;
			this.Shortname = shortname;
			this.Type = type;
			this.Needs_car = needcar;
			this.Owner = owner;
		}

		public string RandomName(List<string> list)
		{
			Random random = new Random();
			string name = list[random.Next(0, list.Count)];
			return name;
		}

		public string RandomName(List<string> firstlist, List<string> secondlist)
        {
			Random random = new Random();
			string name = firstlist[random.Next(0, firstlist.Count)] + " " + secondlist[random.Next(0, secondlist.Count)];
			return name;
		}
	}

	public class Faction
	{
		public int Funds { get; set; }
		public string Slogan { get; set; }
		public List<Squad> Squads { get; }
		public Squad Activesquad { get; set; }
		public bool Disbanding { get; set; }
		public List<Entity> Pool { get; }

		public Faction()
		{
			this.Funds = 0;
			this.Slogan = "We need a slogan!";
			this.Squads = new List<Squad>();
			this.Pool = new List<Entity>();
			this.Disbanding = false;
		}
	};

	public class Squad
	{
		static int idcounter = 0;
		public int ID { get; }
		public string Name { get; set; }
		public List<Entity> Entities { get; }
		public Location Location { get; set; }

		public Squad()
		{
			this.ID = idcounter;
			idcounter++;
			this.Entities = new List<Entity>();
		}
	}

	public class Entity
	{
		public int ID { get; set; }
		static int idcounter = 0;

		public string Firstname { get; set; }
		public string Lastname { get; set; }
		public string Fullname { get; set; }
		public string Handle { get; set; }

		public int Strength { get; set; }
		public int Intelligence { get; set; }
		public int Wisdom { get; set; }
		public int Agility { get; set; }
		public int Health { get; set; }
		public int Charisma { get; set; }
		public int Heart { get; set; }

		public int Handtohand { get; set; }
		public int Knife { get; set; }
		public int Club { get; set; }
		public int Sword { get; set; }
		public int Axe { get; set; }
		public int Spear { get; set; }
		public int Pistol { get; set; }
		public int Rifle { get; set; }
		public int Assaultrifle { get; set; }
		public int Persuasion { get; set; }
		public int Law { get; set; }
		public int Security { get; set; }
		public int Disguise { get; set; }
		public int Computers { get; set; }
		public int Garmentmaking { get; set; }
		public int Driving { get; set; }
		public int Writing { get; set; }

		public int Juice { get; set; }

		public Weapon Weapon { get; set; }
		public Armour Armour { get; set; }
		public Location Mybase { get; set; }
		public Location Location { get; set; }
		public Location Worklocation { get; set; }
		public Entity Prisoner { get; set; }

		public Entity()
		{
			this.ID = idcounter;
			idcounter++;

			this.Firstname = Program.RandomFirstName();
			this.Lastname = Program.RandomLastName();
			this.Fullname = Firstname + " " + Lastname;

			this.Strength = 4;
			this.Intelligence = 1;
			this.Wisdom = 1;
			this.Agility = 4;
			this.Health = 4;
			this.Charisma = 0;
			this.Heart = 5;

			this.Handtohand = 0;
			this.Knife = 0;
			this.Club = 0;
			this.Sword = 0;
			this.Axe = 0;
			this.Spear = 0;
			this.Pistol = 0;
			this.Rifle = 0;
			this.Assaultrifle = 0;
			this.Persuasion = 0;
			this.Law = 0;
			this.Security = 0;
			this.Disguise = 0;
			this.Computers = 0;
			this.Garmentmaking = 0;
			this.Driving = 0;
			this.Writing = 0;

			this.Juice = 0;
		}
	}

	public class Weapon
	{
		public string Type { get; }
		public string Cliptype { get; }
		public Clip Ammo { get; set; }
		public bool Ranged { get; }

		public Weapon(string type, string cliptype, Clip ammo, bool ranged)
		{
			this.Type = type;
			this.Cliptype = cliptype;
			this.Ammo = ammo;
			this.Ranged = ranged;
		}
	};

	public class Clip
	{
		public string Type { get; }
		public int Amount { get; set; }

		public Clip(string type, int amount)
		{
			this.Type = type;
			this.Amount = amount;
		}
	}

	public class Armour
	{
		public string Type { get; }
		public int Quality { get; }
		public bool Damaged { get; set; }

		public Armour(string type, int quality)
		{
			this.Type = type;
			this.Quality = quality;
			this.Damaged = false;
		}
	};

	public class Date
    {
		public int Day { get; set; }
		public int Month { get; set; }
		public int Year { get; set; }

		public Date()
        {
			this.Day = 1;
			this.Month = 1;
			this.Year = 2005;
        }

		public void Advancetime()
        {
			if(this.Day == 30)
            {
				this.Day = 1;

				if(this.Month == 12)
                {
					this.Month = 1;
					this.Year += 1;
                }
				else
                {
					this.Month += 1;
                }
            }
			else
            {
				this.Day += 1;
            }
        }

		public string PrintDate()
        {
			string month = null;

			switch(this.Month)
            {
				case 1:
					month = "January";
					break;

				case 2:
					month = "February";
					break;

				case 3:
					month = "March";
					break;

				case 4:
					month = "April";
					break;

				case 5:
					month = "May";
					break;

				case 6:
					month = "June";
					break;

				case 7:
					month = "July";
					break;

				case 8:
					month = "August";
					break;

				case 9:
					month = "September";
					break;

				case 10:
					month = "October";
					break;

				case 11:
					month = "November";
					break;

				case 12:
					month = "December";
					break;
			}

			return this.Day.ToString() + " " + month + " " + this.Year.ToString();
        }
	}

	class Program
	{
		static Random random = new Random();
		static Date theDate = new Date();
		static City maincity = new City();
		static Faction liberals = new Faction();
		
		static public string RandomFirstName()
		{
			switch (random.Next(0, 100))
			{
				case 0: return "Ryan";
				case 1: return "Sergio";
				case 2: return "Laura";
				case 3: return "Anne";
				case 4: return "Bill";
				case 5: return "James";
				case 6: return "Marty";
				case 7: return "Jessica";
				case 8: return "Lisa";
				case 9: return "Bonita";
				case 10: return "Angel";
				case 11: return "Pat";
				case 12: return "Toshiro";
				case 13: return "Yan-ping";
				case 14: return "Tetsuo";
				case 15: return "Akira";
				case 16: return "Jimmy";
				case 17: return "Carlos";
				case 18: return "William";
				case 19: return "Billy Bob";
				case 20: return "Carol";
				case 21: return "Jenny";
				case 22: return "Jennifer";
				case 23: return "Manuela";
				case 24: return "Douglas";
				case 25: return "Kristin";
				case 26: return "Steven";
				case 27: return "Bonnie";
				case 28: return "Howard";
				case 29: return "Donald";
				case 30: return "Barry";
				case 31: return "Thomas";
				case 32: return "Joann";
				case 33: return "Derek";
				case 34: return "Gary";
				case 35: return "Archie";
				case 36: return "Mayumi";
				case 37: return "Felicia";
				case 38: return "Sherry";
				case 39: return "Judy";
				case 40: return "Elinor";
				case 41: return "Ned";
				case 42: return "Randy";
				case 43: return "Taylor";
				case 44: return "Kim";
				case 45: return "Ruthanne";
				case 46: return "Roger";
				case 47: return "Raymond";
				case 48: return "Harvey";
				case 49: return "Robert";
				case 50: return "Michael";
				case 51: return "Aaron";
				case 52: return "George";
				case 53: return "Noel";
				case 54: return "Adrienne";
				case 55: return "Lex";
				case 56: return "Linda";
				case 57: return "Chuck";
				case 58: return "Charlie";
				case 59: return "Charles";
				case 60: return "Malcolm";
				case 61: return "Martin";
				case 62: return "Sean";
				case 63: return "Raven";
				case 64: return "Wolf";
				case 65: return "Miguel";
				case 66: return "Pablo";
				case 67: return "Paul";
				case 68: return "Jesus";
				case 69: return "Ali";
				case 70: return "Ingrid";
				case 71: return "Kweisi";
				case 72: return "Susanna";
				case 73: return "Sharon";
				case 74: return "Marion";
				case 75: return "Kathy";
				case 76: return "Bruce";
				case 77: return "Dick";
				case 78: return "Phillip";
				case 79: return "Kirk";
				case 80: return "Kurt";
				case 81: return "John";
				case 82: return "Alexander";
				case 83: return "David";
				case 84: return "Beau";
				case 85: return "Elsie";
				case 86: return "Satya";
				case 87: return "Mumtaz";
				case 88: return "Diwakar";
				case 89: return "Dale";
				case 90: return "Woody";
				case 91: return "Ariel";
				case 92: return "Hans";
				case 93: return "Barbara";
				case 94: return "Jun";
				case 95: return "Rosemary";
				case 96: return "Chin-Yuan";
				case 97: return "Aiko";
				case 98: return "Vithara";
				case 99: return "Deepak";
			}
			return null;
		}

		static public string RandomLastName()
        {
			switch (random.Next(0, 100))
			{
				case 0: return "King";
				case 1: return "Lewis";
				case 2: return "Black";
				case 3: return "White";
				case 4: return "Ames";
				case 5: return "Warner";
				case 6: return "Simpson";
				case 7: return "Parker";
				case 8: return "Suave";
				case 9: return "Mifune";
				case 10: return "Gu";
				case 11: return "Bolger";
				case 12: return "Ross";
				case 13: return "Ramirez";
				case 14: return "Kurosawa";
				case 15: return "Johnson";
				case 16: return "Buchanan";
				case 17: return "Adamson";
				case 18: return "Hendrix";
				case 19: return "Rojo";
				case 20: return "Villa";
				case 21: return "Fields";
				case 22: return "Templeton";
				case 23: return "Ivanson";
				case 24: return "Blitzer";
				case 25: return "Muhammed";
				case 26: return "Stone";
				case 27: return "Cho";
				case 28: return "Childress";
				case 29: return "Africa";
				case 30: return "Balgos";
				case 31: return "Baird";
				case 32: return "Bailey";
				case 33: return "Diaz";
				case 34: return "Decker";
				case 35: return "Ericson";
				case 36: return "Loeb";
				case 37: return "Meffert";
				case 38: return "McLeod";
				case 39: return "Tucker";
				case 40: return "Takayoshi";
				case 41: return "Tanner";
				case 42: return "Lipman";
				case 43: return "Little";
				case 44: return "Logsdon";
				case 45: return "Krasow";
				case 46: return "Krieger";
				case 47: return "Dahmer";
				case 48: return "Gacy";
				case 49: return "Krishna";
				case 50: return "la Russa";
				case 51: return "Savedra";
				case 52: return "Scardino";
				case 53: return "Keitel";
				case 54: return "Wallace";
				case 55: return "Buckman";
				case 56: return "Fulsom";
				case 57: return "Smith";
				case 58: return "Venus";
				case 59: return "Straley";
				case 60: return "Purcell";
				case 61: return "al Fadil";
				case 62: return "Storm";
				case 63: return "Patterson";
				case 64: return "Pelton";
				case 65: return "Ng";
				case 66: return "Filler";
				case 67: return "Buttman";
				case 68: return "Fingleton";
				case 69: return "Fenoglio";
				case 70: return "de la Cruz";
				case 71: return "Delgado";
				case 72: return "Hatcher";
				case 73: return "Jameson";
				case 74: return "Franklin";
				case 75: return "Washington";
				case 76: return "Jefferson";
				case 77: return "Strossen";
				case 78: return "Hannemann";
				case 79: return "Hammond";
				case 80: return "Logan";
				case 81: return "Hutchison";
				case 82: return "Jimison";
				case 83: return "Sawyer";
				case 84: return "Santiago";
				case 85: return "Rudkin";
				case 86: return "Bump";
				case 87: return "Simon";
				case 88: return "Davis";
				case 89: return "Reagan";
				case 90: return "Bush";
				case 91: return "Bradshaw";
				case 92: return "Yamaguchi";
				case 93: return "Roy";
				case 94: return "Colt";
				case 95: return "Rothstein";
				case 96: return "Spears";
				case 97: return "Lopez";
				case 98: return "Aguilera";
				case 99: return "Carey";
			}
			return null;
        }

		static void CharacterCreation()
		{
			Location newlocation;
			Squad newsquad = new Squad();
			Entity newcharacter = new Entity();

			for (int q = 0; q < 10; q++)
			{
				Console.Clear();
				Border();

				Console.SetCursorPosition(4, 2);
				Console.WriteLine("Insight into a Revolution:  My Traumatic Childhood");

				switch (q)
				{
					case 0:
						Console.SetCursorPosition(4, 4); Console.WriteLine("The day I was born in 1984...");
						Console.SetCursorPosition(4, 6); Console.WriteLine("A - was the day the Sandinista Front won the elections in Nicaragua.");
						Console.SetCursorPosition(4, 8); Console.WriteLine("B - was the 3rd anniversary of the assassination attempt on Ronald Reagan.");
						Console.SetCursorPosition(4, 10); Console.WriteLine("C - was the day the Macintosh was introduced.");

						Console.SetCursorPosition(4, 14);
						Console.WriteLine("My parents named me " + newcharacter.Fullname + ".");
						break;

					case 1:
						Console.SetCursorPosition(4, 4); Console.WriteLine("When I was bad...");
						Console.SetCursorPosition(4, 6); Console.WriteLine("A - my parents argued with each other about me, but I was never punished.");
						Console.SetCursorPosition(4, 8); Console.WriteLine("B - my father beat me.  I learned to take a punch earlier than most.");
						Console.SetCursorPosition(4, 10); Console.WriteLine("C - I was sent to my room, where I studied quietly by myself, alone.");
						break;

					case 2:
						Console.SetCursorPosition(4, 4); Console.WriteLine("In elementary school...");
						Console.SetCursorPosition(4, 6); Console.WriteLine("A - I was the class clown.  I even had some friends.");
						Console.SetCursorPosition(4, 8); Console.WriteLine("B - I was unruly and often fought with the other children.");
						Console.SetCursorPosition(4, 10); Console.WriteLine("C - I was at the head of the class, and I worked very hard.");
						break;

					case 3:
						Console.SetCursorPosition(4, 4); Console.WriteLine("When I turned 10...");
						Console.SetCursorPosition(4, 6); Console.WriteLine("A - my parents divorced.  Acrimoniously.  I once tripped over the paperwork!");
						Console.SetCursorPosition(4, 8); Console.WriteLine("B - my parents divorced.  Violently.");
						Console.SetCursorPosition(4, 10); Console.WriteLine("C - my parents divorced.  My studies suffered but I continued working.");
						break;

					case 4:
						Console.SetCursorPosition(4, 4); Console.WriteLine("When I hit junior high school...");
						Console.SetCursorPosition(4, 6); Console.WriteLine("A - I broke into lockers and was into punk rock.");
						Console.SetCursorPosition(4, 8); Console.WriteLine("B - I was into knives and broke things with bats.  My anger was unmanaged.");
						Console.SetCursorPosition(4, 10); Console.WriteLine("C - I got into chess and go.  I was a total outcast.");
						break;

					case 5:
						Console.SetCursorPosition(4, 4); Console.WriteLine("Things were getting really bad...");
						Console.SetCursorPosition(4, 6); Console.WriteLine("A - when I stole my first car.  I got a few blocks before I totalled it.");
						Console.SetCursorPosition(4, 8); Console.WriteLine("B - and I went to live with my dad.  He had been in Nam and he still drank.");
						Console.SetCursorPosition(4, 10); Console.WriteLine("C - and I went completely goth.  I had no friends and made costumes by myself.");
						break;

					case 6:
						Console.SetCursorPosition(4, 4); Console.WriteLine("Well, you know it has reached a crescendo when...");
						Console.SetCursorPosition(4, 6); Console.WriteLine("A - you steal a cop car and you're only 14.  I went to juvie for 6 months.");
						Console.SetCursorPosition(4, 8); Console.WriteLine("B - your mom shoots her ex-husband, your dad, with a shotgun.  She got off.");
						Console.SetCursorPosition(4, 10); Console.WriteLine("C - you try sports for a quarter, desperate to fit in.");
						break;

					case 7:
						Console.SetCursorPosition(4, 4); Console.WriteLine("I was only 15 when I ran away, and...");
						Console.SetCursorPosition(4, 6); Console.WriteLine("A - I started robbing houses:  rich people only.  I was fed up with their crap.");
						Console.SetCursorPosition(4, 8); Console.WriteLine("B - Hung out with thugs and beat the shit out of people.");
						Console.SetCursorPosition(4, 10); Console.WriteLine("C - volunteered for a left-wing candidate.  It wasn't *real*, though, you know?");
						break;

					case 8:
						Console.SetCursorPosition(4, 4); Console.WriteLine("Life went on.  For my 18th birthday...");
						Console.SetCursorPosition(4, 6); Console.WriteLine("A - I stole a security uniform.");
						Console.SetCursorPosition(4, 8); Console.WriteLine("B - I bought myself an assault rifle.");
						Console.SetCursorPosition(4, 10); Console.WriteLine("C - I celebrated.  I'd saved a thousand bucks!");
						break;

					case 9:
						Console.SetCursorPosition(4, 4); Console.WriteLine("For the past few years, I've been...");
						Console.SetCursorPosition(4, 6); Console.WriteLine("A - stealing from Corporations, but I want to do more.");
						Console.SetCursorPosition(4, 8); Console.WriteLine("B - a violent criminal.  Nothing can change that.");
						Console.SetCursorPosition(4, 10); Console.WriteLine("C - volunteering for prominent liberals, but I know there's a better way.");

						Console.SetCursorPosition(4, 14); Console.WriteLine("I live in " + maincity.Cityname + ", and it's about to experience real change.");
						break;
				}

				char keyinput;

				do
				{
					keyinput = Console.ReadKey(true).KeyChar;
				} 
				while (keyinput != 'a' && keyinput != 'b' && keyinput != 'c');

				switch (q)
				{
					case 0:
						if (keyinput == 'a')
						{
							newcharacter.Charisma += 2;
							newcharacter.Heart += 1;
							newcharacter.Persuasion += 2;
						}
						if (keyinput == 'b')
						{
							newcharacter.Strength += 1;
							newcharacter.Agility += 1;
							newcharacter.Health += 1;
							newcharacter.Pistol += 2;
						}
						if (keyinput == 'c')
						{
							newcharacter.Intelligence += 3;
							newcharacter.Computers += 2;
						}
						break;

					case 1:
						if (keyinput == 'a')
						{
							newcharacter.Charisma += 1;
							newcharacter.Persuasion += 2;
						}
						if (keyinput == 'b')
						{
							newcharacter.Health += 1;
							newcharacter.Strength += 1;
							newcharacter.Handtohand += 1;
						}
						if (keyinput == 'c')
						{
							newcharacter.Intelligence += 1;
							newcharacter.Writing += 1;
							newcharacter.Computers += 1;
						}
						break;

					case 2:
						if (keyinput == 'a')
						{
							newcharacter.Charisma += 1;
							newcharacter.Persuasion += 2;
						}
						if (keyinput == 'b')
						{
							newcharacter.Strength += 1;
							newcharacter.Agility += 1;
							newcharacter.Handtohand += 1;
						}
						if (keyinput == 'c')
						{
							newcharacter.Intelligence += 1;
							newcharacter.Writing += 1;
							newcharacter.Computers += 1;
						}
						break;

					case 3:
						if (keyinput == 'a')
						{
							newcharacter.Intelligence += 1;
							newcharacter.Writing += 1;
							newcharacter.Law += 1;
						}
						if (keyinput == 'b')
						{
							newcharacter.Strength += 1;
							newcharacter.Agility += 1;
							newcharacter.Club += 1;
						}
						if (keyinput == 'c')
						{
							newcharacter.Intelligence += 2;
							newcharacter.Computers += 1;
						}
						break;

					case 4:
						if (keyinput == 'a')
						{
							newcharacter.Charisma += 1;
							newcharacter.Security += 1;
						}
						if (keyinput == 'b')
						{
							newcharacter.Knife += 1;
							newcharacter.Club += 1;
						}
						if (keyinput == 'c')
						{
							newcharacter.Intelligence += 2;
						}
						break;

					case 5:
						if (keyinput == 'a')
						{
							newcharacter.Intelligence += 1;
							newcharacter.Driving += 1;
							newcharacter.Security += 1;
						}
						if (keyinput == 'b')
						{
							newcharacter.Agility += 1;
							newcharacter.Rifle += 1;
							newcharacter.Assaultrifle += 1;
						}
						if (keyinput == 'c')
						{
							newcharacter.Disguise += 2;
							newcharacter.Garmentmaking += 1;
						}
						break;

					case 6:
						if (keyinput == 'a')
						{
							newcharacter.Driving += 1;
							newcharacter.Security += 2;
						}
						if (keyinput == 'b')
						{
							newcharacter.Rifle += 1;
							newcharacter.Assaultrifle += 1;
							newcharacter.Pistol += 1;
						}
						if (keyinput == 'c')
						{
							newcharacter.Strength += 1;
							newcharacter.Agility += 2;
						}
						break;

					case 7:
						if (keyinput == 'a')
						{
							newcharacter.Intelligence += 1;
							newcharacter.Security += 1;
							newcharacter.Disguise += 1;
						}
						if (keyinput == 'b')
						{
							newcharacter.Strength += 1;
							newcharacter.Health += 1;
							newcharacter.Handtohand += 1;
						}
						if (keyinput == 'c')
						{
							newcharacter.Heart += 1;
							newcharacter.Law += 1;
							newcharacter.Persuasion += 1;
						}
						break;

					case 8:
						if (keyinput == 'a')
						{
							newcharacter.Armour = new Armour("securityuniform", 1);
						}
						if (keyinput == 'b')
						{
							newcharacter.Weapon = new Weapon("semirifleak47", "assault", new Clip("assault", 9), true);
						}
						if (keyinput == 'c')
						{
							liberals.Funds = 1000;
						}
						break;

					case 9:
						if (keyinput == 'a')
						{
							newcharacter.Intelligence += 2;
							newcharacter.Agility += 2;
							newcharacter.Health += 1;
							newcharacter.Disguise += 2;
							newcharacter.Security += 2;
							newcharacter.Driving += 1;
						}
						if (keyinput == 'b')
						{
							newcharacter.Agility += 2;
							newcharacter.Strength += 1;
							newcharacter.Health += 2;
							newcharacter.Rifle += 1;
							newcharacter.Assaultrifle += 1;
							newcharacter.Pistol += 1;
							newcharacter.Knife += 1;
							newcharacter.Club += 1;
						}
						if (keyinput == 'c')
						{
							newcharacter.Intelligence += 2;
							newcharacter.Heart += 2;
							newcharacter.Health += 1;
							newcharacter.Law += 2;
							newcharacter.Writing += 2;
							newcharacter.Persuasion += 1;
						}
						break;
				}
			}

			Console.Clear();
			Border();
			Console.SetCursorPosition(4, 2);
			Console.Write("What is your name to the People?");
			Console.SetCursorPosition(4, 3);

			string nameinput = Console.ReadLine();

			if (nameinput == null)
            {
				newcharacter.Handle = newcharacter.Fullname;
            }
            else
            {
				newcharacter.Handle = nameinput;
			}

			newlocation = new Location("Downtown", "Downtown", "downtown", false, null);
			maincity.Locations.Add(newlocation);

			newlocation = new Location("The University District", "U-District", "unidistrict", false, null);
			maincity.Locations.Add(newlocation);

			newlocation = new Location("The Industrial District", "I-District", "inddistrict", false, null);
			maincity.Locations.Add(newlocation);

			newlocation = new Location("On the Outskirts of the City", "Outskirts", "outskirts", true, null);
			maincity.Locations.Add(newlocation);

			newlocation = new Location("Police Station", "Police Station", "policestation", false, null);
			maincity.Locations.Add(newlocation);

			newlocation = new Location("Court House", "Court House", "courthouse", false, null);
			maincity.Locations.Add(newlocation);

			newlocation = new Location(RandomLastName() + " Prison", "Prison", "prison", true, null);
			maincity.Locations.Add(newlocation);

			newlocation = new Location("Nuclear Power Plant", "NPower Plant", "nuclear", true, null);
			maincity.Locations.Add(newlocation);

			newlocation = new Location("Intelligence HQ", "Int. HQ", "intelligencehq", true, null);
			maincity.Locations.Add(newlocation);

			newlocation = new Location("Corporate HQ", "Corp. HQ", "corporatehq", true, null);
			maincity.Locations.Add(newlocation);

			newlocation = new Location("CEO Residence", "CEO House", "corporatehouse", true, null);
			maincity.Locations.Add(newlocation);

			newlocation = new Location("Homeless Shelter", "Shelter", "shelter", false, null);
			maincity.Locations.Add(newlocation);

			newlocation = new Location(null, null, "warehouse", false, null);
			newlocation.RandomName(new List<string> { "Meat Plant", "Warehouse", "Paper Mill", "Cement Factory", "Fertilizer Plant" });
			maincity.Locations.Add(newlocation);

			newlocation = new Location(null, null, "warehouse", false, null);
			newlocation.RandomName(new List<string> { "Meat Plant", "Warehouse", "Paper Mill", "Cement Factory", "Fertilizer Plant" });
			maincity.Locations.Add(newlocation);

			newlocation = new Location(null, null, "warehouse", false, null);
			newlocation.RandomName(new List<string> { "Meat Plant", "Warehouse", "Paper Mill", "Cement Factory", "Fertilizer Plant" });
			maincity.Locations.Add(newlocation);

			newlocation = new Location(null, null, "polluter", false, null);
			newlocation.RandomName(new List<string> { "Aluminum Factory", "Plastic Factory", "Oil Refinery", "Auto Plant", "Chemical Factory" });
			maincity.Locations.Add(newlocation);

			newlocation = new Location(null, null, "polluter", false, null);
			newlocation.RandomName(new List<string> { "Aluminum Factory", "Plastic Factory", "Oil Refinery", "Auto Plant", "Chemical Factory" });
			maincity.Locations.Add(newlocation);

			newlocation = new Location(null, null, "polluter", false, null);
			newlocation.RandomName(new List<string> { "Aluminum Factory", "Plastic Factory", "Oil Refinery", "Auto Plant", "Chemical Factory" });
			maincity.Locations.Add(newlocation);

			newlocation = new Location("Cable News Station", "News Station", "cablenews", false, null);
			maincity.Locations.Add(newlocation);

			newlocation = new Location("AM Radio Station", "Radio Station", "amradio", false, null);
			maincity.Locations.Add(newlocation);

			string randomname = RandomLastName();
			newlocation = new Location(randomname + " Apartments", randomname + " Apts", "upscaleapt", false, null);
			maincity.Locations.Add(newlocation);

			randomname = RandomLastName();
			newlocation = new Location(randomname + " Apartments", randomname + " Apts", "upscaleapt", false, null);
			maincity.Locations.Add(newlocation);

			randomname = RandomLastName();
			newlocation = new Location(randomname + " Apartments", randomname + " Apts", "apt", false, null);
			maincity.Locations.Add(newlocation);

			randomname = RandomLastName();
			newlocation = new Location(randomname + " Apartments", randomname + " Apts", "apt", false, null);
			maincity.Locations.Add(newlocation);

			randomname = RandomLastName();
			newlocation = new Location(randomname + " Apartments", randomname + " Apts", "tenement", false, null);
			maincity.Locations.Add(newlocation);

			randomname = RandomLastName();
			newlocation = new Location(randomname + " Apartments", randomname + " Apts", "tenement", false, null);
			maincity.Locations.Add(newlocation);

			newlocation = new Location("The University Hospital", "U Hospital", "hospitaluni", false, null);
			maincity.Locations.Add(newlocation);

			newlocation = new Location("The Free CLINIC", "CLINIC", "hospitalclinic", false, null);
			maincity.Locations.Add(newlocation);

			newlocation = new Location(Program.RandomLastName() + " Genetics", "Genetics Lab", "labgenetic", false, null);
			maincity.Locations.Add(newlocation);

			newlocation = new Location(Program.RandomLastName() + " Cosmetics", "Cosmetics Lab", "labcosmetics", false, null);
			maincity.Locations.Add(newlocation);

			newlocation = new Location(Program.RandomLastName() + " Cash & Loans", "Pawnshop", "pawnshop", false, null);
			maincity.Locations.Add(newlocation);

			newlocation = new Location(Program.RandomLastName() + "'s Department Store", "Dept. Store", "deptstore", false, null);
			maincity.Locations.Add(newlocation);

			newlocation = new Location("The Oubliette", "Oubliette", "halloween", false, null);
			maincity.Locations.Add(newlocation);

			newlocation = new Location(Program.RandomLastName() + " Garment Makers", "Sweatshop", "sweatshop", false, null);
			maincity.Locations.Add(newlocation);

			newlocation = new Location(Program.RandomLastName() + " Garment Makers", "Sweatshop", "sweatshop", false, null);
			maincity.Locations.Add(newlocation);

			newlocation = new Location(Program.RandomLastName() + " St. Crack House", "Crack House", "crackhouse", false, null);
			maincity.Locations.Add(newlocation);

			newlocation = new Location(Program.RandomLastName() + " St. Crack House", "Crack House", "crackhouse", false, null);
			maincity.Locations.Add(newlocation);

			newlocation = new Location(Program.RandomLastName() + " St. Crack House", "Crack House", "crackhouse", false, null);
			maincity.Locations.Add(newlocation);

			newlocation = new Location(null, "Vegan Co-op", "vegancoop", false, null);
			newlocation.RandomName(new List<string> { "Asparagus", "Tofu", "Broccoli", "Radish", "Eggplant" }, new List<string> { "Forest", "Rainbow", "Garden", "Farm", "Meadow" });
			maincity.Locations.Add(newlocation);

			newlocation = new Location(null, "Juice Bar", "juicebar", false, null);
			newlocation.RandomName(new List<string> { "Natural", "Harmonious", "Restful", "Healthy", "New You" }, new List<string> { "Diet", "Methods", "Plan", "Orange", "Carrot" });
			maincity.Locations.Add(newlocation);

			newlocation = new Location(null, "Net Cafe", "internetcafe", false, null);
			newlocation.RandomName(new List<string> { "Electric", "Wired", "Nano", "Micro", "Techno" }, new List<string> { "Panda", "Troll", "Latte", "Unicorn", "Pixie" });
			maincity.Locations.Add(newlocation);

			newlocation = new Location("The " + Program.RandomLastName() + " Gentlemen's Club", "Cigar Bar", "cigarbar", false, null);
			maincity.Locations.Add(newlocation);

			newlocation = new Location(null, "Latte Stand", "lattestand", false, null);
			newlocation.RandomName(new List<string> { "Frothy", "Milky", "Caffine", "Morning", "Evening" }, new List<string> { "Mug", "Cup", "Jolt", "Wonder", "Express" });
			maincity.Locations.Add(newlocation);

			newlocation = new Location(null, "Latte Stand", "lattestand", false, null);
			newlocation.RandomName(new List<string> { "Frothy", "Milky", "Caffine", "Morning", "Evening" }, new List<string> { "Mug", "Cup", "Jolt", "Wonder", "Express" });
			maincity.Locations.Add(newlocation);

			newsquad.Entities.Add(newcharacter);
			newsquad.Name = "The Liberal Crime Squad";

			for (int i = 0; i < maincity.Locations.Count; i++)
			{
				if (maincity.Locations[i].Type == "shelter")
				{
					newcharacter.Mybase = maincity.Locations[i];
					newcharacter.Location = maincity.Locations[i];
					newsquad.Location = maincity.Locations[i];
					break;
				}
			}

			liberals.Squads.Add(newsquad);
			liberals.Activesquad = newsquad;

			Mode_base();
		}

		static void Border()
		{
			for (int x = 2; x < Console.BufferWidth; x++)
			{
				Console.SetCursorPosition(x, 0);
				Console.Write("\u2588");
			}

			for (int x = 2; x < Console.BufferWidth; x++)
			{
				Console.SetCursorPosition(x, Console.BufferHeight - 2);
				Console.Write("\u2588");
			}

			for (int y = 1; y < Console.BufferHeight - 2; y++)
			{
				Console.SetCursorPosition(2, y);
				Console.Write("\u2588");
			}

			for (int y = 1; y < Console.BufferHeight - 2; y++)
			{
				Console.SetCursorPosition(Console.BufferWidth - 1, y);
				Console.Write("\u2588");
			}
		}

		static void Mode_title()
		{
			Console.Clear();
			Border();

			string str = "Liberal Crime Squad";
			Console.SetCursorPosition((Console.BufferWidth / 2) - (str.Length / 2), 4);
			Console.WriteLine(str);

			str = "Inspired by the 1983 version of Oubliette";
			Console.SetCursorPosition((Console.BufferWidth / 2) - (str.Length / 2), 6);
			Console.WriteLine(str);

			str = "v3.06 Copyright (C) 2002-4, Tarn Adams";
			Console.SetCursorPosition((Console.BufferWidth / 2) - (str.Length / 2), 13);
			Console.WriteLine(str);

			str = "A Bay 12 Games Production";
			Console.SetCursorPosition((Console.BufferWidth / 2) - (str.Length / 2), 14);
			Console.WriteLine(str);

			str = "www.bay12games.com";
			Console.SetCursorPosition((Console.BufferWidth / 2) - (str.Length / 2), 15);
			Console.WriteLine(str);

			str = "Press ESC now to quit.  Quitting later causes your progress to be saved.";
			Console.SetCursorPosition((Console.BufferWidth / 2) - (str.Length / 2), 20);
			Console.WriteLine(str);

			str = "Press any other key to pursue your Liberal Agenda!";
			Console.SetCursorPosition((Console.BufferWidth / 2) - (str.Length / 2), 22);
			Console.WriteLine(str);

			if (Console.ReadKey().Key == ConsoleKey.Escape)
			{
				return;
			}

			CharacterCreation();
		}

		static void Mode_base()
        {
			Console.Clear();
			Border();
			Console.SetCursorPosition(4, 2);
			Console.Write(liberals.Activesquad.Location.Name + ", " + theDate.PrintDate());

			string activity = "Hanging Out";
			Console.SetCursorPosition((Console.BufferWidth / 2) - (activity.Length / 2), 2);
			Console.Write(activity);

			Console.SetCursorPosition(Console.BufferWidth - 10, 2);
			Console.Write("$" + liberals.Funds);

			Console.SetCursorPosition(4 ,3);
			Console.Write("#-CODE NAME------------SKILL------------WEAPON------------ARMOUR------------HEALTH------------TRANSPORT----------#");
			Console.ReadKey();
		}

		static void Main(string[] args)
		{
			Console.SetWindowSize(120, 30);
			Console.SetBufferSize(120, 30);
			Console.CursorVisible = false;

			Mode_title();
		}
	}
}
