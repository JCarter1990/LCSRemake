using System;
using System.Collections.Generic;

namespace LCSRemake
{
	public class Clip
	{
		string type;
		int holds;

		public Clip(string type, int holds)
		{
			this.type = type;
			this.holds = holds;
		}
	}

	public class Weapon
	{
		string type;
		Clip clip;
		int ammo;
		bool ranged;

		public Weapon(string type, Clip clip, int ammo, bool ranged)
		{
			this.type = type;
			this.clip = clip;
			this.ammo = ammo;
			this.ranged = ranged;
		}
	};

	public class Armour
	{
		string type;
		string subtype;
		int quality;
		int flag;

		public Armour(string type, string subtype, int quality, int flag)
		{
			this.type = type;
			this.subtype = subtype;
			this.quality = quality;
			this.flag = flag;
		}

		public Armour(string type, int quality, int flag)
		{
			this.type = type;
			this.quality = quality;
			this.flag = flag;
		}
	};

	public class Faction
	{
		int funds;
		string slogan;
		List<Squad> squads;
		Squad activesquad;

		public Faction()
		{
			this.funds = 0;
			this.slogan = "We need a slogan!";
			this.squads = new List<Squad>();
		}

		public int AccessFunds
		{
			get
			{
				return this.funds;
			}
			set
			{
				this.funds = value;
			}
		}

		public List<Squad> GetSquads()
		{
			return this.squads;
		}

		public void AddSquad(Squad squad)
		{
			this.squads.Add(squad);
		}

		public void RemoveSquad(Squad squad)
		{
			this.squads.Remove(squad);
		}

		public void SetActive(Squad squad)
		{
			this.activesquad = squad;
		}
	};

	public class Squad
    {
		static int idcounter = 0;
		int id;
		string name;
		List<Entity> entities;

		public Squad()
        {
			this.id = idcounter;
			idcounter++;
			this.entities = new List<Entity>();
        }

		public void AddMember(Entity entity)
        {
			this.entities.Add(entity);
        }

		public void RemoveMember(Entity entity)
        {
			this.entities.Remove(entity);
        }

		public int GetID()
        {
			return this.id;
        }

		public string Name
		{
			get
			{
				return this.name;
			}

			set
			{
				this.name = value;
			}
		}
	}

	public class Entity
	{
		int squadid;

		string firstname;
		string lastname;
		string fullname;
		string handle;

		int strength;
		int intelligence;
		int wisdom;
		int agility;
		int health;
		int charisma;
		int heart;

		int handtohand;
		int knife;
		int club;
		int sword;
		int axe;
		int spear;
		int pistol;
		int rifle;
		int assaultrifle;
		int persuasion;
		int law;
		int security;
		int disguise;
		int computers;
		int garmentmaking;
		int driving;
		int writing;

		int juice;

		Weapon weapon;
		Armour armour;

		Location mybase;
		Location location;

		public Entity()
		{
			this.firstname = Program.RandomFirstName();
			this.lastname = Program.RandomLastName();
			this.fullname = firstname + " " + lastname;
			this.handle = firstname;

			this.strength = 4;
			this.intelligence = 1;
			this.wisdom = 1;
			this.agility = 4;
			this.health = 4;
			this.charisma = 0;
			this.heart = 5;

			this.handtohand = 0;
			this.knife = 0;
			this.club = 0;
			this.sword = 0;
			this.axe = 0;
			this.spear = 0;
			this.pistol = 0;
			this.rifle = 0;
			this.assaultrifle = 0;
			this.persuasion = 0;
			this.law = 0;
			this.security = 0;
			this.disguise = 0;
			this.computers = 0;
			this.garmentmaking = 0;
			this.driving = 0;
			this.writing = 0;

			this.juice = 0;
		}

		public int SquadID
		{
			get
			{
				return this.squadid;
			}

			set
			{
				this.squadid = value;
			}
		}

		public string FirstName
		{
			get
			{
				return this.firstname;
			}

			set
            {
				this.firstname = value;
            }
		}

		public string LastName
		{
			get
			{
				return this.lastname;
			}

			set
			{
				this.lastname = value;
			}
		}

		public string FullName
		{
			get
			{
				return this.fullname;
			}
		}

