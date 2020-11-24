using System;

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

		public Faction(int funds)
		{
			this.funds = funds;
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
	};

	public class Entity
	{
		string firstname;
		string lastname;
		string fullname;

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

		Weapon weapon;
		Armour armour;

		public Entity()
		{
			GiveName();
			this.fullname = firstname + " " + lastname;

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
		}

		void GiveName()
		{
			Random random = new Random();

			switch (random.Next(0, 100))
			{
				case 0: this.firstname = "Ryan"; break;
				case 1: this.firstname = "Sergio"; break;
				case 2: this.firstname = "Laura"; break;
				case 3: this.firstname = "Anne"; break;
				case 4: this.firstname = "Bill"; break;
				case 5: this.firstname = "James"; break;
				case 6: this.firstname = "Marty"; break;
				case 7: this.firstname = "Jessica"; break;
				case 8: this.firstname = "Lisa"; break;
				case 9: this.firstname = "Bonita"; break;
				case 10: this.firstname = "Angel"; break;
				case 11: this.firstname = "Pat"; break;
				case 12: this.firstname = "Toshiro"; break;
				case 13: this.firstname = "Yan-ping"; break;
				case 14: this.firstname = "Tetsuo"; break;
				case 15: this.firstname = "Akira"; break;
				case 16: this.firstname = "Jimmy"; break;
				case 17: this.firstname = "Carlos"; break;
				case 18: this.firstname = "William"; break;
				case 19: this.firstname = "Billy Bob"; break;
				case 20: this.firstname = "Carol"; break;
				case 21: this.firstname = "Jenny"; break;
				case 22: this.firstname = "Jennifer"; break;
				case 23: this.firstname = "Manuela"; break;
				case 24: this.firstname = "Douglas"; break;
				case 25: this.firstname = "Kristin"; break;
				case 26: this.firstname = "Steven"; break;
				case 27: this.firstname = "Bonnie"; break;
				case 28: this.firstname = "Howard"; break;
				case 29: this.firstname = "Donald"; break;
				case 30: this.firstname = "Barry"; break;
				case 31: this.firstname = "Thomas"; break;
				case 32: this.firstname = "Joann"; break;
				case 33: this.firstname = "Derek"; break;
				case 34: this.firstname = "Gary"; break;
				case 35: this.firstname = "Archie"; break;
				case 36: this.firstname = "Mayumi"; break;
				case 37: this.firstname = "Felicia"; break;
				case 38: this.firstname = "Sherry"; break;
				case 39: this.firstname = "Judy"; break;
				case 40: this.firstname = "Elinor"; break;
				case 41: this.firstname = "Ned"; break;
				case 42: this.firstname = "Randy"; break;
				case 43: this.firstname = "Taylor"; break;
				case 44: this.firstname = "Kim"; break;
				case 45: this.firstname = "Ruthanne"; break;
				case 46: this.firstname = "Roger"; break;
				case 47: this.firstname = "Raymond"; break;
				case 48: this.firstname = "Harvey"; break;
				case 49: this.firstname = "Robert"; break;
				case 50: this.firstname = "Michael"; break;
				case 51: this.firstname = "Aaron"; break;
				case 52: this.firstname = "George"; break;
				case 53: this.firstname = "Noel"; break;
				case 54: this.firstname = "Adrienne"; break;
				case 55: this.firstname = "Lex"; break;
				case 56: this.firstname = "Linda"; break;
				case 57: this.firstname = "Chuck"; break;
				case 58: this.firstname = "Charlie"; break;
				case 59: this.firstname = "Charles"; break;
				case 60: this.firstname = "Malcolm"; break;
				case 61: this.firstname = "Martin"; break;
				case 62: this.firstname = "Sean"; break;
				case 63: this.firstname = "Raven"; break;
				case 64: this.firstname = "Wolf"; break;
				case 65: this.firstname = "Miguel"; break;
				case 66: this.firstname = "Pablo"; break;
				case 67: this.firstname = "Paul"; break;
				case 68: this.firstname = "Jesus"; break;
				case 69: this.firstname = "Ali"; break;
				case 70: this.firstname = "Ingrid"; break;
				case 71: this.firstname = "Kweisi"; break;
				case 72: this.firstname = "Susanna"; break;
				case 73: this.firstname = "Sharon"; break;
				case 74: this.firstname = "Marion"; break;
				case 75: this.firstname = "Kathy"; break;
				case 76: this.firstname = "Bruce"; break;
				case 77: this.firstname = "Dick"; break;
				case 78: this.firstname = "Phillip"; break;
				case 79: this.firstname = "Kirk"; break;
				case 80: this.firstname = "Kurt"; break;
				case 81: this.firstname = "John"; break;
				case 82: this.firstname = "Alexander"; break;
				case 83: this.firstname = "David"; break;
				case 84: this.firstname = "Beau"; break;
				case 85: this.firstname = "Elsie"; break;
				case 86: this.firstname = "Satya"; break;
				case 87: this.firstname = "Mumtaz"; break;
				case 88: this.firstname = "Diwakar"; break;
				case 89: this.firstname = "Dale"; break;
				case 90: this.firstname = "Woody"; break;
				case 91: this.firstname = "Ariel"; break;
				case 92: this.firstname = "Hans"; break;
				case 93: this.firstname = "Barbara"; break;
				case 94: this.firstname = "Jun"; break;
				case 95: this.firstname = "Rosemary"; break;
				case 96: this.firstname = "Chin-Yuan"; break;
				case 97: this.firstname = "Aiko"; break;
				case 98: this.firstname = "Vithara"; break;
				case 99: this.firstname = "Deepak"; break;
			}

			switch (random.Next(0, 100))
			{
				case 0: this.lastname = "King"; break;
				case 1: this.lastname = "Lewis"; break;
				case 2: this.lastname = "Black"; break;
				case 3: this.lastname = "White"; break;
				case 4: this.lastname = "Ames"; break;
				case 5: this.lastname = "Warner"; break;
				case 6: this.lastname = "Simpson"; break;
				case 7: this.lastname = "Parker"; break;
				case 8: this.lastname = "Suave"; break;
				case 9: this.lastname = "Mifune"; break;
				case 10: this.lastname = "Gu"; break;
				case 11: this.lastname = "Bolger"; break;
				case 12: this.lastname = "Ross"; break;
				case 13: this.lastname = "Ramirez"; break;
				case 14: this.lastname = "Kurosawa"; break;
				case 15: this.lastname = "Johnson"; break;
				case 16: this.lastname = "Buchanan"; break;
				case 17: this.lastname = "Adamson"; break;
				case 18: this.lastname = "Hendrix"; break;
				case 19: this.lastname = "Rojo"; break;
				case 20: this.lastname = "Villa"; break;
				case 21: this.lastname = "Fields"; break;
				case 22: this.lastname = "Templeton"; break;
				case 23: this.lastname = "Ivanson"; break;
				case 24: this.lastname = "Blitzer"; break;
				case 25: this.lastname = "Muhammed"; break;
				case 26: this.lastname = "Stone"; break;
				case 27: this.lastname = "Cho"; break;
				case 28: this.lastname = "Childress"; break;
				case 29: this.lastname = "Africa"; break;
				case 30: this.lastname = "Balgos"; break;
				case 31: this.lastname = "Baird"; break;
				case 32: this.lastname = "Bailey"; break;
				case 33: this.lastname = "Diaz"; break;
				case 34: this.lastname = "Decker"; break;
				case 35: this.lastname = "Ericson"; break;
				case 36: this.lastname = "Loeb"; break;
				case 37: this.lastname = "Meffert"; break;
				case 38: this.lastname = "McLeod"; break;
				case 39: this.lastname = "Tucker"; break;
				case 40: this.lastname = "Takayoshi"; break;
				case 41: this.lastname = "Tanner"; break;
				case 42: this.lastname = "Lipman"; break;
				case 43: this.lastname = "Little"; break;
				case 44: this.lastname = "Logsdon"; break;
				case 45: this.lastname = "Krasow"; break;
				case 46: this.lastname = "Krieger"; break;
				case 47: this.lastname = "Dahmer"; break;
				case 48: this.lastname = "Gacy"; break;
				case 49: this.lastname = "Krishna"; break;
				case 50: this.lastname = "la Russa"; break;
				case 51: this.lastname = "Savedra"; break;
				case 52: this.lastname = "Scardino"; break;
				case 53: this.lastname = "Keitel"; break;
				case 54: this.lastname = "Wallace"; break;
				case 55: this.lastname = "Buckman"; break;
				case 56: this.lastname = "Fulsom"; break;
				case 57: this.lastname = "Smith"; break;
				case 58: this.lastname = "Venus"; break;
				case 59: this.lastname = "Straley"; break;
				case 60: this.lastname = "Purcell"; break;
				case 61: this.lastname = "al Fadil"; break;
				case 62: this.lastname = "Storm"; break;
				case 63: this.lastname = "Patterson"; break;
				case 64: this.lastname = "Pelton"; break;
				case 65: this.lastname = "Ng"; break;
				case 66: this.lastname = "Filler"; break;
				case 67: this.lastname = "Buttman"; break;
				case 68: this.lastname = "Fingleton"; break;
				case 69: this.lastname = "Fenoglio"; break;
				case 70: this.lastname = "de la Cruz"; break;
				case 71: this.lastname = "Delgado"; break;
				case 72: this.lastname = "Hatcher"; break;
				case 73: this.lastname = "Jameson"; break;
				case 74: this.lastname = "Franklin"; break;
				case 75: this.lastname = "Washington"; break;
				case 76: this.lastname = "Jefferson"; break;
				case 77: this.lastname = "Strossen"; break;
				case 78: this.lastname = "Hannemann"; break;
				case 79: this.lastname = "Hammond"; break;
				case 80: this.lastname = "Logan"; break;
				case 81: this.lastname = "Hutchison"; break;
				case 82: this.lastname = "Jimison"; break;
				case 83: this.lastname = "Sawyer"; break;
				case 84: this.lastname = "Santiago"; break;
				case 85: this.lastname = "Rudkin"; break;
				case 86: this.lastname = "Bump"; break;
				case 87: this.lastname = "Simon"; break;
				case 88: this.lastname = "Davis"; break;
				case 89: this.lastname = "Reagan"; break;
				case 90: this.lastname = "Bush"; break;
				case 91: this.lastname = "Bradshaw"; break;
				case 92: this.lastname = "Yamaguchi"; break;
				case 93: this.lastname = "Roy"; break;
				case 94: this.lastname = "Colt"; break;
				case 95: this.lastname = "Rothstein"; break;
				case 96: this.lastname = "Spears"; break;
				case 97: this.lastname = "Lopez"; break;
				case 98: this.lastname = "Aguilera"; break;
				case 99: this.lastname = "Carey"; break;
			}
		}

		public string FullName
		{
			get
			{
				return this.fullname;
			}
			set
			{
				this.fullname = value;
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
	}

	class Program
	{
		static void CharacterCreation()
		{
			Faction liberals = new Faction(0);
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

						//Console.SetCursorPosition(4, 14); Console.WriteLine("I live in " + lcityname + ", and it's about to experience real change.");
						break;
				}

				char input = Console.ReadKey(true).KeyChar;

				switch (q)
				{
					case 0:
						if (input == 'a')
						{
							newcharacter.AttributeInc("charisma", 2);
							newcharacter.AttributeInc("heart", 1);
							newcharacter.SkillInc("persuasion", 2);
						}
						if (input == 'b')
						{
							newcharacter.AttributeInc("strength", 1);
							newcharacter.AttributeInc("agility", 1);
							newcharacter.AttributeInc("health", 1);
							newcharacter.SkillInc("pistol", 2);
						}
						if (input == 'c')
						{
							newcharacter.AttributeInc("intelligence", 3);
							newcharacter.SkillInc("computers", 2);
						}
						break;

					case 1:
						if (input == 'a')
						{
							newcharacter.AttributeInc("charisma", 1);
							newcharacter.SkillInc("persuasion", 2);
						}
						if (input == 'b')
						{
							newcharacter.AttributeInc("health", 1);
							newcharacter.AttributeInc("strength", 1);
							newcharacter.SkillInc("handtohand", 1);
						}
						if (input == 'c')
						{
							newcharacter.AttributeInc("intelligence", 1);
							newcharacter.SkillInc("writing", 1);
							newcharacter.SkillInc("computers", 1);
						}
						break;

					case 2:
						if (input == 'a')
						{
							newcharacter.AttributeInc("charisma", 1);
							newcharacter.SkillInc("persuasion", 2);
						}
						if (input == 'b')
						{
							newcharacter.AttributeInc("strength", 1);
							newcharacter.AttributeInc("agility", 1);
							newcharacter.SkillInc("handtohand", 1);
						}
						if (input == 'c')
						{
							newcharacter.AttributeInc("intelligence", 1);
							newcharacter.SkillInc("writing", 1);
							newcharacter.SkillInc("computers", 1);
						}
						break;

					case 3:
						if (input == 'a')
						{
							newcharacter.AttributeInc("intelligence", 1);
							newcharacter.SkillInc("writing", 1);
							newcharacter.SkillInc("law", 1);
						}
						if (input == 'b')
						{
							newcharacter.AttributeInc("strength", 1);
							newcharacter.AttributeInc("agility", 1);
							newcharacter.SkillInc("club", 1);
						}
						if (input == 'c')
						{
							newcharacter.AttributeInc("intelligence", 2);
							newcharacter.SkillInc("computers", 1);
						}
						break;

					case 4:
						if (input == 'a')
						{
							newcharacter.AttributeInc("charisma", 1);
							newcharacter.SkillInc("security", 1);
						}
						if (input == 'b')
						{
							newcharacter.SkillInc("knife", 1);
							newcharacter.SkillInc("club", 1);
						}
						if (input == 'c')
						{
							newcharacter.AttributeInc("intelligence", 2);
						}
						break;

					case 5:
						if (input == 'a')
						{
							newcharacter.AttributeInc("intelligence", 1);
							newcharacter.SkillInc("driving", 1);
							newcharacter.SkillInc("security", 1);
						}
						if (input == 'b')
						{
							newcharacter.AttributeInc("agility", 1);
							newcharacter.SkillInc("rifle", 1);
							newcharacter.SkillInc("assaultrifle", 1);
						}
						if (input == 'c')
						{
							newcharacter.SkillInc("disguise", 2);
							newcharacter.SkillInc("garmentmaking", 1);
						}
						break;

					case 6:
						if (input == 'a')
						{
							newcharacter.SkillInc("driving", 1);
							newcharacter.SkillInc("security", 2);
						}
						if (input == 'b')
						{
							newcharacter.SkillInc("rifle", 1);
							newcharacter.SkillInc("assaultrifle", 1);
							newcharacter.SkillInc("pistol", 1);
						}
						if (input == 'c')
						{
							newcharacter.AttributeInc("strength", 1);
							newcharacter.AttributeInc("agility", 2);
						}
						break;

					case 7:
						if (input == 'a')
						{
							newcharacter.AttributeInc("intelligence", 1);
							newcharacter.SkillInc("security", 1);
							newcharacter.SkillInc("disguise", 1);
						}
						if (input == 'b')
						{
							newcharacter.AttributeInc("strength", 1);
							newcharacter.AttributeInc("health", 1);
							newcharacter.SkillInc("handtohand", 1);
						}
						if (input == 'c')
						{
							newcharacter.AttributeInc("heart", 1);
							newcharacter.SkillInc("law", 1);
							newcharacter.SkillInc("persuasion", 1);
						}
						break;

					case 8:
						if (input == 'a')
						{
							newcharacter.AccessArmour = new Armour("securityuniform", 1, 0);
						}
						if (input == 'b')
						{
							newcharacter.AccessWeapon = new Weapon("semirifleak47", new Clip("assault", 9), 30, true);
						}
						if (input == 'c')
						{
							liberals.AccessFunds = 1000;
						}
						break;

					case 9:
						if (input == 'a')
						{
							newcharacter.AttributeInc("intelligence", 2);
							newcharacter.AttributeInc("agility", 2);
							newcharacter.AttributeInc("health", 1);
							newcharacter.SkillInc("disguise", 2);
							newcharacter.SkillInc("security", 2);
							newcharacter.SkillInc("driving", 1);
						}
						if (input == 'b')
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
						if (input == 'c')
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