		public string Handle
		{
			get
			{
				return this.handle;
			}

			set
			{
				this.handle = value;
			}
		}

		public void AttributeInc(string att, int incby)
		{
			switch (att)
			{
				case "strength":
					this.strength += incby;
					break;

				case "intelligence":
					this.intelligence += incby;
					break;

				case "wisdom":
					this.wisdom += incby;
					break;

				case "agility":
					this.agility += incby;
					break;

				case "health":
					this.health += incby;
					break;

				case "charisma":
					this.charisma += incby;
					break;

				case "heart":
					this.heart += incby;
					break;
			}
		}

		public void SkillInc(string skill, int incby)
		{
			switch (skill)
			{
				case "handtohand":
					this.handtohand += incby;
					break;

				case "knife":
					this.knife += incby;
					break;

				case "club":
					this.club += incby;
					break;

				case "sword":
					this.sword += incby;
					break;

				case "axe":
					this.axe += incby;
					break;

				case "spear":
					this.spear += incby;
					break;

				case "pistol":
					this.pistol += incby;
					break;

				case "rifle":
					this.rifle += incby;
					break;

				case "assaultrifle":
					this.assaultrifle += incby;
					break;

				case "persuasion":
					this.persuasion += incby;
					break;

				case "law":
					this.law += incby;
					break;

				case "security":
					this.security += incby;
					break;

				case "disguise":
					this.disguise += incby;
					break;

				case "computers":
					this.computers += incby;
					break;

				case "garmentmaking":
					this.garmentmaking += incby;
					break;

				case "driving":
					this.driving += incby;
					break;

				case "writing":
					this.writing += incby;
					break;
			}
		}

		public Weapon AccessWeapon
		{
			get
			{
				return this.weapon;
			}
			set
			{
				this.weapon = value;
			}
		}

		public Armour AccessArmour
		{
			get
			{
				return this.armour;
			}
			set
			{
				this.armour = value;
			}
		}

		public Location AccessBase
		{
			get
			{
				return this.mybase;
			}
			set
			{
				this.mybase = value;
			}
		}

		public Location AccessLocation
		{
			get
			{
				return this.location;
			}
			set
			{
				this.location = value;
			}
		}
	}

	class City
    {
		string cityname;
		List<Location> locations;

		public City()
        {
			RandomCityName();
			this.locations = new List<Location>();
        }

		public string GetName()
        {
			return this.cityname;
        }

		public List<Location> GetLocations()
        {
			return this.locations;
        }

		public void AddLocation(Location location)
		{
			this.locations.Add(location);
		}

		public void RemoveLocation(Location location)
		{
			this.locations.Remove(location);
		}

		public void RandomCityName()
		{
			Random random = new Random();

			switch (random.Next(20))
			{
				case 0: this.cityname = "San Francisco, CA"; break;
				case 1: this.cityname = "Boston, MA"; break;
				case 2: this.cityname = "Los Angeles, CA"; break;
				case 3: this.cityname = "Detroit, MC"; break;
				case 4: this.cityname = "Cleveland, OH"; break;
				case 5: this.cityname = "Cincinnati, OH"; break;
				case 6: this.cityname = "New York, NY"; break;
				case 7: this.cityname = "Chicago, IL"; break;
				case 8: this.cityname = "Trenton, NJ"; break;
				case 9: this.cityname = "Denver, CO"; break;
				case 10: this.cityname = "Phoenix, AZ"; break;
				case 11: this.cityname = "Little Rock, AR"; break;
				case 12: this.cityname = "Houston, TX"; break;
				case 13: this.cityname = "Dallas, TX"; break;
				case 14: this.cityname = "Hartford, CT"; break;
				case 15: this.cityname = "Miami, FL"; break;
				case 16: this.cityname = "Baton Rouge, LA"; break;
				case 17: this.cityname = "Seattle, WA"; break;
				case 18: this.cityname = "Salt Lake City, UT"; break;
				case 19: this.cityname = "Philadelphia, PA"; break;
			}
		}
	}

	public class Location
    {
		string name;
		string shortname;
		string conservativename;
		string conservativeshortname;
		string type;
		int parent;
		bool needcar;
		bool renting;

		public Location(string name, string shortname, string conservativename, string conservativeshortname, string type, int parent, bool needcar, bool renting)
        {
			this.name = name;
			this.shortname = shortname;
			this.conservativename = conservativename;
			this.conservativeshortname = conservativeshortname;
			this.type = type;
			this.parent = parent;
			this.needcar = needcar;
			this.renting = renting;
        }

		public string GetLocationType()
        {
			return this.type;
        }

		public void RandomPrisonName()
		{
			Random random = new Random();

			string firstpart = null;
			string secondpart = null;

			switch (random.Next(5))
			{
				case 0: firstpart = "Happy"; break;
				case 1: firstpart = "Cheery"; break;
				case 2: firstpart = "Quiet"; break;
				case 3: firstpart = "Green"; break;
				case 4: firstpart = "Nectar"; break;
			}

			switch (random.Next(5))
			{
				case 0: secondpart = "Valley"; break;
				case 1: secondpart = "Meadow"; break;
				case 2: secondpart = "Hills"; break;
				case 3: secondpart = "Glade"; break;
				case 4: secondpart = "Forest"; break;
			}

			this.conservativename = firstpart + " " + secondpart + " Re-education Camp";
		}

		public void RandomWarehouseName()
		{
			Random random = new Random();

			switch (random.Next(5))
			{
				case 0:
					this.name = "Abandoned Meat Plant";
					this.shortname = "Meat Plant";
					break;
				case 1:
					this.name = "Abandoned Warehouse";
					this.shortname = "Warehouse";
					break;
				case 2:
					this.name = "Abandoned Paper Mill";
					this.shortname = "Paper Mill";
					break;
				case 3:
					this.name = "Abandoned Cement Factory";
					this.shortname = "Cement";
					break;
				case 4:
					this.name = "Abandoned Fertilizer Plant";
					this.shortname = "Fertilizer";
					break;
			}
		}

		public void RandomPolluterName()
		{
			Random random = new Random();

			switch (random.Next(5))
			{
				case 0:
					this.name = "Aluminum Factory";
					this.shortname = "Alum Fact";
					break;
				case 1:
					this.name = "Plastic Factory";
					this.shortname = "Plast Fact";
					break;
				case 2:
					this.name = "Oil Refinery";
					this.shortname = "Refinery";
					break;
				case 3:
					this.name = "Auto Plant";
					this.shortname = "Auto Plant";
					break;
				case 4:
					this.name = "Chemical Factory";
					this.shortname = "Chem Fact";
					break;
			}
		}

		public void RandomAptName()
        {
			string aptname = Program.RandomLastName();

			this.name = aptname + " Apartments";
			this.shortname = aptname + " Apts";
        }

		public void RandomVeganName()
		{
			Random random = new Random();

			string firstpart = null;
			string secondpart = null;

			switch (random.Next(5))
			{
				case 0: firstpart = "Asparagus"; break;
				case 1: firstpart = "Tofu"; break;
				case 2: firstpart = "Broccoli"; break;
				case 3: firstpart = "Radish"; break;
				case 4: firstpart = "Eggplant"; break;
			}

			switch (random.Next(5))
			{
				case 0: secondpart = "Forest"; break;
				case 1: secondpart = "Rainbow"; break;
				case 2: secondpart = "Garden"; break;
				case 3: secondpart = "Farm"; break;
				case 4: secondpart = "Meadow"; break;
			}

			this.name = firstpart + " " + secondpart + " Vegan Co-op";
		}

		public void RandomJuiceName()
		{
			Random random = new Random();

			string firstpart = null;
			string secondpart = null;

			switch (random.Next(5))
			{
				case 0: firstpart = "Natural"; break;
				case 1: firstpart = "Harmonious"; break;
				case 2: firstpart = "Restful"; break;
				case 3: firstpart = "Healthy"; break;
				case 4: firstpart = "New You"; break;
			}

			switch (random.Next(5))
			{
				case 0: secondpart = "Diet"; break;
				case 1: secondpart = "Methods"; break;
				case 2: secondpart = "Plan"; break;
				case 3: secondpart = "Orange"; break;
				case 4: secondpart = "Carrot"; break;
			}

			this.name = firstpart + " " + secondpart + " Juice Bar";
		}

		public void RandomInternetName()
		{
			Random random = new Random();

			string firstpart = null;
			string secondpart = null;

			switch (random.Next(5))
			{
				case 0: firstpart = "Electric"; break;
				case 1: firstpart = "Wired"; break;
				case 2: firstpart = "Nano"; break;
				case 3: firstpart = "Micro"; break;
				case 4: firstpart = "Techno"; break;
			}

			switch (random.Next(5))
			{
				case 0: secondpart = "Panda"; break;
				case 1: secondpart = "Troll"; break;
				case 2: secondpart = "Latte"; break;
				case 3: secondpart = "Unicorn"; break;
				case 4: secondpart = "Pixie"; break;
			}

			this.name = firstpart + " " + secondpart + " Internet Cafe";
		}

		public void RandomLatteName()
		{
			Random random = new Random();

			string firstpart = null;
			string secondpart = null;

			switch (random.Next(5))
			{
				case 0: firstpart = "Frothy"; break;
				case 1: firstpart = "Milky"; break;
				case 2: firstpart = "Caffine"; break;
				case 3: firstpart = "Morning"; break;
				case 4: firstpart = "Evening"; break;
			}

			switch (random.Next(5))
			{
				case 0: secondpart = "Mug"; break;
				case 1: secondpart = "Cup"; break;
				case 2: secondpart = "Jolt"; break;
				case 3: secondpart = "Wonder"; break;
				case 4: secondpart = "Express"; break;
			}

			this.name = firstpart + " " + secondpart + " Latte Stand";
		}
	}

	class Program
	{
		static Random random = new Random();

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
			City maincity = new City();
			Location newlocation;
			Faction liberals = new Faction();
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
						Console.WriteLine("My parents named me " + newcharacter.FullName + ".");
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

						Console.SetCursorPosition(4, 14); Console.WriteLine("I live in " + maincity.GetName() + ", and it's about to experience real change.");
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
							newcharacter.AttributeInc("charisma", 2);
							newcharacter.AttributeInc("heart", 1);
							newcharacter.SkillInc("persuasion", 2);
						}
						if (keyinput == 'b')
						{
							newcharacter.AttributeInc("strength", 1);
							newcharacter.AttributeInc("agility", 1);
							newcharacter.AttributeInc("health", 1);
							newcharacter.SkillInc("pistol", 2);
						}
						if (keyinput == 'c')
						{
							newcharacter.AttributeInc("intelligence", 3);
							newcharacter.SkillInc("computers", 2);
						}
						break;

					case 1:
						if (keyinput == 'a')
						{
							newcharacter.AttributeInc("charisma", 1);
							newcharacter.SkillInc("persuasion", 2);
						}
						if (keyinput == 'b')
						{
							newcharacter.AttributeInc("health", 1);
							newcharacter.AttributeInc("strength", 1);
							newcharacter.SkillInc("handtohand", 1);
						}
						if (keyinput == 'c')
						{
							newcharacter.AttributeInc("intelligence", 1);
							newcharacter.SkillInc("writing", 1);
							newcharacter.SkillInc("computers", 1);
						}
						break;

					case 2:
						if (keyinput == 'a')
						{
							newcharacter.AttributeInc("charisma", 1);
							newcharacter.SkillInc("persuasion", 2);
						}
						if (keyinput == 'b')
						{
							newcharacter.AttributeInc("strength", 1);
							newcharacter.AttributeInc("agility", 1);
							newcharacter.SkillInc("handtohand", 1);
						}
						if (keyinput == 'c')
						{
							newcharacter.AttributeInc("intelligence", 1);
							newcharacter.SkillInc("writing", 1);
							newcharacter.SkillInc("computers", 1);
						}
						break;

					case 3:
						if (keyinput == 'a')
						{
							newcharacter.AttributeInc("intelligence", 1);
							newcharacter.SkillInc("writing", 1);
							newcharacter.SkillInc("law", 1);
						}
						if (keyinput == 'b')
						{
							newcharacter.AttributeInc("strength", 1);
							newcharacter.AttributeInc("agility", 1);
							newcharacter.SkillInc("club", 1);
						}
						if (keyinput == 'c')
						{
							newcharacter.AttributeInc("intelligence", 2);
							newcharacter.SkillInc("computers", 1);
						}
						break;

					case 4:
						if (keyinput == 'a')
						{
							newcharacter.AttributeInc("charisma", 1);
							newcharacter.SkillInc("security", 1);
						}
						if (keyinput == 'b')
						{
							newcharacter.SkillInc("knife", 1);
							newcharacter.SkillInc("club", 1);
						}
						if (keyinput == 'c')
						{
							newcharacter.AttributeInc("intelligence", 2);
						}
						break;

					case 5:
						if (keyinput == 'a')
						{
							newcharacter.AttributeInc("intelligence", 1);
							newcharacter.SkillInc("driving", 1);
							newcharacter.SkillInc("security", 1);
						}
						if (keyinput == 'b')
						{
							newcharacter.AttributeInc("agility", 1);
							newcharacter.SkillInc("rifle", 1);
							newcharacter.SkillInc("assaultrifle", 1);
						}
						if (keyinput == 'c')
						{
							newcharacter.SkillInc("disguise", 2);
							newcharacter.SkillInc("garmentmaking", 1);
						}
						break;

					case 6:
						if (keyinput == 'a')
						{
							newcharacter.SkillInc("driving", 1);
							newcharacter.SkillInc("security", 2);
						}
						if (keyinput == 'b')
						{
							newcharacter.SkillInc("rifle", 1);
							newcharacter.SkillInc("assaultrifle", 1);
							newcharacter.SkillInc("pistol", 1);
						}
						if (keyinput == 'c')
						{
							newcharacter.AttributeInc("strength", 1);
							newcharacter.AttributeInc("agility", 2);
						}
						break;

					case 7:
						if (keyinput == 'a')
						{
							newcharacter.AttributeInc("intelligence", 1);
							newcharacter.SkillInc("security", 1);
							newcharacter.SkillInc("disguise", 1);
						}
						if (keyinput == 'b')
						{
							newcharacter.AttributeInc("strength", 1);
							newcharacter.AttributeInc("health", 1);
							newcharacter.SkillInc("handtohand", 1);
						}
						if (keyinput == 'c')
						{
							newcharacter.AttributeInc("heart", 1);
							newcharacter.SkillInc("law", 1);
							newcharacter.SkillInc("persuasion", 1);
						}
						break;

					case 8:
						if (keyinput == 'a')
						{
							newcharacter.AccessArmour = new Armour("securityuniform", 1, 0);
						}
						if (keyinput == 'b')
						{
							newcharacter.AccessWeapon = new Weapon("semirifleak47", new Clip("assault", 9), 30, true);
						}
						if (keyinput == 'c')
						{
							liberals.AccessFunds = 1000;
						}
						break;

					case 9:
						if (keyinput == 'a')
						{
							newcharacter.AttributeInc("intelligence", 2);
							newcharacter.AttributeInc("agility", 2);
							newcharacter.AttributeInc("health", 1);
							newcharacter.SkillInc("disguise", 2);
							newcharacter.SkillInc("security", 2);
							newcharacter.SkillInc("driving", 1);
						}
						if (keyinput == 'b')
						{
							newcharacter.AttributeInc("agility", 2);
							newcharacter.AttributeInc("strength", 1);
							newcharacter.AttributeInc("health", 2);
							newcharacter.SkillInc("rifle", 1);
							newcharacter.SkillInc("assaultrifle", 1);
							newcharacter.SkillInc("pistol", 1);
							newcharacter.SkillInc("knife", 1);
							newcharacter.SkillInc("club", 1);
						}
						if (keyinput == 'c')
						{
							newcharacter.AttributeInc("intelligence", 2);
							newcharacter.AttributeInc("heart", 2);
							newcharacter.AttributeInc("health", 1);
							newcharacter.SkillInc("law", 2);
							newcharacter.SkillInc("writing", 2);
							newcharacter.SkillInc("persuasion", 1);
						}
						break;
				}
			}

			Console.Clear();
			Console.SetCursorPosition(4, 2);
			Console.Write("What is your name to the People?");
			Console.SetCursorPosition(4, 3);

			string nameinput = Console.ReadLine();

			if (nameinput == null)
            {
				newcharacter.Handle = newcharacter.FullName;
            }
            else
            {
				newcharacter.Handle = nameinput;
			}

			newlocation = new Location("Downtown", "Downtown", null, null, "downtown", -1, false, false);
			maincity.AddLocation(newlocation);

			newlocation = new Location("The University District", "U-District", null, null, "unidistrict", -1, false, false);
			maincity.AddLocation(newlocation);

			newlocation = new Location("The Industrial District", "I-District", null, null, "inddistrict", -1, false, false);
			maincity.AddLocation(newlocation);

			newlocation = new Location("On the Outskirts of the City", "Outskirts", null, null, "outskirts", -1, true, false);
			maincity.AddLocation(newlocation);

			newlocation = new Location("Police Station", "Police Station", null, null, "policestation", 0, false, false);
			maincity.AddLocation(newlocation);

			newlocation = new Location("Court House", "Court House", "Halls of Ultimate Judgement", "Judge Hall", "courthouse", 0, false, false);
			maincity.AddLocation(newlocation);

			newlocation = new Location(RandomLastName() + " Prison", "Prison", null, "Re-ed Camp", "prison", 3, true, false);
			newlocation.RandomPrisonName();
			maincity.AddLocation(newlocation);

			newlocation = new Location("Nuclear Power Plant", "NPower Plant", null, null, "nuclear", 3, true, false);
			maincity.AddLocation(newlocation);

			newlocation = new Location("Intelligence HQ", "Int. HQ", "Ministry of Love", "Min. Love", "intelligencehq", 3, true, false);
			maincity.AddLocation(newlocation);

			newlocation = new Location("Corporate HQ", "Corp. HQ", null, null, "corporatehq", 3, true, false);
			maincity.AddLocation(newlocation);

			newlocation = new Location("CEO Residence", "CEO House", "CEO Castle", "CEO Castle", "corporatehouse", 3, true, false);
			maincity.AddLocation(newlocation);

			newlocation = new Location("Homeless Shelter", "Shelter", null, null, "shelter", 2, false, false);
			maincity.AddLocation(newlocation);

			newlocation = new Location(null, null, null, null, "warehouse", 2, false, false);
			newlocation.RandomWarehouseName();
			maincity.AddLocation(newlocation);

			newlocation = new Location(null, null, null, null, "warehouse", 2, false, false);
			newlocation.RandomWarehouseName();
			maincity.AddLocation(newlocation);

			newlocation = new Location(null, null, null, null, "warehouse", 2, false, false);
			newlocation.RandomWarehouseName();
			maincity.AddLocation(newlocation);

			newlocation = new Location(null, null, null, null, "polluter", 2, false, false);
			newlocation.RandomPolluterName();
			maincity.AddLocation(newlocation);

			newlocation = new Location(null, null, null, null, "polluter", 2, false, false);
			newlocation.RandomPolluterName();
			maincity.AddLocation(newlocation);

			newlocation = new Location(null, null, null, null, "polluter", 2, false, false);
			newlocation.RandomPolluterName();
			maincity.AddLocation(newlocation);

			newlocation = new Location("Cable News Station", "News Station", null, null, "cablenews", 0, false, false);
			maincity.AddLocation(newlocation);

			newlocation = new Location("AM Radio Station", "Radio Station", null, null, "amradio", 0, false, false);
			maincity.AddLocation(newlocation);

			newlocation = new Location(null, null, null, null, "upscaleapt", 0, false, false);
			newlocation.RandomAptName();
			maincity.AddLocation(newlocation);

			newlocation = new Location(null, null, null, null, "upscaleapt", 0, false, false);
			newlocation.RandomAptName();
			maincity.AddLocation(newlocation);

			newlocation = new Location(null, null, null, null, "apt", 1, false, false);
			newlocation.RandomAptName();
			maincity.AddLocation(newlocation);

			newlocation = new Location(null, null, null, null, "apt", 1, false, false);
			newlocation.RandomAptName();
			maincity.AddLocation(newlocation);

			newlocation = new Location(null, null, null, null, "tenement", 2, false, false);
			newlocation.RandomAptName();
			maincity.AddLocation(newlocation);

			newlocation = new Location(null, null, null, null, "tenement", 2, false, false);
			newlocation.RandomAptName();
			maincity.AddLocation(newlocation);

			newlocation = new Location("The University Hospital", "U Hospital", null, null, "hospitaluni", 1, false, false);
			maincity.AddLocation(newlocation);

			newlocation = new Location("The Free CLINIC", "CLINIC", null, null, "hospitalclinic", 1, false, false);
			maincity.AddLocation(newlocation);

			newlocation = new Location(Program.RandomLastName() + " Genetics", "Genetics Lab", null, null, "labgenetic", 1, false, false);
			maincity.AddLocation(newlocation);

			newlocation = new Location(Program.RandomLastName() + " Cosmetics", "Cosmetics Lab", null, null, "labcosmetics", 1, false, false);
			maincity.AddLocation(newlocation);

			newlocation = new Location(Program.RandomLastName() + " Cash & Loans", "Pawnshop", null, null, "pawnshop", 2, false, false);
			maincity.AddLocation(newlocation);

			newlocation = new Location(Program.RandomLastName() + "'s Department Store", "Dept. Store", null, null, "deptstore", 0, false, false);
			maincity.AddLocation(newlocation);

			newlocation = new Location("The Oubliette", "Oubliette", null, null, "halloween", 1, false, false);
			maincity.AddLocation(newlocation);

			newlocation = new Location(Program.RandomLastName() + " Garment Makers", "Sweatshop", null, null, "sweatshop", 2, false, false);
			maincity.AddLocation(newlocation);

			newlocation = new Location(Program.RandomLastName() + " Garment Makers", "Sweatshop", null, null, "sweatshop", 2, false, false);
			maincity.AddLocation(newlocation);

			newlocation = new Location(Program.RandomLastName() + " St. Crack House", "Crack House", null, null, "crackhouse", 2, false, false);
			maincity.AddLocation(newlocation);

			newlocation = new Location(Program.RandomLastName() + " St. Crack House", "Crack House", null, null, "crackhouse", 2, false, false);
			maincity.AddLocation(newlocation);

			newlocation = new Location(Program.RandomLastName() + " St. Crack House", "Crack House", null, null, "crackhouse", 2, false, false);
			maincity.AddLocation(newlocation);

			newlocation = new Location(null, "Vegan Co-op", null, null, "vegancoop", 1, false, false);
			newlocation.RandomVeganName();
			maincity.AddLocation(newlocation);

			newlocation = new Location(null, "Juice Bar", null, null, "juicebar", 1, false, false);
			newlocation.RandomJuiceName();
			maincity.AddLocation(newlocation);

			newlocation = new Location(null, "Net Cafe", null, null, "internetcafe", 1, false, false);
			newlocation.RandomInternetName();
			maincity.AddLocation(newlocation);

			newlocation = new Location("The " + Program.RandomLastName() + " Gentlemen's Club", "Cigar Bar", null, null, "cigarbar", 1, false, false);
			maincity.AddLocation(newlocation);

			newlocation = new Location(null, "Latte Stand", null, null, "lattestand", 0, false, false);
			newlocation.RandomLatteName();
			maincity.AddLocation(newlocation);

			newlocation = new Location(null, "Latte Stand", null, null, "lattestand", 0, false, false);
			newlocation.RandomLatteName();
			maincity.AddLocation(newlocation);

			newsquad.AddMember(newcharacter);
			newcharacter.SquadID = newsquad.GetID();
			newsquad.Name = "The Liberal Crime Squad";

			for (int i = 0; i < maincity.GetLocations().Count; i++)
			{
				if (maincity.GetLocations()[i].GetLocationType() == "shelter")
				{
					newcharacter.AccessBase = maincity.GetLocations()[i];
					newcharacter.AccessLocation = maincity.GetLocations()[i];
					break;
				}
			}

			liberals.AddSquad(newsquad);
			liberals.SetActive(newsquad);
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

		static void Main(string[] args)
		{
			Console.SetWindowSize(120, 30);
			Console.SetBufferSize(120, 30);
			Console.CursorVisible = false;

			Mode_title();
		}
	}
}
