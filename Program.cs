using System;
using System.Collections.Generic;
using System.Threading;

namespace LCSRemake
{
    public enum WeaponTypes
    {
        BASEBALLBAT,
        CROWBAR,
        KNIFE,
        SHANK,
        SYRINGE,
        REVOLVER_22,
        REVOLVER_44,
        SEMIPISTOL_9MM,
        SEMIPISTOL_45,
        SEMIRIFLE_M16,
        SEMIRIFLE_AK47,
        SHOTGUN,
        SWORD,
        CHAIN,
        NIGHTSTICK,
        GAVEL,
        AXE,
        HAMMER,
        MAUL,
        CROSS,
        STAFF,
        PITCHFORK,
        TORCH
    }
    public enum ClipTypes
    {
        NINEMM,
        DOT45,
        ASSAULT,
        DOT22,
        DOT44,
        BUCKSHOT
    }
    public enum ArmourTypes
    {
        CLOTHES,
        TRENCHCOAT,
        WORKCLOTHES,
        SECURITYUNIFORM,
        POLICEUNIFORM,
        CHEAPSUIT,
        EXPENSIVESUIT,
        BLACKSUIT,
        CHEAPDRESS,
        EXPENSIVEDRESS,
        BLACKDRESS,
        LABCOAT,
        BLACKROBE,
        CLOWNSUIT,
        BONDAGEGEAR,
        MASK,
        MILITARY,
        PRISONGUARD,
        PRISONER,
        TOGA,
        MITHRIL,
        OVERALLS,
        WIFEBEATER
    }
    public enum ActivityTypes
    {
        NONE,
        VISIT,
        HOSTAGETENDING,
        TROUBLE,
        FUNDS_LEGAL,
        FUNDS_ILLEGAL,
        REPAIR_ARMOUR,
        MAKE_ARMOUR,
        POLLS,
        STEALCARS,
        WHEELCHAIR,
        BURY
    };
    public enum SkillTypes
    {
        HANDTOHAND,
        KNIFE,
        CLUB,
        SWORD,
        AXE,
        SPEAR,
        PISTOL,
        RIFLE,
        ASSAULTRIFLE,
        PERSUASION,
        LAW,
        SECURITY,
        DISGUISE,
        COMPUTERS,
        GARMENTMAKING,
        DRIVING,
        WRITING
    };
    public enum VehicleTypes
    {
        VAN,
        STATIONWAGON,
        SPORTSCAR,
        BUG,
        PICKUP,
        POLICECAR,
        TAXICAB,
        SUV,
        AGENTCAR,
        JEEP
    };

    public class City
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
        public bool HasFlag { get; set; }
        public Faction Owner { get; set; }
        public List<Item> Stash { get; }

        public Location(string name, string shortname, string type, bool needcar, Faction owner)
        {
            this.Name = name;
            this.Shortname = shortname;
            this.Type = type;
            this.Needs_car = needcar;
            this.Owner = owner;
            this.HasFlag = false;
            this.Stash = new List<Item>();
        }

        public void RandomName(List<string> list)
        {
            Random random = new Random();
            string name = list[random.Next(0, list.Count)];
            if (this.Name == null)
            {
                this.Name = name;
            }
            else
            {
                this.Name += name;
            }

            if (this.Shortname == null)
            {
                this.Shortname = name;
            }
        }

        public void RandomName(List<string> firstlist, List<string> secondlist)
        {
            Random random = new Random();
            string name = firstlist[random.Next(0, firstlist.Count)] + " " + secondlist[random.Next(0, secondlist.Count)];
            if (this.Name == null)
            {
                this.Name = name;
            }
            else
            {
                this.Name += name;
            }

            if (this.Shortname == null)
            {
                this.Shortname = name;
            }
        }
    }

    public class Faction
    {
        public int Funds { get; set; }
        public string Slogan { get; set; }
        public List<Squad> Squads { get; }
        public Squad Activesquad { get; set; }
        public bool Disbanding { get; set; }
        public List<Entity> Active { get; }
        public List<Entity> Hostages { get; }
        public List<Entity> Clinic { get; }
        public List<Entity> JusticeSystem { get; }
        public List<Entity> Sleepers { get; }
        public List<Entity> TheDead { get; }
        public List<Entity> Away { get; }
        public List<Armour> CraftableArmours { get; }
        public List<Vehicle> Vehicles { get; }

        public Faction()
        {
            this.Funds = 0;
            this.Slogan = "We need a slogan!";
            this.Squads = new List<Squad>();
            this.Disbanding = false;
            this.Active = new List<Entity>();
            this.Hostages = new List<Entity>();
            this.Clinic = new List<Entity>();
            this.JusticeSystem = new List<Entity>();
            this.Sleepers = new List<Entity>();
            this.TheDead = new List<Entity>();
            this.Away = new List<Entity>();
            this.CraftableArmours = new List<Armour> { 
                new Armour("Clothes", ArmourTypes.CLOTHES, 0, 10),
                new Armour("Trenchcoat", ArmourTypes.TRENCHCOAT, 0, 20),
                new Armour("Work Clothes", ArmourTypes.WORKCLOTHES, 0, 10),
                new Armour("Security Uniform", ArmourTypes.SECURITYUNIFORM, 0, 40),
                new Armour("Police Uniform", ArmourTypes.POLICEUNIFORM, 0, 40),
                new Armour("Cheap Suit", ArmourTypes.CHEAPSUIT, 0, 50),
                new Armour("Expensive Suit", ArmourTypes.EXPENSIVESUIT, 0, 300),
                new Armour("Black Suit", ArmourTypes.BLACKSUIT, 0, 60),
                new Armour("Cheap Dress", ArmourTypes.CHEAPDRESS, 0, 20),
                new Armour("Expensve Dress", ArmourTypes.EXPENSIVEDRESS, 0, 300),
                new Armour("Black Dress", ArmourTypes.BLACKDRESS, 0, 60),
                new Armour("Lab Coat", ArmourTypes.LABCOAT, 0, 20),
                new Armour("Black Robe", ArmourTypes.BLACKROBE, 0, 20),
                new Armour("Clown Suit", ArmourTypes.CLOWNSUIT, 0, 20),
                new Armour("Bondage Gear", ArmourTypes.BONDAGEGEAR, 0, 30),
                new Armour("Army Uniform", ArmourTypes.MILITARY, 0, 40),
                new Armour("Guard Uniform", ArmourTypes.PRISONGUARD, 0, 40),
                new Armour("Orange Jumpsuit", ArmourTypes.PRISONER, 0, 20),
                new Armour("Toga", ArmourTypes.TOGA, 0, 5),
                new Armour("Overalls", ArmourTypes.OVERALLS, 0, 10),
                new Armour("Wife Beater", ArmourTypes.WIFEBEATER, 0, 5)
            };
            this.Vehicles = new List<Vehicle>();
        }
    };

    public class Squad
    {
        static int idcounter = 0;
        public int ID { get; }
        public string Name { get; set; }
        public Entity Driver { get; set; }
        public Vehicle Vehicle { get; set; }
        public List<Entity> Entities { get; }
        public Location Location { get; set; }

        public Squad()
        {
            this.ID = idcounter;
            idcounter++;
            this.Name = "";
            this.Entities = new List<Entity>();
        }

        public string GetActivityInfo()
        {
            try
            {
                string activityname = this.Entities[0].Activity.Name;
                bool allsame = true;

                foreach (Entity entity in this.Entities)
                {
                    if (entity.Activity.Name == activityname)
                    {
                        allsame = true;
                    }
                    else
                    {
                        allsame = false;
                    }
                }

                if (allsame)
                {
                    return this.Entities[0].Activity.Name;
                }
                else
                {
                    return "Acting Individually";
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                return "";
            }
        }

        public string GetVehicle(Entity entity)
        {
            if (this.Vehicle == null)
            {
                return "On foot";
            }
            else
            {
                if (entity == this.Driver)
                {
                    return this.Vehicle.GetName() + " - D";
                }
                else
                {
                    return this.Vehicle.GetName();
                }
            }
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
        public string Title { get; set; }
        public string Profession { get; set; }

        public int Strength { get; set; }
        public int Intelligence { get; set; }
        public int Wisdom { get; set; }
        public int Agility { get; set; }
        public int MaxHealth { get; set; }
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
        public int DaysCaptive { get; set; }
        public int HealTime { get; set; }
        public int DaysAway { get; set; }
        public int DaysDead { get; set; }

        public Squad AssignedSquad { get; set; }
        public Weapon Weapon { get; set; }
        public Armour Armour { get; set; }
        public Location Mybase { get; set; }
        public Location Location { get; set; }
        public Location Worklocation { get; set; }
        public Entity Prisoner { get; set; }
        public Entity AssignedTo { get; set; }
        public Activity Activity { get; set; }

        public Entity()
        {
            this.ID = idcounter;
            idcounter++;

            this.Firstname = Program.RandomFirstName();
            this.Lastname = Program.RandomLastName();
            this.Fullname = Firstname + " " + Lastname;
            this.Handle = Fullname;
            this.Profession = "Transient";

            this.Strength = 4;
            this.Intelligence = 1;
            this.Wisdom = 1;
            this.Agility = 4;
            this.MaxHealth = 4;
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
            this.DaysCaptive = 0;
            this.HealTime = 0;
            this.DaysAway = 0;
            this.DaysDead = 0;

            this.AssignedTo = null;

            this.Title = UpdateTitle();
        }

        public int GetTotalSkillLevel()
        {
            return this.Handtohand + this.Knife + this.Club + this.Sword + this.Axe +
                   this.Spear + this.Pistol + this.Rifle + this.Assaultrifle + this.Persuasion +
                   this.Law + this.Security + this.Disguise + this.Computers + this.Garmentmaking +
                   this.Driving + this.Writing;
        }

        public string UpdateTitle()
        {
            if (this.Juice <= -50)
            {
                return "Damn Worthless";
            }
            else if (this.Juice <= -10)
            {
                return "Society's Dregs";
            }
            else if (this.Juice < 0)
            {
                return "Punk";
            }
            else if (this.Juice < 10)
            {
                return "Civilian";
            }
            else if (this.Juice < 50)
            {
                return "Activist";
            }
            else if (this.Juice < 100)
            {
                return "Socialist Threat";
            }
            else if (this.Juice < 200)
            {
                return "Revolutionary";
            }
            else if (this.Juice < 500)
            {
                return "Urban Commando";
            }
            else
            {
                return "Elite Liberal";
            }
        }

        public string GetWeaponName()
        {
            if (this.Weapon == null)
            {
                return "None";
            }
            else
            {
                if (this.Weapon.Ammo == null)
                {
                    return this.Weapon.Name + $" (0/0)";
                }
                else
                {
                    return this.Weapon.Name + $" ({this.Weapon.Ammo.Amount}/{this.Weapon.SpareClips.Count})";
                }
            }
        }

        public int GetWeaponSkill()
        {
            if (this.Weapon == null)
            {
                return this.Handtohand;
            }
            else
            {
                switch (this.Weapon.Skilltype)
                {
                    case SkillTypes.HANDTOHAND:
                        return this.Handtohand;
                    case SkillTypes.KNIFE:
                        return this.Knife;
                    case SkillTypes.CLUB:
                        return this.Club;
                    case SkillTypes.SWORD:
                        return this.Sword;
                    case SkillTypes.AXE:
                        return this.Axe;
                    case SkillTypes.SPEAR:
                        return this.Spear;
                    case SkillTypes.PISTOL:
                        return this.Pistol;
                    case SkillTypes.RIFLE:
                        return this.Rifle;
                    case SkillTypes.ASSAULTRIFLE:
                        return this.Assaultrifle;
                }
            }
            return 0;
        }

        public string GetArmourName()
        {
            if (this.Armour == null)
            {
                return "Naked";
            }
            else
            {
                return this.Armour.Name;
            }
        }
    }

    public class Activity
    {
        public string Name { get; set; }
        public ActivityTypes ActivityType { get; set; }
        public int Funding { get; set; }
        public Entity Hostage { get; set; }
        public Armour Armour { get; set; }

        public Activity(string name, ActivityTypes activitytype)
        {
            this.Name = name;
            this.ActivityType = activitytype;
            this.Funding = 0;
            this.Hostage = null;
            this.Armour = null;
        }
    }

    public class Vehicle
    {
        static int idcounter = 0;
        public int ID { get; set; }
        public string Name { get; set; }
        public VehicleTypes VehicleType { get; set; }
        public string Colour { get; set; }
        public Location Location { get; set; }
        public int Year { get; set; }
        public Squad AssignedTo { get; set; }

        public Vehicle(VehicleTypes vehicletype, Location location, Date thedate)
        {
            Random random = new Random();

            this.ID = idcounter; idcounter++;
            this.VehicleType = vehicletype;
            this.Location = location;

            switch (vehicletype)
            {
                case VehicleTypes.JEEP:
                    this.Name = "Jeep";
                    this.Year = thedate.Year + 1 - random.Next(41);
                    break;
                case VehicleTypes.VAN:
                    this.Name = "Van";
                    this.Year = 1969 + random.Next(6);
                    break;
                case VehicleTypes.STATIONWAGON:
                    this.Name = "Station Wagon";
                    this.Year = thedate.Year + 1 - random.Next(41);
                    break;
                case VehicleTypes.SPORTSCAR:
                    this.Name = "Sportscar";
                    this.Year = thedate.Year + 1 - random.Next(21);
                    break;
                case VehicleTypes.BUG:
                    this.Name = "Bug";
                    this.Year = 1969 + random.Next(6);
                    break;
                case VehicleTypes.PICKUP:
                    this.Name = "Pickup Truck";
                    this.Year = thedate.Year + 1 - random.Next(41);
                    break;
                case VehicleTypes.POLICECAR:
                    this.Name = "Police Cruiser";
                    this.Year = thedate.Year + 1 - random.Next(21);
                    break;
                case VehicleTypes.TAXICAB:
                    this.Name = "Taxicab";
                    this.Year = thedate.Year + 1 - random.Next(41);
                    break;
                case VehicleTypes.SUV:
                    this.Name = "SUV";
                    this.Year = 1995 + random.Next(thedate.Year - 1995 + 1);
                    break;
                case VehicleTypes.AGENTCAR:
                    this.Name = "Car";
                    break;
            }

            switch (vehicletype)
            {
                case VehicleTypes.POLICECAR:
                    this.Colour = "Police-Marked";
                    break;
                case VehicleTypes.AGENTCAR:
                    this.Colour = "Black";
                    break;
                case VehicleTypes.TAXICAB:
                    this.Colour = "Taxi-Striped";
                    break;
                case VehicleTypes.JEEP:
                case VehicleTypes.VAN:
                case VehicleTypes.STATIONWAGON:
                case VehicleTypes.SPORTSCAR:
                case VehicleTypes.BUG:
                case VehicleTypes.PICKUP:
                case VehicleTypes.SUV:
                    switch (random.Next(5))
                    {
                        case 0: this.Colour = "Red"; break;
                        case 1: this.Colour = "White"; break;
                        case 2: this.Colour = "Blue"; break;
                        case 3: this.Colour = "Beige"; break;
                        case 4: this.Colour = "Black"; break;
                    }
                    break;
            }
        }

        public string GetName()
        {
            return this.Name;
        }

        public string GetFullName()
        {
            if (this.VehicleType == VehicleTypes.AGENTCAR)
            {
                return $"{this.Colour} {this.Name}";
            }
            else
            {
                return $"{this.Colour} {this.Year} {this.Name}";
            }
        }
    }

    public abstract class Item
    {
        public string Name { get; set; }
    }


    public class Weapon : Item
    {
        public SkillTypes Skilltype { get; }
        public ClipTypes Cliptype { get; }
        public Clip Ammo { get; set; }
        public List<Clip> SpareClips { get; set; }
        public bool Ranged { get; }

        public Weapon(string name, SkillTypes skilltype, ClipTypes cliptype, Clip ammo, bool ranged)
        {
            this.Name = name;
            this.Skilltype = skilltype;
            this.Cliptype = cliptype;
            this.Ammo = ammo;
            this.Ranged = ranged;
            this.SpareClips = new List<Clip>();
        }
    };

    public class Clip : Item
    {
        public ClipTypes Cliptype { get; }
        public int Amount { get; set; }

        public Clip(string name, ClipTypes cliptype, int amount)
        {
            this.Name = name;
            this.Cliptype = cliptype;
            this.Amount = amount;
        }
    }

    public class Armour : Item
    {
        public ArmourTypes Armourtype { get; }
        public int Quality { get; }
        public int Cost { get; }
        public bool Damaged { get; set; }

        public Armour(string name, ArmourTypes armourtype, int quality, int cost)
        {
            this.Name = name;
            this.Armourtype = armourtype;
            this.Quality = quality;
            this.Cost = cost;
            this.Damaged = false;
        }

        public int MakeDifficulty(Entity entity)
        {
            int basedifficulty;

            switch (this.Armourtype)
            {
                case ArmourTypes.TOGA:
                case ArmourTypes.WIFEBEATER:
                    basedifficulty = 2;
                    break;
                case ArmourTypes.CLOTHES:
                case ArmourTypes.OVERALLS:
                case ArmourTypes.WORKCLOTHES:
                    basedifficulty = 3;
                    break;
                case ArmourTypes.CLOWNSUIT:
                case ArmourTypes.PRISONER:
                case ArmourTypes.CHEAPDRESS:
                case ArmourTypes.TRENCHCOAT:
                case ArmourTypes.LABCOAT:
                case ArmourTypes.BLACKROBE:
                case ArmourTypes.BONDAGEGEAR:
                    basedifficulty = 4;
                    break;
                case ArmourTypes.SECURITYUNIFORM:
                case ArmourTypes.PRISONGUARD:
                case ArmourTypes.MILITARY:
                case ArmourTypes.POLICEUNIFORM:
                    basedifficulty = 5;
                    break;
                case ArmourTypes.CHEAPSUIT:
                    basedifficulty = 6;
                    break;
                case ArmourTypes.BLACKSUIT:
                case ArmourTypes.BLACKDRESS:
                    basedifficulty = 7;
                    break;
                case ArmourTypes.EXPENSIVESUIT:
                case ArmourTypes.EXPENSIVEDRESS:
                    basedifficulty = 9;
                    break;
                default:
                    basedifficulty = 10;
                    break;
            }

            basedifficulty -= entity.Garmentmaking - 3;
            if (basedifficulty < 0) basedifficulty = 0;

            return basedifficulty;
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
            if (this.Day == 30)
            {
                this.Day = 1;

                if (this.Month == 12)
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

            switch (this.Month)
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
        static string str_codename = "CODE NAME";
        static string str_skill = "SKILL";
        static string str_weapon = "WEAPON";
        static string str_armour = "ARMOUR";
        static string str_health = "HEALTH";
        static string str_transport = "TRANSPORT";
        static string str_squadname = "SQUAD NAME";
        static string str_location = "LOCATION";
        static string str_squad_activity = "SQUAD / ACTIVITY";
        static string str_activity = "ACTIVITY";
        static string str_days_captive = "DAYS IN CAPTIVITY";
        static string str_prognosis = "PROGNOSIS";
        static string str_days_return = "DAYS UNTIL RETURN";
        static string str_days_dead = "DAYS SINCE PASSING";
        static string str_profession = "PROFESSION";
        static string str_months_left = "MONTHS LEFT";
        static string str_current_base = "CURRENT BASE";
        static string str_new_base = "NEW BASE";
        static string str_current_contact = "CURRENT CONTACT";
        static string str_contact_after_promotion = "CONTACT AFTER PROMOTION";
        static string str_name = "NAME";
        static string str_difficulty = "DIFFICULTY";
        static string str_cost = "COST";
        static string str_current_activity = "CURRENT ACTIVITY";
        static string str_bulk_activity = "BULK ACTIVITY";

        static void Border()
        {
            for (int x = 2; x < Console.BufferWidth - 2; x++)
            {
                Print(x, 0, "\u2588");
            }

            for (int x = 2; x < Console.BufferWidth - 2; x++)
            {
                Print(x, Console.BufferHeight - 2, "\u2588");
            }

            for (int y = 1; y < Console.BufferHeight - 2; y++)
            {
                Print(2, y, "\u2588");
            }

            for (int y = 1; y < Console.BufferHeight - 2; y++)
            {
                Print(Console.BufferWidth - 3, y, "\u2588");
            }
        }

        static void Print(int x, int y, string write, ConsoleColor foregroundcolour = ConsoleColor.Gray, ConsoleColor backgroundcolour = ConsoleColor.Black)
        {
            Console.ForegroundColor = foregroundcolour;
            Console.BackgroundColor = backgroundcolour;
            Console.SetCursorPosition(x, y);
            Console.Write(write);
            Console.ResetColor();
        }

        static void GetHealthLabel(int x, int y, Entity entity)
        {
            if (entity.Health >= entity.MaxHealth - 1)
            {
                Print(x, y, "Liberal", ConsoleColor.Green);
            }
            else if (entity.Health < entity.MaxHealth - 1 && entity.Health > (int)entity.MaxHealth / 2)
            {
                Print(x, y, "Moderate", ConsoleColor.White);
            }
            else
            {
                Print(x, y, "Conservative", ConsoleColor.Red);
            }
        }

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

        static void Fullstatus(Entity entity)
        {
            while (true)
            {
                Console.Clear();
                Border();

                Print(4, 2, "Profile of a liberal");
                Print(3, 4, "#----------------------------------------------------------------------------------------------------------------#");
                Print(5, 4, entity.Handle + ", " + entity.Title);
                Print(80, 4, entity.Profession);

                Print(4, 6, "Heart:        " + entity.Heart);
                Print(4, 7, "Intelligence: " + entity.Intelligence);
                Print(4, 8, "Wisdom:       " + entity.Wisdom);
                Print(4, 9, "Health:       " + entity.MaxHealth + "/" + entity.Health);
                Print(4, 10, "Agility:      " + entity.Agility);
                Print(4, 11, "Strength:     " + entity.Strength);
                Print(4, 12, "Charisma:     " + entity.Charisma);
                Print(42, 6, "Juice: " + entity.Juice);
                Print(42, 7, "Next:  ");

                if (entity.Juice < 500)
                {
                    if (entity.Juice < 0)
                    {
                        Print(49, 7, "0");
                    }
                    else if (entity.Juice < 10)
                    {
                        Print(49, 7, "10");
                    }
                    else if (entity.Juice < 50)
                    {
                        Print(49, 7, "50");
                    }
                    else if (entity.Juice < 100)
                    {
                        Print(49, 7, "100");
                    }
                    else if (entity.Juice < 200)
                    {
                        Print(49, 7, "200");
                    }
                    else
                    {
                        Print(49, 7, "500");
                    }
                }

                Print(80, 6, "Handtohand:    " + entity.Handtohand);
                Print(80, 7, "Knife:         " + entity.Knife);
                Print(80, 8, "Club:          " + entity.Club);
                Print(80, 9, "Sword:         " + entity.Sword);
                Print(80, 10, "Axe:           " + entity.Axe);
                Print(80, 11, "Spear:         " + entity.Spear);
                Print(80, 12, "Pistol:        " + entity.Pistol);
                Print(80, 13, "Rifle:         " + entity.Rifle);
                Print(80, 14, "Assaultrifle:  " + entity.Assaultrifle);
                Print(100, 6, "Persuasion:    " + entity.Persuasion);
                Print(100, 7, "Law:           " + entity.Law);
                Print(100, 8, "Security:      " + entity.Security);
                Print(100, 9, "Disguise:      " + entity.Disguise);
                Print(100, 10, "Computers:     " + entity.Computers);
                Print(100, 11, "Garmentmaking: " + entity.Garmentmaking);
                Print(100, 12, "Driving:       " + entity.Driving);
                Print(100, 13, "Writing:       " + entity.Writing);

                Print(4, 16, "Weapon: " + entity.GetWeaponName());
                Print(42, 16, "Armour: " + entity.GetArmourName());
                Print(80, 16, $"Transport: {entity.AssignedSquad.GetVehicle(entity)}");

                Print(3, 17, "#----------------------------------------------------------------------------------------------------------------#");

                Print(4, 25, "Press N to change this Liberal's Code Name");
                Print(4, 26, "Press any other key to continue the Struggle");

                char keyinput = Console.ReadKey(true).KeyChar;

                if (keyinput == 'n')
                {
                    Print(42, 20, "What is the new code name?");

                    Console.SetCursorPosition(42, 21);

                    string newname = Console.ReadLine();

                    if (newname == "")
                    {
                        entity.Handle = entity.Fullname;
                    }
                    else
                    {
                        entity.Handle = newname;
                    }
                }
                else
                {
                    break;
                }
            }
        }

        static void Equipment()
        {
            int currenty;
            int currenty2;
            int currenty3;
            int currenty4;
            int letter;
            int count;
            int position;
            int page = 0;
            int maxpage = liberals.Activesquad.Location.Stash.Count / 16;

            while (true)
            {
                currenty = 13;
                currenty2 = 13;
                currenty3 = 13;
                currenty4 = 13;
                letter = 65;
                position = page * 16;

                if (liberals.Activesquad.Location.Stash.Count - page * 16 > 16)
                {
                    count = 16;
                }
                else
                {
                    count = liberals.Activesquad.Location.Stash.Count - page * 16;
                }

                Console.Clear();
                Border();

                Print(5, 2, "Equip the Squad");
                Print(106, 2, "Page:" + page.ToString() + "/" + maxpage.ToString());
                Print(3, 4, "#----------------------------------------------------------------------------------------------------------------#");
                Print(5, 4, str_codename);
                Print(26, 4, str_skill);
                Print(43, 4, str_weapon);
                Print(61, 4, str_armour);
                Print(79, 4, str_health);
                Print(97, 4, str_transport);
                Print(3, 5, "1");
                Print(3, 6, "2");
                Print(3, 7, "3");
                Print(3, 8, "4");
                Print(3, 9, "5");
                Print(3, 10, "6");

                for (int member = 0; member < liberals.Activesquad.Entities.Count; member++)
                {
                    Entity selectedmember = liberals.Activesquad.Entities[member];

                    Print(5, 5 + member, selectedmember.Handle);
                    Print(26, 5 + member, selectedmember.GetTotalSkillLevel() + "/" + selectedmember.GetWeaponSkill());
                    Print(43, 5 + member, selectedmember.GetWeaponName());
                    Print(61, 5 + member, selectedmember.GetArmourName());
                    GetHealthLabel(79, 5 + member, selectedmember);
                    Print(97, 5 + member, selectedmember.AssignedSquad.GetVehicle(selectedmember));
                }

                Print(3, 11, "#----------------------------------------------------------------------------------------------------------------#");

                foreach (Item item in liberals.Activesquad.Location.Stash.GetRange(position, count))
                {
                    if (letter < 69)
                    {
                        if (item.GetType() == typeof(Clip))
                        {
                            Print(3, currenty, (char)letter + " - " + item.Name + $" ({((Clip)item).Amount})");
                            currenty++;
                            letter++;
                        }
                        else
                        {
                            Print(3, currenty, (char)letter + " - " + item.Name);
                            currenty++;
                            letter++;
                        }
                    }
                    else if (letter < 73)
                    {
                        if (item.GetType() == typeof(Clip))
                        {
                            Print(32, currenty2, (char)letter + " - " + item.Name + $" ({((Clip)item).Amount})");
                            currenty2++;
                            letter++;
                        }
                        else
                        {
                            Print(32, currenty2, (char)letter + " - " + item.Name);
                            currenty2++;
                            letter++;
                        }
                    }
                    else if(letter < 77)
                    {
                        if (item.GetType() == typeof(Clip))
                        {
                            Print(61, currenty3, (char)letter + " - " + item.Name + $" ({((Clip)item).Amount})");
                            currenty3++;
                            letter++;
                        }
                        else
                        {
                            Print(61, currenty3, (char)letter + " - " + item.Name);
                            currenty3++;
                            letter++;
                        }
                    }
                    else
                    {
                        if (item.GetType() == typeof(Clip))
                        {
                            Print(90, currenty4, (char)letter + " - " + item.Name + $" ({((Clip)item).Amount})");
                            currenty4++;
                            letter++;
                        }
                        else
                        {
                            Print(90, currenty4, (char)letter + " - " + item.Name);
                            currenty4++;
                            letter++;
                        }
                    }
                }

                Print(3, 18, "#----------------------------------------------------------------------------------------------------------------#");
                Print(4, 22, "Press a letter to equip a Liberal item");
                Print(4, 23, "Press a number to drop that Squad member's Conservative weapon");
                Print(4, 24, "S - Liberally Strip a Squad member");
                Print(4, 26, "X - Done");

                char keyinput = Console.ReadKey(true).KeyChar;

                if (keyinput >= 'a' && keyinput <= 'r')
                {
                    try
                    {
                        Print(38, 11, "Choose a Liberal squad member to recieve it", ConsoleColor.White);

                        char subkeyinput = Console.ReadKey(true).KeyChar;

                        if (subkeyinput >= '1' && subkeyinput <= '6')
                        {
                            switch (keyinput)
                            {
                                case 'a':
                                    AddRemoveEquipment(0, page, (int)Char.GetNumericValue(subkeyinput) - 1);
                                    break;
                                case 'b':
                                    AddRemoveEquipment(1, page, (int)Char.GetNumericValue(subkeyinput) - 1);
                                    break;
                                case 'c':
                                    AddRemoveEquipment(2, page, (int)Char.GetNumericValue(subkeyinput) - 1);
                                    break;
                                case 'd':
                                    AddRemoveEquipment(3, page, (int)Char.GetNumericValue(subkeyinput) - 1);
                                    break;
                                case 'e':
                                    AddRemoveEquipment(4, page, (int)Char.GetNumericValue(subkeyinput) - 1);
                                    break;
                                case 'f':
                                    AddRemoveEquipment(5, page, (int)Char.GetNumericValue(subkeyinput) - 1);
                                    break;
                                case 'g':
                                    AddRemoveEquipment(6, page, (int)Char.GetNumericValue(subkeyinput) - 1);
                                    break;
                                case 'h':
                                    AddRemoveEquipment(7, page, (int)Char.GetNumericValue(subkeyinput) - 1);
                                    break;
                                case 'i':
                                    AddRemoveEquipment(8, page, (int)Char.GetNumericValue(subkeyinput) - 1);
                                    break;
                                case 'j':
                                    AddRemoveEquipment(9, page, (int)Char.GetNumericValue(subkeyinput) - 1);
                                    break;
                                case 'k':
                                    AddRemoveEquipment(10, page, (int)Char.GetNumericValue(subkeyinput) - 1);
                                    break;
                                case 'l':
                                    AddRemoveEquipment(11, page, (int)Char.GetNumericValue(subkeyinput) - 1);
                                    break;
                                case 'm':
                                    AddRemoveEquipment(12, page, (int)Char.GetNumericValue(subkeyinput) - 1);
                                    break;
                                case 'n':
                                    AddRemoveEquipment(13, page, (int)Char.GetNumericValue(subkeyinput) - 1);
                                    break;
                                case 'o':
                                    AddRemoveEquipment(14, page, (int)Char.GetNumericValue(subkeyinput) - 1);
                                    break;
                                case 'p':
                                    AddRemoveEquipment(15, page, (int)Char.GetNumericValue(subkeyinput) - 1);
                                    break;
                            }
                        }
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                    }
                }

                if (keyinput >= '1' && keyinput <= '6')
                {
                    try
                    {
                        if(liberals.Activesquad.Entities[(int)Char.GetNumericValue(keyinput) - 1].Weapon != null)
                        {
                            liberals.Activesquad.Location.Stash.Add(liberals.Activesquad.Entities[(int)Char.GetNumericValue(keyinput) - 1].Weapon.Ammo);
                            liberals.Activesquad.Location.Stash.Add(liberals.Activesquad.Entities[(int)Char.GetNumericValue(keyinput) - 1].Weapon);

                            if (liberals.Activesquad.Entities[(int)Char.GetNumericValue(keyinput) - 1].Weapon.SpareClips.Count > 0)
                            {
                                foreach (Clip clip in liberals.Activesquad.Entities[(int)Char.GetNumericValue(keyinput) - 1].Weapon.SpareClips)
                                {
                                    liberals.Activesquad.Location.Stash.Add(clip);
                                }
                                liberals.Activesquad.Entities[(int)Char.GetNumericValue(keyinput) - 1].Weapon.SpareClips.Clear();
                            }

                            liberals.Activesquad.Entities[(int)Char.GetNumericValue(keyinput) - 1].Weapon.Ammo = null;
                            liberals.Activesquad.Entities[(int)Char.GetNumericValue(keyinput) - 1].Weapon = null;
                        }
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                    }
                }

                if (keyinput == ']')
                {
                    if (page < maxpage)
                    {
                        page++;
                    }
                }

                if (keyinput == '[')
                {
                    if (page > 0)
                    {
                        page--;
                    }
                }

                if (keyinput == 's')
                {
                    Print(38, 11, "Choose a Liberal squad member to strip down", ConsoleColor.White);

                    char subkeyinput = Console.ReadKey(true).KeyChar;

                    if (subkeyinput >= '1' && subkeyinput <= '6')
                    {
                        try
                        {
                            if (liberals.Activesquad.Entities[(int)Char.GetNumericValue(subkeyinput) - 1].Armour != null)
                            {
                                liberals.Activesquad.Location.Stash.Add(liberals.Activesquad.Entities[(int)Char.GetNumericValue(subkeyinput) - 1].Armour);
                                liberals.Activesquad.Entities[(int)Char.GetNumericValue(subkeyinput) - 1].Armour = null;
                            }
                        }
                        catch (ArgumentOutOfRangeException)
                        {
                        }
                    }
                }

                if (keyinput == 'x')
                {
                    break;
                }
            }
        }

        static void AddRemoveEquipment(int index, int page, int characterPosition)
        {
            if (liberals.Activesquad.Location.Stash[index + page * 16].GetType().Equals(typeof(Weapon)))
            {
                if (liberals.Activesquad.Entities[characterPosition].Weapon == null)
                {
                    liberals.Activesquad.Entities[characterPosition].Weapon = (Weapon)liberals.Activesquad.Location.Stash[index + page * 16];
                    liberals.Activesquad.Location.Stash.Remove(liberals.Activesquad.Location.Stash[index + page * 16]);
                }
                else
                {
                    liberals.Activesquad.Location.Stash.Add(liberals.Activesquad.Entities[characterPosition].Weapon);
                    liberals.Activesquad.Entities[characterPosition].Weapon = (Weapon)liberals.Activesquad.Location.Stash[index + page * 16];
                    liberals.Activesquad.Location.Stash.Remove(liberals.Activesquad.Location.Stash[index + page * 16]);
                }
            }
            else if (liberals.Activesquad.Location.Stash[index + page * 16].GetType().Equals(typeof(Armour)))
            {
                if (liberals.Activesquad.Entities[characterPosition].Armour == null)
                {
                    liberals.Activesquad.Entities[characterPosition].Armour = (Armour)liberals.Activesquad.Location.Stash[index + page * 16];
                    liberals.Activesquad.Location.Stash.Remove(liberals.Activesquad.Location.Stash[index + page * 16]);
                }
                else
                {
                    liberals.Activesquad.Location.Stash.Add(liberals.Activesquad.Entities[characterPosition].Armour);
                    liberals.Activesquad.Entities[characterPosition].Armour = (Armour)liberals.Activesquad.Location.Stash[index + page * 16];
                    liberals.Activesquad.Location.Stash.Remove(liberals.Activesquad.Location.Stash[index + page * 16]);
                }
            }
            else if (liberals.Activesquad.Location.Stash[index + page * 16].GetType().Equals(typeof(Clip)))
            {
                if (((Clip)liberals.Activesquad.Location.Stash[index + page * 16]).Cliptype == liberals.Activesquad.Entities[characterPosition].Weapon.Cliptype)
                {
                    if (liberals.Activesquad.Entities[characterPosition].Weapon.Ammo == null)
                    {
                        liberals.Activesquad.Entities[characterPosition].Weapon.Ammo = (Clip)liberals.Activesquad.Location.Stash[index + page * 16];
                        liberals.Activesquad.Location.Stash.Remove(liberals.Activesquad.Location.Stash[index + page * 16]);
                    }
                    else
                    {
                        liberals.Activesquad.Entities[characterPosition].Weapon.SpareClips.Add((Clip)liberals.Activesquad.Location.Stash[index + page * 16]);
                        liberals.Activesquad.Location.Stash.Remove(liberals.Activesquad.Location.Stash[index + page * 16]);
                    }
                }
            }
        }

        static void Vehicles()
        {
            int currenty;
            int currenty2;
            int currenty3;
            int letter;
            int count;
            int position;
            int page = 0;
            int maxpage = liberals.Vehicles.Count / 12;

            while (true)
            {
                currenty = 13;
                currenty2 = 13;
                currenty3 = 13;
                letter = 65;
                position = page * 12;

                if (liberals.Vehicles.Count - page * 12 > 12)
                {
                    count = 12;
                }
                else
                {
                    count = liberals.Vehicles.Count - page * 12;
                }

                Console.Clear();
                Border();

                Print(5, 2, "Equip the Squad");
                Print(106, 2, "Page:" + page.ToString() + "/" + maxpage.ToString());
                Print(3, 4, "#----------------------------------------------------------------------------------------------------------------#");
                Print(5, 4, str_codename);
                Print(26, 4, str_skill);
                Print(43, 4, str_weapon);
                Print(61, 4, str_armour);
                Print(79, 4, str_health);
                Print(97, 4, str_transport);
                Print(3, 5, "1");
                Print(3, 6, "2");
                Print(3, 7, "3");
                Print(3, 8, "4");
                Print(3, 9, "5");
                Print(3, 10, "6");

                for (int member = 0; member < liberals.Activesquad.Entities.Count; member++)
                {
                    Entity selectedmember = liberals.Activesquad.Entities[member];

                    Print(5, 5 + member, selectedmember.Handle);
                    Print(26, 5 + member, selectedmember.GetTotalSkillLevel() + "/" + selectedmember.GetWeaponSkill());
                    Print(43, 5 + member, selectedmember.GetWeaponName());
                    Print(61, 5 + member, selectedmember.GetArmourName());
                    GetHealthLabel(79, 5 + member, selectedmember);
                    Print(97, 5 + member, selectedmember.AssignedSquad.GetVehicle(selectedmember));
                }

                Print(3, 11, "#----------------------------------------------------------------------------------------------------------------#");

                foreach (Vehicle vehicle in liberals.Vehicles.GetRange(position, count))
                {
                    if (letter < 69)
                    {
                        if (liberals.Activesquad.Vehicle == vehicle)
                        {
                            Print(3, currenty, (char)letter + " - " + vehicle.GetFullName(), ConsoleColor.Green);
                        }
                        else if (liberals.Activesquad.Vehicle != vehicle && vehicle.AssignedTo != null)
                        {
                            Print(3, currenty, (char)letter + " - " + vehicle.GetFullName(), ConsoleColor.DarkYellow);
                        }
                        else
                        {
                            Print(3, currenty, (char)letter + " - " + vehicle.GetFullName());
                        }
                        currenty++;
                        letter++;
                    }
                    else if (letter < 73)
                    {
                        if (liberals.Activesquad.Vehicle == vehicle)
                        {
                            Print(41, currenty2, (char)letter + " - " + vehicle.GetFullName(), ConsoleColor.Green);
                        }
                        else if (liberals.Activesquad.Vehicle != vehicle && vehicle.AssignedTo != null)
                        {
                            Print(41, currenty2, (char)letter + " - " + vehicle.GetFullName(), ConsoleColor.DarkYellow);
                        }
                        else
                        {
                            Print(41, currenty2, (char)letter + " - " + vehicle.GetFullName());
                        }
                        currenty2++;
                        letter++;
                    }
                    else
                    {
                        if (liberals.Activesquad.Vehicle == vehicle)
                        {
                            Print(79, currenty3, (char)letter + " - " + vehicle.GetFullName(), ConsoleColor.Green);
                        }
                        else if (liberals.Activesquad.Vehicle != vehicle && vehicle.AssignedTo != null)
                        {
                            Print(79, currenty3, (char)letter + " - " + vehicle.GetFullName(), ConsoleColor.DarkYellow);
                        }
                        else
                        {
                            Print(79, currenty3, (char)letter + " - " + vehicle.GetFullName());
                        }
                        currenty3++;
                        letter++;
                    }
                }

                Print(3, 18, "#----------------------------------------------------------------------------------------------------------------#");
                Print(4, 22, "Press a letter to specify passengers for that Liberal vehicle.");
                Print(4, 23, "Note: Vehicles in yellow have already been selected by another squad.");
                Print(4, 26, "X - Done");

                char keyinput = Console.ReadKey(true).KeyChar;

                if (keyinput >= 'a' && keyinput <= 'l')
                {
                    try
                    {
                        Print(38, 11, "Choose a Liberal squad member to be the driver", ConsoleColor.White);

                        char subkeyinput = Console.ReadKey(true).KeyChar;

                        if (subkeyinput >= '1' && subkeyinput <= '6')
                        {
                            switch (keyinput)
                            {
                                case 'a':
                                    AssignVehicles(0, page, (int)Char.GetNumericValue(subkeyinput) - 1);
                                    break;
                                    
                                case 'b':
                                    AssignVehicles(1, page, (int)Char.GetNumericValue(subkeyinput) - 1);
                                    break;

                                case 'c':
                                    AssignVehicles(2, page, (int)Char.GetNumericValue(subkeyinput) - 1);
                                    break;

                                case 'd':
                                    AssignVehicles(3, page, (int)Char.GetNumericValue(subkeyinput) - 1);
                                    break;

                                case 'e':
                                    AssignVehicles(4, page, (int)Char.GetNumericValue(subkeyinput) - 1);
                                    break;

                                case 'f':
                                    AssignVehicles(5, page, (int)Char.GetNumericValue(subkeyinput) - 1);
                                    break;

                                case 'g':
                                    AssignVehicles(6, page, (int)Char.GetNumericValue(subkeyinput) - 1);
                                    break;

                                case 'h':
                                    AssignVehicles(7, page, (int)Char.GetNumericValue(subkeyinput) - 1);
                                    break;

                                case 'i':
                                    AssignVehicles(8, page, (int)Char.GetNumericValue(subkeyinput) - 1);
                                    break;

                                case 'j':
                                    AssignVehicles(9, page, (int)Char.GetNumericValue(subkeyinput) - 1);
                                    break;

                                case 'k':
                                    AssignVehicles(10, page, (int)Char.GetNumericValue(subkeyinput) - 1);
                                    break;

                                case 'l':
                                    AssignVehicles(11, page, (int)Char.GetNumericValue(subkeyinput) - 1);
                                    break;
                            }
                        }
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                    }
                }

                if (keyinput == ']')
                {
                    if (page < maxpage)
                    {
                        page++;
                    }
                }

                if (keyinput == '[')
                {
                    if (page > 0)
                    {
                        page--;
                    }
                }

                if (keyinput == 'x')
                {
                    break;
                }
            }
        }

        static void AssignVehicles(int index, int page, int characterPosition)
        {
            if (liberals.Activesquad.Vehicle == null)
            {
                if (liberals.Vehicles[index + page * 12].AssignedTo == null)
                {
                    liberals.Activesquad.Driver = liberals.Activesquad.Entities[characterPosition];
                    liberals.Activesquad.Vehicle = liberals.Vehicles[index + page * 12];
                    liberals.Vehicles[index + page * 12].AssignedTo = liberals.Activesquad;
                }
                else
                {
                    liberals.Vehicles[index + page * 12].AssignedTo.Vehicle = null;
                    liberals.Activesquad.Driver = liberals.Activesquad.Entities[characterPosition];
                    liberals.Activesquad.Vehicle = liberals.Vehicles[index + page * 12];
                    liberals.Vehicles[index + page * 12].AssignedTo = liberals.Activesquad;
                }
            }
            else
            {
                if (liberals.Vehicles[index + page * 12].AssignedTo == null)
                {
                    liberals.Activesquad.Vehicle.AssignedTo = null;
                    liberals.Activesquad.Driver = liberals.Activesquad.Entities[characterPosition];
                    liberals.Activesquad.Vehicle = liberals.Vehicles[index + page * 12];
                    liberals.Vehicles[index + page * 12].AssignedTo = liberals.Activesquad;
                }
                else
                {
                    liberals.Activesquad.Vehicle.AssignedTo = null;
                    liberals.Vehicles[index + page * 12].AssignedTo.Vehicle = null;
                    liberals.Activesquad.Driver = liberals.Activesquad.Entities[characterPosition];
                    liberals.Activesquad.Vehicle = liberals.Vehicles[index + page * 12];
                    liberals.Vehicles[index + page * 12].AssignedTo = liberals.Activesquad;
                }
            }
        }

        static void Review()
        {
            int currenty;
            int letter;
            int count;
            int position;
            int page = 0;
            int maxpage = liberals.Squads.Count / 12;

            while (true)
            {
                currenty = 5;
                letter = 65;
                position = page * 12;

                if(liberals.Squads.Count - page * 12 > 12)
                {
                    count = 12;
                }
                else 
                {
                    count = liberals.Squads.Count - page * 12;
                }
                
                Console.Clear();
                Border();

                Print(4, 2, "Review your Liberals and Assemble Squads");
                Print(106, 2, "Page:" + page.ToString() + "/" + maxpage.ToString());
                Print(3, 4, "#----------------------------------------------------------------------------------------------------------------#");
                Print(7, 4, str_squadname);
                Print(55, 4, str_location);
                Print(91, 4, str_activity);

                foreach (Squad squad in liberals.Squads.GetRange(position, count))
                {
                    if (squad == liberals.Activesquad)
                    {
                        Print(3, currenty, (char)letter + " - " + squad.Name, ConsoleColor.White);
                        Print(55, currenty, squad.Location.Shortname, ConsoleColor.White);
                        Print(91, currenty, squad.GetActivityInfo(), ConsoleColor.White);
                    }
                    else
                    {
                        Print(3, currenty, (char)letter + " - " + squad.Name);
                        Print(55, currenty, squad.Location.Shortname);
                        Print(91, currenty, squad.GetActivityInfo());
                    }
                    currenty++;
                    letter++;
                }

                Print(3, 17, "#----------------------------------------------------------------------------------------------------------------#");
                Print(28, 19, "1 - Active Liberals", ConsoleColor.Green);
                Print(54, 19, "2 - Hostages", ConsoleColor.Red);
                Print(80, 19, "3 - CLINIC", ConsoleColor.White);
                Print(28, 20, "4 - Justice System", ConsoleColor.Yellow);
                Print(54, 20, "5 - Sleepers", ConsoleColor.Magenta);
                Print(80, 20, "6 - The Dead", ConsoleColor.DarkGray);
                Print(28, 21, "7 - Away", ConsoleColor.Blue);

                Print(4, 24, "Press a letter to select a squad. 1-7 to view liberal groups.");
                Print(4, 25, "[] to view other liberal pages.   Press U to promote liberals.");
                Print(4, 26, "Press Z to assemble a new squad.  Press T to assign new bases to the squadless.");

                char keyinput = Console.ReadKey(true).KeyChar;

                if (keyinput >= 'a' && keyinput <= 'l')
                {
                    try
                    {
                        switch (keyinput)
                        {
                            case 'a':
                                AssembleSquad(liberals.Squads[0 + page]);
                                break;
                            case 'b':
                                AssembleSquad(liberals.Squads[1 + page]);
                                break;
                            case 'c':
                                AssembleSquad(liberals.Squads[2 + page]);
                                break;
                            case 'd':
                                AssembleSquad(liberals.Squads[3 + page]);
                                break;
                            case 'e':
                                AssembleSquad(liberals.Squads[4 + page]);
                                break;
                            case 'f':
                                AssembleSquad(liberals.Squads[5 + page]);
                                break;
                            case 'g':
                                AssembleSquad(liberals.Squads[6 + page]);
                                break;
                            case 'h':
                                AssembleSquad(liberals.Squads[7 + page]);
                                break;
                            case 'i':
                                AssembleSquad(liberals.Squads[8 + page]);
                                break;
                            case 'j':
                                AssembleSquad(liberals.Squads[9 + page]);
                                break;
                            case 'k':
                                AssembleSquad(liberals.Squads[10 + page]);
                                break;
                            case 'l':
                                AssembleSquad(liberals.Squads[11 + page]);
                                break;
                        }
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                    }
                }
                else if (keyinput >= '1' && keyinput <= '7')
                {
                    switch (keyinput)
                    {
                        case '1':
                            ReviewSubscreen(liberals.Active, 6, "Active Liberals", str_squad_activity, 1);
                            break;

                        case '2':
                            ReviewSubscreen(liberals.Hostages, 12, "Conservative Automatons in Captivity", str_days_captive, 2);
                            break;

                        case '3':
                            ReviewSubscreen(liberals.Clinic, 12, "Liberals in CLINICS", str_prognosis, 3);
                            break;

                        case '4':
                            ReviewSubscreen(liberals.JusticeSystem, 12, "Liberals and the Justice System", str_months_left, 4);
                            break;

                        case '5':
                            ReviewSubscreen(liberals.Sleepers, 12, "Sleepers", str_profession, 5);
                            break;

                        case '6':
                            ReviewSubscreen(liberals.TheDead, 12, "Liberal Martyrs and Dead Bodies", str_days_dead, 6);
                            break;

                        case '7':
                            ReviewSubscreen(liberals.Away, 12, "Liberals that are Away", str_days_return, 7);
                            break;
                    }
                }
                else if (keyinput == ']')
                {
                    if (page < maxpage)
                    {
                        page++;
                    }
                }
                else if (keyinput == '[')
                {
                    if (page > 0)
                    {
                        page--;
                    }
                }
                else if (keyinput == 'u')
                {
                    PromoteLiberal();
                }
                else if (keyinput == 'z')
                {
                    AssembleSquad(new Squad());
                }
                else if (keyinput == 't')
                {
                    AssignBase();
                }
                else
                {
                    break;
                }
            }
        }

        static void ReviewSubscreen(List<Entity> members, int people_per_page, string title, string related_string, int screen_number)
        {
            int currenty;
            int letter;
            int count;
            int position;
            int page = 0;
            int maxpage = members.Count / people_per_page;

            while (true)
            {
                currenty = 5;
                letter = 65;
                position = page * people_per_page;

                if (members.Count - page * people_per_page > people_per_page)
                {
                    count = people_per_page;
                }
                else
                {
                    count = members.Count - page * people_per_page;
                }

                Console.Clear();
                Border();

                Print(4, 2, title);
                Print(106, 2, "Page:" + page.ToString() + "/" + maxpage.ToString());
                Print(3, 4, "#----------------------------------------------------------------------------------------------------------------#");
                Print(7, 4, str_codename);
                Print(29, 4, str_skill);
                Print(47, 4, str_health);
                Print(66, 4, str_location);
                Print(87, 4, related_string);

                foreach (Entity entity in members.GetRange(position, count))
                {
                    Print(3, currenty, (char)letter + " - " + entity.Handle);
                    Print(29, currenty, entity.GetTotalSkillLevel().ToString());
                    GetHealthLabel(47, currenty, entity);
                    Print(66, currenty, entity.Location.Name);

                    switch(screen_number)
                    {
                        case 1:
                            if (entity.AssignedSquad != null)
                            {
                                Print(87, currenty, entity.AssignedSquad.Name + " / ", ConsoleColor.White);
                            }
                            else
                            {
                                Print(87, currenty, "None" + " / ", ConsoleColor.White);
                            }
                            Print(87, currenty + 1, entity.Activity.Name, ConsoleColor.White);
                            currenty += 2;
                            break;

                        case 2:
                            Print(87, currenty, entity.DaysCaptive.ToString() + " Days", ConsoleColor.Magenta);
                            currenty++;
                            break;

                        case 3:
                            Print(87, currenty, "Out in " + entity.HealTime.ToString() + " Month", ConsoleColor.Cyan);
                            currenty++;
                            break;

                        case 4:
                            Print(87, currenty, "-------", ConsoleColor.DarkGray);
                            currenty++;
                            break;

                        case 5:
                            Print(87, currenty, entity.Profession, ConsoleColor.Green);
                            currenty++;
                            break;

                        case 6:
                            Print(87, currenty, entity.DaysDead.ToString() + " Days", ConsoleColor.Magenta);
                            currenty++;
                            break;

                        case 7:
                            Print(87, currenty, entity.DaysAway.ToString() + " Days", ConsoleColor.Blue);
                            currenty++;
                            break;
                    }
                    
                    letter++;
                }

                Print(3, 17, "#----------------------------------------------------------------------------------------------------------------#");

                Print(4, 24, "Press a Letter to View Status.");
                Print(4, 25, "[] to view other liberal pages.");

                char keyinput = Console.ReadKey(true).KeyChar;

                if(keyinput >= 'a' && keyinput <= 'l')
                {
                    try
                    {
                        switch (keyinput)
                        {
                            case 'a':
                                Fullstatus(members[0 + page * people_per_page]);
                                break;
                            case 'b':
                                Fullstatus(members[1 + page * people_per_page]);
                                break;
                            case 'c':
                                Fullstatus(members[2 + page * people_per_page]);
                                break;
                            case 'd':
                                Fullstatus(members[3 + page * people_per_page]);
                                break;
                            case 'e':
                                Fullstatus(members[4 + page * people_per_page]);
                                break;
                            case 'f':
                                Fullstatus(members[5 + page * people_per_page]);
                                break;
                            case 'g':
                                Fullstatus(members[6 + page * people_per_page]);
                                break;
                            case 'h':
                                Fullstatus(members[7 + page * people_per_page]);
                                break;
                            case 'i':
                                Fullstatus(members[8 + page * people_per_page]);
                                break;
                            case 'j':
                                Fullstatus(members[9 + page * people_per_page]);
                                break;
                            case 'k':
                                Fullstatus(members[10 + page * people_per_page]);
                                break;
                            case 'l':
                                Fullstatus(members[11 + page * people_per_page]);
                                break;
                        }
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                    }
                }
                else if (keyinput == ']')
                {
                    if (page < maxpage)
                    {
                        page++;
                    }
                }
                else if (keyinput == '[')
                {
                    if (page > 0)
                    {
                        page--;
                    }
                }
                else
                {
                    break;
                }
            }
        }

        static void SquadEdit(int position, Squad squad)
        {
            if (liberals.Active[position].AssignedSquad == squad)
            {
                squad.Entities.Remove(liberals.Active[position]);
                liberals.Active[position].AssignedSquad = null;
            }
            else if (liberals.Active[position].AssignedSquad != squad && liberals.Active[position].AssignedSquad != null)
            {
                liberals.Active[position].AssignedSquad.Entities.Remove(liberals.Active[position]);

                if (liberals.Active[position].AssignedSquad.Entities.Count == 0)
                {
                    liberals.Squads.Remove(liberals.Active[position].AssignedSquad);
                }

                liberals.Active[position].AssignedSquad = squad;
                squad.Entities.Add(liberals.Active[position]);
            }
            else
            {
                squad.Entities.Add(liberals.Active[position]);
                liberals.Active[position].AssignedSquad = squad;
            }
        }

        static void AssembleSquad(Squad squad)
        {
            int currenty;
            int letter;
            int count;
            int position;
            int page = 0;
            int maxpage = liberals.Active.Count / 12;

            while (true)
            {
                currenty = 5;
                letter = 65;
                position = page * 12;

                if (liberals.Active.Count - page * 12 > 12)
                {
                    count = 12;
                }
                else
                {
                    count = liberals.Active.Count - page * 12;
                }

                Console.Clear();
                Border();

                Print(4, 2, "Assemble the squad!");
                if (squad.Name == "")
                {
                    Print(48, 2, "Squad: New Squad");
                }
                else
                {
                    Print(48, 2, "Squad: " + squad.Name);
                }
                Print(106, 2, "Page:" + page.ToString() + "/" + maxpage.ToString());
                Print(3, 4, "#----------------------------------------------------------------------------------------------------------------#");
                Print(7, 4, str_codename);
                Print(33, 4, str_skill);
                Print(55, 4, str_health);
                Print(78, 4, str_profession);

                foreach (Entity entity in liberals.Active.GetRange(position, count))
                {
                    Print(3, currenty, (char)letter + " - " + entity.Handle);
                    Print(33, currenty, entity.GetTotalSkillLevel().ToString());
                    GetHealthLabel(55, currenty, entity);
                    Print(78, currenty, entity.Profession, ConsoleColor.Green);
                    if (entity.AssignedSquad == squad)
                    {
                        Print(105, currenty, "SQUAD", ConsoleColor.Green);
                    }
                    else if (entity.AssignedSquad == null)
                    {
                    }
                    else
                    {
                        Print(105, currenty, "SQUAD", ConsoleColor.DarkYellow);
                    }
                    currenty++;
                    letter++;
                }

                Print(3, 17, "#----------------------------------------------------------------------------------------------------------------#");

                Print(4, 24, "Press a Letter to add or remove a Liberal from the squad.");
                Print(4, 25, "[] to view other liberal pages.");
                Print(4, 26, "1 - The squad is ready.");
                if(squad.Entities.Count > 0)
                {
                    Print(29, 26, "9 - Dissolve the squad.");
                }
                else
                {
                    Print(29, 26, "9 - Dissolve the squad.", ConsoleColor.DarkGray);
                }
                
                char keyinput = Console.ReadKey(true).KeyChar;

                if (keyinput >= 'a' && keyinput <= 'l')
                {
                    try
                    {
                        switch (keyinput)
                        {
                            case 'a':
                                SquadEdit(0 + page * 12, squad);
                                break;
                            case 'b':
                                SquadEdit(1 + page * 12, squad);
                                break;
                            case 'c':
                                SquadEdit(2 + page * 12, squad);
                                break;
                            case 'd':
                                SquadEdit(3 + page * 12, squad);
                                break;
                            case 'e':
                                SquadEdit(4 + page * 12, squad);
                                break;
                            case 'f':
                                SquadEdit(5 + page * 12, squad);
                                break;
                            case 'g':
                                SquadEdit(6 + page * 12, squad);
                                break;
                            case 'h':
                                SquadEdit(7 + page * 12, squad);
                                break;
                            case 'i':
                                SquadEdit(8 + page * 12, squad);
                                break;
                            case 'j':
                                SquadEdit(9 + page * 12, squad);
                                break;
                            case 'k':
                                SquadEdit(10 + page * 12, squad);
                                break;
                            case 'l':
                                SquadEdit(11 + page * 12, squad);
                                break;
                        }
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                    }
                }
                else if (keyinput == ']')
                {
                    if (page < maxpage)
                    {
                        page++;
                    }
                }
                else if (keyinput == '[')
                {
                    if (page > 0)
                    {
                        page--;
                    }
                }
                else if (keyinput == '1')
                {
                    if (squad.Entities.Count == 0)
                    {
                        if (squad == liberals.Activesquad)
                        {
                            squad.Vehicle.AssignedTo = null;
                            liberals.Squads.Remove(squad);
                            liberals.Activesquad = liberals.Squads[0];
                        }
                        else
                        {
                            squad.Vehicle.AssignedTo = null;
                            liberals.Squads.Remove(squad);
                        }
                        break;
                    }
                    else
                    {
                        if (squad.Name == "")
                        {
                            Print(4, 24, "                                                         ");
                            Print(4, 25, "                               ");
                            Print(4, 26, "                       ");
                            Print(29, 26, "                       ");
                            Print(4, 24, "What shall we designate this Liberal squad?");

                            while (true)
                            {
                                Console.SetCursorPosition(4, 25);
                                string newname = Console.ReadLine();

                                if (newname != "")
                                {
                                    squad.Name = newname;
                                    break;
                                }
                            }
                            
                            if (!liberals.Squads.Contains(squad))
                            {
                                squad.Location = squad.Entities[0].Location;
                                liberals.Squads.Add(squad);
                            }
                        }
                        break;
                    }
                }
                else if (keyinput == '9')
                {
                    if(squad.Entities.Count > 0)
                    {
                        for (int i = 0; i < squad.Entities.Count; i++)
                        {
                            squad.Entities[i].AssignedSquad = null;
                            squad.Entities.Remove(squad.Entities[i]);
                            i--;
                        }
                    }
                }
            }
        }

        static void AssignBase()
        {
            int currenty;
            int letter;
            int count;
            int position;
            int page = 0;
            int maxpage = liberals.Active.Count / 12;
            Location selectedlocation = maincity.Locations[11];
            List<Entity> templist = new List<Entity>();

            while (true)
            {
                currenty = 5;
                letter = 65;
                position = page * 12;
                templist.Clear();

                if (liberals.Active.Count - page * 12 > 12)
                {
                    count = 12;
                }
                else
                {
                    count = liberals.Active.Count - page * 12;
                }

                Console.Clear();
                Border();

                Print(4, 2, "New Bases for Squadless Liberals");
                Print(106, 2, "Page:" + page.ToString() + "/" + maxpage.ToString());
                Print(3, 4, "#----------------------------------------------------------------------------------------------------------------#");
                Print(7, 4, str_codename);
                Print(49, 4, str_current_base);
                Print(94, 4, str_new_base);

                if (maincity.Locations[11] == selectedlocation)
                {
                    Print(94, 5, "1 - " + maincity.Locations[11].Shortname, ConsoleColor.White);
                }
                else
                {
                    Print(94, 5, "1 - " + maincity.Locations[11].Shortname);
                }

                if (maincity.Locations[12] == selectedlocation)
                {
                    Print(94, 6, "2 - " + maincity.Locations[12].Shortname, ConsoleColor.White);
                }
                else
                {
                    Print(94, 6, "2 - " + maincity.Locations[12].Shortname);
                }

                if (maincity.Locations[13] == selectedlocation)
                {
                    Print(94, 7, "3 - " + maincity.Locations[13].Shortname, ConsoleColor.White);
                }
                else
                {
                    Print(94, 7, "3 - " + maincity.Locations[13].Shortname);
                }

                if (maincity.Locations[14] == selectedlocation)
                {
                    Print(94, 8, "4 - " + maincity.Locations[14].Shortname, ConsoleColor.White);
                }
                else
                {
                    Print(94, 8, "4 - " + maincity.Locations[14].Shortname);
                }

                foreach (Entity entity in liberals.Active.GetRange(position, count))
                {
                    if (entity.AssignedSquad == null)
                    {
                        Print(3, currenty, (char)letter + " - " + entity.Handle);
                        Print(49, currenty, entity.Mybase.Shortname);
                        templist.Add(entity);
                        currenty++;
                        letter++;
                    }
                }

                Print(3, 17, "#----------------------------------------------------------------------------------------------------------------#");

                Print(4, 24, "Press a Letter to assign a Base. Press a Number to select a Base.");
                Print(4, 25, "[] to view other liberal pages.");

                char keyinput = Console.ReadKey(true).KeyChar;

                if (keyinput >= 'a' && keyinput <= 'l')
                {
                    try
                    {
                        switch (keyinput)
                        {
                            case 'a':
                                templist[0 + page * 12].Mybase = selectedlocation;
                                break;
                            case 'b':
                                templist[1 + page * 12].Mybase = selectedlocation;
                                break;
                            case 'c':
                                templist[2 + page * 12].Mybase = selectedlocation;
                                break;
                            case 'd':
                                templist[3 + page * 12].Mybase = selectedlocation;
                                break;
                            case 'e':
                                templist[4 + page * 12].Mybase = selectedlocation;
                                break;
                            case 'f':
                                templist[5 + page * 12].Mybase = selectedlocation;
                                break;
                            case 'g':
                                templist[6 + page * 12].Mybase = selectedlocation;
                                break;
                            case 'h':
                                templist[7 + page * 12].Mybase = selectedlocation;
                                break;
                            case 'i':
                                templist[8 + page * 12].Mybase = selectedlocation;
                                break;
                            case 'j':
                                templist[9 + page * 12].Mybase = selectedlocation;
                                break;
                            case 'k':
                                templist[10 + page * 12].Mybase = selectedlocation;
                                break;
                            case 'l':
                                templist[11 + page * 12].Mybase = selectedlocation;
                                break;
                        }
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                    }
                }
                else if (keyinput == ']')
                {
                    if (page < maxpage)
                    {
                        page++;
                    }
                }
                else if (keyinput == '[')
                {
                    if (page > 0)
                    {
                        page--;
                    }
                }
                else if (keyinput >= '1' && keyinput <= '4')
                {
                    switch(keyinput)
                    {
                        case '1':
                            selectedlocation = maincity.Locations[11];
                            break;
                        case '2':
                            selectedlocation = maincity.Locations[12];
                            break;
                        case '3':
                            selectedlocation = maincity.Locations[13];
                            break;
                        case '4':
                            selectedlocation = maincity.Locations[14];
                            break;
                    }
                }
                else
                {
                    break;
                }
            }
        }

        static void PromoteLiberal()
        {
            int currenty;
            int letter;
            int count;
            int position;
            int page = 0;
            int maxpage = liberals.Active.Count / 12;

            while (true)
            {
                currenty = 5;
                letter = 65;
                position = page * 12;

                if (liberals.Active.Count - page * 12 > 12)
                {
                    count = 12;
                }
                else
                {
                    count = liberals.Active.Count - page * 12;
                }

                Console.Clear();
                Border();

                Print(4, 2, "Promote the Elite Liberals");
                Print(106, 2, "Page:" + page.ToString() + "/" + maxpage.ToString());
                Print(3, 4, "#----------------------------------------------------------------------------------------------------------------#");
                Print(7, 4, str_codename);
                Print(52, 4, str_current_contact);
                Print(90, 4, str_contact_after_promotion);

                foreach (Entity entity in liberals.Active.GetRange(position, count))
                {
                    Print(3, currenty, (char)letter + " - " + entity.Handle);
                    if (entity.AssignedTo != null && entity.AssignedTo.AssignedTo != null)
                    {
                        Print(52, currenty, entity.AssignedTo.Handle);
                        Print(90, currenty, entity.AssignedTo.AssignedTo.Handle);
                    }
                    else 
                    {
                        if (entity.AssignedTo != null)
                        {
                            Print(52, currenty, entity.AssignedTo.Handle);
                        }
                    }
                    
                    currenty++;
                    letter++;
                }

                Print(3, 17, "#----------------------------------------------------------------------------------------------------------------#");

                Print(4, 24, "Press a Letter to Promote a Liberal");
                Print(4, 25, "[] to view other liberal pages.");

                char keyinput = Console.ReadKey(true).KeyChar;

                if (keyinput >= 'a' && keyinput <= 'l')
                {
                    try
                    {
                        switch (keyinput)
                        {
                            case 'a':
                                if (liberals.Active[0 + page * 12].AssignedTo.AssignedTo != null)
                                {
                                    liberals.Active[0 + page * 12].AssignedTo = liberals.Active[0 + page * 12].AssignedTo.AssignedTo;
                                }
                                break;
                            case 'b':
                                if (liberals.Active[1 + page * 12].AssignedTo.AssignedTo != null)
                                {
                                    liberals.Active[1 + page * 12].AssignedTo = liberals.Active[1 + page * 12].AssignedTo.AssignedTo;
                                }
                                break;
                            case 'c':
                                if (liberals.Active[2 + page * 12].AssignedTo.AssignedTo != null)
                                {
                                    liberals.Active[2 + page * 12].AssignedTo = liberals.Active[2 + page * 12].AssignedTo.AssignedTo;
                                }
                                break;
                            case 'd':
                                if (liberals.Active[3 + page * 12].AssignedTo.AssignedTo != null)
                                {
                                    liberals.Active[3 + page * 12].AssignedTo = liberals.Active[3 + page * 12].AssignedTo.AssignedTo;
                                }
                                break;
                            case 'e':
                                if (liberals.Active[4 + page * 12].AssignedTo.AssignedTo != null)
                                {
                                    liberals.Active[4 + page * 12].AssignedTo = liberals.Active[4 + page * 12].AssignedTo.AssignedTo;
                                }
                                break;
                            case 'f':
                                if (liberals.Active[5 + page * 12].AssignedTo.AssignedTo != null)
                                {
                                    liberals.Active[5 + page * 12].AssignedTo = liberals.Active[5 + page * 12].AssignedTo.AssignedTo;
                                }
                                break;
                            case 'g':
                                if (liberals.Active[6 + page * 12].AssignedTo.AssignedTo != null)
                                {
                                    liberals.Active[6 + page * 12].AssignedTo = liberals.Active[6 + page * 12].AssignedTo.AssignedTo;
                                }
                                break;
                            case 'h':
                                if (liberals.Active[7 + page * 12].AssignedTo.AssignedTo != null)
                                {
                                    liberals.Active[7 + page * 12].AssignedTo = liberals.Active[7 + page * 12].AssignedTo.AssignedTo;
                                }
                                break;
                            case 'i':
                                if (liberals.Active[8 + page * 12].AssignedTo.AssignedTo != null)
                                {
                                    liberals.Active[8 + page * 12].AssignedTo = liberals.Active[8 + page * 12].AssignedTo.AssignedTo;
                                }
                                break;
                            case 'j':
                                if (liberals.Active[9 + page * 12].AssignedTo.AssignedTo != null)
                                {
                                    liberals.Active[9 + page * 12].AssignedTo = liberals.Active[9 + page * 12].AssignedTo.AssignedTo;
                                }
                                break;
                            case 'k':
                                if (liberals.Active[10 + page * 12].AssignedTo.AssignedTo != null)
                                {
                                    liberals.Active[10 + page * 12].AssignedTo = liberals.Active[10 + page * 12].AssignedTo.AssignedTo;
                                }
                                break;
                            case 'l':
                                if (liberals.Active[11 + page * 12].AssignedTo.AssignedTo != null)
                                {
                                    liberals.Active[11 + page * 12].AssignedTo = liberals.Active[11 + page * 12].AssignedTo.AssignedTo;
                                }
                                break;
                        }
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                    }
                }
                else if (keyinput == ']')
                {
                    if (page < maxpage)
                    {
                        page++;
                    }
                }
                else if (keyinput == '[')
                {
                    if (page > 0)
                    {
                        page--;
                    }
                }
                else
                {
                    break;
                }
            }
        }

        static void AssignActivity()
        {
            int currenty;
            int letter;
            int count;
            int position;
            int page = 0;
            int maxpage = liberals.Active.Count / 12;

            while (true)
            {
                currenty = 5;
                letter = 65;
                position = page * 12;

                if (liberals.Active.Count - page * 12 > 12)
                {
                    count = 12;
                }
                else
                {
                    count = liberals.Active.Count - page * 12;
                }

                Console.Clear();
                Border();

                Print(4, 2, "Activate Uninvolved Liberals");
                Print(106, 2, "Page:" + page.ToString() + "/" + maxpage.ToString());
                Print(3, 4, "#----------------------------------------------------------------------------------------------------------------#");
                Print(7, 4, str_codename);
                Print(29, 4, str_skill);
                Print(47, 4, str_health);
                Print(66, 4, str_location);
                Print(87, 4, str_activity);

                foreach (Entity entity in liberals.Active.GetRange(position, count))
                {
                        Print(3, currenty, (char)letter + " - " + entity.Handle);
                        Print(29, currenty, entity.GetTotalSkillLevel().ToString());
                        GetHealthLabel(47, currenty, entity);
                        Print(66, currenty, entity.Location.Shortname);
                        Print(87, currenty, entity.Activity.Name, ConsoleColor.White);
                        currenty++;
                        letter++;
                }

                Print(3, 17, "#----------------------------------------------------------------------------------------------------------------#");

                Print(4, 24, "Press a Letter to Assign an Activity.");
                Print(4, 25, "[] to view other liberal pages.");
                Print(4, 26, "Press Z to assign simple tasks in bulk.");

                char keyinput = Console.ReadKey(true).KeyChar;

                if (keyinput >= 'a' && keyinput <= 'l')
                {
                    try
                    {
                        switch (keyinput)
                        {
                            case 'a':
                                AssignActivitySubscreen(liberals.Active[0 + page * 12]);
                                break;
                            case 'b':
                                AssignActivitySubscreen(liberals.Active[1 + page * 12]);
                                break;
                            case 'c':
                                AssignActivitySubscreen(liberals.Active[2 + page * 12]);
                                break;
                            case 'd':
                                AssignActivitySubscreen(liberals.Active[3 + page * 12]);
                                break;
                            case 'e':
                                AssignActivitySubscreen(liberals.Active[4 + page * 12]);
                                break;
                            case 'f':
                                AssignActivitySubscreen(liberals.Active[5 + page * 12]);
                                break;
                            case 'g':
                                AssignActivitySubscreen(liberals.Active[6 + page * 12]);
                                break;
                            case 'h':
                                AssignActivitySubscreen(liberals.Active[7 + page * 12]);
                                break;
                            case 'i':
                                AssignActivitySubscreen(liberals.Active[8 + page * 12]);
                                break;
                            case 'j':
                                AssignActivitySubscreen(liberals.Active[9 + page * 12]);
                                break;
                            case 'k':
                                AssignActivitySubscreen(liberals.Active[10 + page * 12]);
                                break;
                            case 'l':
                                AssignActivitySubscreen(liberals.Active[11 + page * 12]);
                                break;
                        }
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                    }
                }
                else if (keyinput == ']')
                {
                    if (page < maxpage)
                    {
                        page++;
                    }
                }
                else if (keyinput == '[')
                {
                    if (page > 0)
                    {
                        page--;
                    }
                }
                else if (keyinput == 'z')
                {
                    AssignActivityBulk();
                }
                else
                {
                    break;
                }
            }
        }

        static void AssignActivitySubscreen(Entity entity)
        {
            while (true)
            {
                Console.Clear();
                Border();

                Print(4, 2, $"Taking Action: What will {entity.Handle} be doing today?");
                Print(3, 4, "#----------------------------------------------------------------------------------------------------------------#");
                Print(5, 4, entity.Handle + ", " + entity.Title);
                GetHealthLabel(80, 4, entity);

                Print(4, 6, "Heart:        " + entity.Heart);
                Print(4, 7, "Intelligence: " + entity.Intelligence);
                Print(4, 8, "Wisdom:       " + entity.Wisdom);
                Print(4, 9, "Health:       " + entity.MaxHealth + "/" + entity.Health);
                Print(4, 10, "Agility:      " + entity.Agility);
                Print(4, 11, "Strength:     " + entity.Strength);
                Print(4, 12, "Charisma:     " + entity.Charisma);
                Print(42, 6, "Juice: " + entity.Juice);
                Print(42, 7, "Next:  ");

                if (entity.Juice < 500)
                {
                    if (entity.Juice < 0)
                    {
                        Print(49, 7, "0");
                    }
                    else if (entity.Juice < 10)
                    {
                        Print(49, 7, "10");
                    }
                    else if (entity.Juice < 50)
                    {
                        Print(49, 7, "50");
                    }
                    else if (entity.Juice < 100)
                    {
                        Print(49, 7, "100");
                    }
                    else if (entity.Juice < 200)
                    {
                        Print(49, 7, "200");
                    }
                    else
                    {
                        Print(49, 7, "500");
                    }
                }

                Print(80, 6, "Handtohand:    " + entity.Handtohand);
                Print(80, 7, "Knife:         " + entity.Knife);
                Print(80, 8, "Club:          " + entity.Club);
                Print(80, 9, "Sword:         " + entity.Sword);
                Print(80, 10, "Axe:           " + entity.Axe);
                Print(80, 11, "Spear:         " + entity.Spear);
                Print(80, 12, "Pistol:        " + entity.Pistol);
                Print(80, 13, "Rifle:         " + entity.Rifle);
                Print(80, 14, "Assaultrifle:  " + entity.Assaultrifle);
                Print(100, 6, "Persuasion:    " + entity.Persuasion);
                Print(100, 7, "Law:           " + entity.Law);
                Print(100, 8, "Security:      " + entity.Security);
                Print(100, 9, "Disguise:      " + entity.Disguise);
                Print(100, 10, "Computers:     " + entity.Computers);
                Print(100, 11, "Garmentmaking: " + entity.Garmentmaking);
                Print(100, 12, "Driving:       " + entity.Driving);
                Print(100, 13, "Writing:       " + entity.Writing);

                Print(4, 16, "Weapon: " + entity.GetWeaponName());
                Print(42, 16, "Armour: " + entity.GetArmourName());
                Print(80, 16, "Transport: " + entity.AssignedSquad.GetVehicle(entity));

                Print(3, 17, "#----------------------------------------------------------------------------------------------------------------#");

                Print(4, 19, "A - Perpetrating random acts of Liberal Disobedience.");
                Print(4, 20, "D - Soliciting Donations.");
                Print(4, 21, "C - Making Clothing.");
                Print(4, 22, "H - Tending to a Conservative hostage.");
                Print(4, 23, "S - Stealing a Car.");
                Print(4, 24, "Z - Dispose of bodies.");
                Print(67, 19, "B - Selling Brownies.");
                Print(67, 20, "R - Repairing Clothing.");
                Print(67, 21, "P - Surfing the Net for opinion polls.");

                Print(4, 26, "Any other key - Nothing for now.");

                char keyinput = Console.ReadKey(true).KeyChar;

                if (keyinput == 'a')
                {
                    CausingTrouble(entity);
                    break;
                }
                else if (keyinput == 'd')
                {
                    entity.Activity = new Activity("Soliciting Donations", ActivityTypes.FUNDS_LEGAL);
                    break;
                }
                else if (keyinput == 'c')
                {
                    MakeClothes(entity);
                    break;
                }
                else if (keyinput == 'h')
                {
                    TendingHostage(entity);
                    break;
                }
                else if (keyinput == 's')
                {
                    entity.Activity = new Activity("Stealing a Car", ActivityTypes.STEALCARS);
                    break;
                }
                else if (keyinput == 'z')
                {
                    entity.Activity = new Activity("Disposing of Bodies", ActivityTypes.BURY);
                    break;
                }
                else if (keyinput == 'b')
                {
                    entity.Activity = new Activity("Selling Brownies", ActivityTypes.FUNDS_ILLEGAL);
                    break;
                }
                else if (keyinput == 'r')
                {
                    entity.Activity = new Activity("Repairing Clothing", ActivityTypes.REPAIR_ARMOUR);
                    break;
                }
                else if (keyinput == 'p')
                {
                    entity.Activity = new Activity("Gathering Opinion Info", ActivityTypes.POLLS);
                    break;
                }
                else
                {
                    entity.Activity = new Activity("Hanging Out", ActivityTypes.NONE);
                    break;
                }
            }
        }

        static void AssignActivityBulk()
        {
            int currenty;
            int letter;
            int count;
            int position;
            int page = 0;
            int maxpage = liberals.Active.Count / 12;
            Activity selectedactivity = new Activity("Causing Trouble", ActivityTypes.TROUBLE);
            selectedactivity.Funding = 0;

            while (true)
            {
                currenty = 5;
                letter = 65;
                position = page * 12;

                if (liberals.Active.Count - page * 12 > 12)
                {
                    count = 12;
                }
                else
                {
                    count = liberals.Active.Count - page * 12;
                }

                Console.Clear();
                Border();

                Print(4, 2, "Activate Uninvolved Liberals");
                Print(106, 2, "Page:" + page.ToString() + "/" + maxpage.ToString());
                Print(3, 4, "#----------------------------------------------------------------------------------------------------------------#");
                Print(7, 4, str_codename);
                Print(49, 4, str_current_activity, ConsoleColor.White);
                Print(89, 4, str_bulk_activity);

                if (selectedactivity.Name == "Causing Trouble" && selectedactivity.Funding == 0)
                {
                    Print(89, 5, "1 - Causing Trouble ($0).", ConsoleColor.White);
                }
                else
                {
                    Print(89, 5, "1 - Causing Trouble ($0).");
                }

                if (selectedactivity.Name == "Causing Trouble" && selectedactivity.Funding == 20)
                {
                    Print(89, 6, "2 - Causing Trouble ($20).", ConsoleColor.White);
                }
                else
                {
                    Print(89, 6, "2 - Causing Trouble ($20).");
                }

                if (selectedactivity.Name == "Causing Trouble" && selectedactivity.Funding == 50)
                {
                    Print(89, 7, "3 - Causing Trouble ($50).", ConsoleColor.White);
                }
                else
                {
                    Print(89, 7, "3 - Causing Trouble ($50).");
                }

                if (selectedactivity.Name == "Causing Trouble" && selectedactivity.Funding == 100)
                {
                    Print(89, 8, "4 - Causing Trouble ($100).", ConsoleColor.White);
                }
                else
                {
                    Print(89, 8, "4 - Causing Trouble ($100).");
                }

                if (selectedactivity.Name == "Causing Trouble" && selectedactivity.Funding == 500)
                {
                    Print(89, 9, "5 - Causing Trouble ($500).", ConsoleColor.White);
                }
                else
                {
                    Print(89, 9, "5 - Causing Trouble ($500).");
                }

                if (selectedactivity.Name == "Soliciting Donations")
                {
                    Print(89, 10, "6 - Soliciting Donations.", ConsoleColor.White);
                }
                else
                {
                    Print(89, 10, "6 - Soliciting Donations.");
                }

                if (selectedactivity.Name == "Selling Brownies")
                {
                    Print(89, 11, "7 - Selling Brownies.", ConsoleColor.White);
                }
                else
                {
                    Print(89, 11, "7 - Selling Brownies.");
                }

                if (selectedactivity.Name == "Stealing a Car")
                {
                    Print(89, 12, "8 - Stealing a Car.", ConsoleColor.White);
                }
                else
                {
                    Print(89, 12, "8 - Stealing a Car.");
                }

                foreach (Entity entity in liberals.Active.GetRange(position, count))
                {
                    Print(3, currenty, (char)letter + " - " + entity.Handle);
                    Print(49, currenty, entity.Activity.Name);
                    currenty++;
                    letter++;
                }

                Print(3, 17, "#----------------------------------------------------------------------------------------------------------------#");

                Print(4, 24, "Press a Letter to Assign an Activity. Press a Number to select an Activity.");
                Print(4, 25, "[] to view other liberal pages.");

                char keyinput = Console.ReadKey(true).KeyChar;

                if (keyinput >= 'a' && keyinput <= 'l')
                {
                    try
                    {
                        switch (keyinput)
                        {
                            case 'a':
                                liberals.Active[0 + page * 12].Activity = new Activity(selectedactivity.Name, selectedactivity.ActivityType);
                                liberals.Active[0 + page * 12].Activity.Funding = selectedactivity.Funding;
                                break;
                            case 'b':
                                liberals.Active[1 + page * 12].Activity = new Activity(selectedactivity.Name, selectedactivity.ActivityType);
                                liberals.Active[1 + page * 12].Activity.Funding = selectedactivity.Funding;
                                break;
                            case 'c':
                                liberals.Active[2 + page * 12].Activity = new Activity(selectedactivity.Name, selectedactivity.ActivityType);
                                liberals.Active[2 + page * 12].Activity.Funding = selectedactivity.Funding;
                                break;
                            case 'd':
                                liberals.Active[3 + page * 12].Activity = new Activity(selectedactivity.Name, selectedactivity.ActivityType);
                                liberals.Active[3 + page * 12].Activity.Funding = selectedactivity.Funding;
                                break;
                            case 'e':
                                liberals.Active[4 + page * 12].Activity = new Activity(selectedactivity.Name, selectedactivity.ActivityType);
                                liberals.Active[4 + page * 12].Activity.Funding = selectedactivity.Funding;
                                break;
                            case 'f':
                                liberals.Active[5 + page * 12].Activity = new Activity(selectedactivity.Name, selectedactivity.ActivityType);
                                liberals.Active[5 + page * 12].Activity.Funding = selectedactivity.Funding;
                                break;
                            case 'g':
                                liberals.Active[6 + page * 12].Activity = new Activity(selectedactivity.Name, selectedactivity.ActivityType);
                                liberals.Active[6 + page * 12].Activity.Funding = selectedactivity.Funding;
                                break;
                            case 'h':
                                liberals.Active[7 + page * 12].Activity = new Activity(selectedactivity.Name, selectedactivity.ActivityType);
                                liberals.Active[7 + page * 12].Activity.Funding = selectedactivity.Funding;
                                break;
                            case 'i':
                                liberals.Active[8 + page * 12].Activity = new Activity(selectedactivity.Name, selectedactivity.ActivityType);
                                liberals.Active[8 + page * 12].Activity.Funding = selectedactivity.Funding;
                                break;
                            case 'j':
                                liberals.Active[9 + page * 12].Activity = new Activity(selectedactivity.Name, selectedactivity.ActivityType);
                                liberals.Active[9 + page * 12].Activity.Funding = selectedactivity.Funding;
                                break;
                            case 'k':
                                liberals.Active[10 + page * 12].Activity = new Activity(selectedactivity.Name, selectedactivity.ActivityType);
                                liberals.Active[10 + page * 12].Activity.Funding = selectedactivity.Funding;
                                break;
                            case 'l':
                                liberals.Active[11 + page * 12].Activity = new Activity(selectedactivity.Name, selectedactivity.ActivityType);
                                liberals.Active[11 + page * 12].Activity.Funding = selectedactivity.Funding;
                                break;
                        }
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                    }
                }
                else if (keyinput == ']')
                {
                    if (page < maxpage)
                    {
                        page++;
                    }
                }
                else if (keyinput == '[')
                {
                    if (page > 0)
                    {
                        page--;
                    }
                }
                else if (keyinput >= '1' && keyinput <= '8')
                {
                    switch (keyinput)
                    {
                        case '1':
                            selectedactivity = new Activity("Causing Trouble", ActivityTypes.TROUBLE);
                            selectedactivity.Funding = 0;
                            break;
                        case '2':
                            selectedactivity = new Activity("Causing Trouble", ActivityTypes.TROUBLE);
                            selectedactivity.Funding = 20;
                            break;
                        case '3':
                            selectedactivity = new Activity("Causing Trouble", ActivityTypes.TROUBLE);
                            selectedactivity.Funding = 50;
                            break;
                        case '4':
                            selectedactivity = new Activity("Causing Trouble", ActivityTypes.TROUBLE);
                            selectedactivity.Funding = 100;
                            break;
                        case '5':
                            selectedactivity = new Activity("Causing Trouble", ActivityTypes.TROUBLE);
                            selectedactivity.Funding = 500;
                            break;
                        case '6':
                            selectedactivity = new Activity("Soliciting Donations", ActivityTypes.FUNDS_LEGAL);
                            break;
                        case '7':
                            selectedactivity = new Activity("Selling Brownies", ActivityTypes.FUNDS_ILLEGAL);
                            break;
                        case '8':
                            selectedactivity = new Activity("Stealing a Car", ActivityTypes.STEALCARS);
                            break;
                    }
                }
                else
                {
                    break;
                }
            }
        }

        static void CausingTrouble(Entity entity)
        {
            while (true)
            {
                Console.Clear();
                Border();

                Print(4, 2, "Select a Funding Level for this Operation:");
                Print(3, 4, "#----------------------------------------------------------------------------------------------------------------#");
                Print(3, 5, $"A - Don't spend anything. {entity.Handle} just needs something constructive to do.");
                Print(3, 6, "B - $20 per day. Some minor purchases are needed.");
                Print(3, 7, "C - $50 per day. Disobedience costs money.");
                Print(3, 8, "D - $100 per day. Enough to be really disobedient.");
                Print(3, 9, $"E - $500 per day. The Machine will buckle under the weight of {entity.Handle}'s Numerous and Varied Liberal Acts.");
                Print(3, 11, $"X - On second thought, this isn't a job for {entity.Handle}.");
                Print(3, 12, "#----------------------------------------------------------------------------------------------------------------#");

                char keyinput = Console.ReadKey(true).KeyChar;

                if (keyinput == 'a')
                {
                    entity.Activity = new Activity("Causing Trouble", ActivityTypes.TROUBLE);
                    entity.Activity.Funding = 0;
                    break;
                }
                else if (keyinput == 'b')
                {
                    entity.Activity = new Activity("Causing Trouble", ActivityTypes.TROUBLE);
                    entity.Activity.Funding = 20;
                    break;
                }
                else if (keyinput == 'c')
                {
                    entity.Activity = new Activity("Causing Trouble", ActivityTypes.TROUBLE);
                    entity.Activity.Funding = 50;
                    break;
                }
                else if (keyinput == 'd')
                {
                    entity.Activity = new Activity("Causing Trouble", ActivityTypes.TROUBLE);
                    entity.Activity.Funding = 100;
                    break;
                }
                else if (keyinput == 'e')
                {
                    entity.Activity = new Activity("Causing Trouble", ActivityTypes.TROUBLE);
                    entity.Activity.Funding = 500;
                    break;
                }
                else if (keyinput == 'x')
                {
                    entity.Activity = new Activity("Hanging Out", ActivityTypes.NONE);
                    break;
                }
            }
        }

        static void TendingHostage(Entity entity)
        {
            int currenty;
            int letter;
            int count;
            int position;
            int page = 0;
            int maxpage = liberals.Hostages.Count / 12;

            while (true)
            {
                currenty = 5;
                letter = 65;
                position = page * 12;

                if (liberals.Hostages.Count - page * 12 > 12)
                {
                    count = 12;
                }
                else
                {
                    count = liberals.Hostages.Count - page * 12;
                }

                Console.Clear();
                Border();

                Print(4, 2, $"Which hostage will {entity.Handle} be watching over?");
                Print(106, 2, "Page:" + page.ToString() + "/" + maxpage.ToString());
                Print(3, 4, "#----------------------------------------------------------------------------------------------------------------#");
                Print(7, 4, str_codename);
                Print(29, 4, str_skill);
                Print(47, 4, str_health);
                Print(66, 4, str_location);
                Print(87, 4, str_days_captive);

                foreach (Entity captive in liberals.Hostages.GetRange(position, count))
                {
                    Print(3, currenty, (char)letter + " - " + captive.Handle);
                    Print(29, currenty, captive.GetTotalSkillLevel().ToString());
                    GetHealthLabel(47, currenty, captive);
                    Print(66, currenty, captive.Location.Name);
                    Print(87, currenty, captive.DaysCaptive.ToString() + " Days", ConsoleColor.Magenta);
                    currenty++;
                    letter++;
                }

                Print(3, 17, "#----------------------------------------------------------------------------------------------------------------#");

                Print(4, 24, "Press a Letter to select a Conservative.");
                Print(4, 25, "[] to view other liberal pages.");

                char keyinput = Console.ReadKey(true).KeyChar;

                if (keyinput >= 'a' && keyinput <= 'l')
                {
                    try
                    {
                        switch (keyinput)
                        {
                            case 'a':
                                HostageFunding(entity, liberals.Hostages[0 + page * 12]);
                                break;
                            case 'b':
                                HostageFunding(entity, liberals.Hostages[1 + page * 12]);
                                break;
                            case 'c':
                                HostageFunding(entity, liberals.Hostages[2 + page * 12]);
                                break;
                            case 'd':
                                HostageFunding(entity, liberals.Hostages[3 + page * 12]);
                                break;
                            case 'e':
                                HostageFunding(entity, liberals.Hostages[4 + page * 12]);
                                break;
                            case 'f':
                                HostageFunding(entity, liberals.Hostages[5 + page * 12]);
                                break;
                            case 'g':
                                HostageFunding(entity, liberals.Hostages[6 + page * 12]);
                                break;
                            case 'h':
                                HostageFunding(entity, liberals.Hostages[7 + page * 12]);
                                break;
                            case 'i':
                                HostageFunding(entity, liberals.Hostages[8 + page * 12]);
                                break;
                            case 'j':
                                HostageFunding(entity, liberals.Hostages[9 + page * 12]);
                                break;
                            case 'k':
                                HostageFunding(entity, liberals.Hostages[10 + page * 12]);
                                break;
                            case 'l':
                                HostageFunding(entity, liberals.Hostages[11 + page * 12]);
                                break;
                        }
                        break;
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                    }
                }
                else if (keyinput == ']')
                {
                    if (page < maxpage)
                    {
                        page++;
                    }
                }
                else if (keyinput == '[')
                {
                    if (page > 0)
                    {
                        page--;
                    }
                }
                else
                {
                    break;
                }
            }
        }

        static void HostageFunding(Entity entity, Entity hostage)
        {
            while (true)
            {
                Console.Clear();
                Border();

                Print(4, 2, "Select a Funding Level for this Operation:");
                Print(3, 4, "#----------------------------------------------------------------------------------------------------------------#");
                Print(3, 5, $"A - Don't spend anything. {entity.Handle} is just on watch duty.");
                Print(3, 6, $"B - Don't spend anything. {entity.Handle} will turn the prisoner over time.");
                Print(3, 7, "C - $20 per day. Enough for some props.");
                Print(3, 8, $"D - $50 per day. {entity.Handle} will go for a thrifty indoctrination.");
                Print(3, 9, $"E - $100 per day. {entity.Handle} needs enough freedom to be creative.");
                Print(3, 10, "F - $500 per day. It is imperative that the Conservative be turned quickly.");
                Print(3, 11, "K - This Conservative has become a liability and needs to be terminated.");
                Print(3, 13, $"X - On second thought, this isn't a job for {entity.Handle}.");
                Print(3, 14, "#----------------------------------------------------------------------------------------------------------------#");

                char keyinput = Console.ReadKey(true).KeyChar;

                if (keyinput == 'a')
                {
                    entity.Activity = new Activity($"Tending to {hostage.Handle}", ActivityTypes.HOSTAGETENDING);
                    entity.Activity.Funding = 0;
                    entity.Activity.Hostage = hostage;
                    break;
                }
                else if (keyinput == 'b')
                {
                    entity.Activity = new Activity($"Tending to {hostage.Handle}", ActivityTypes.HOSTAGETENDING);
                    entity.Activity.Funding = 1;
                    entity.Activity.Hostage = hostage;
                    break;
                }
                else if (keyinput == 'c')
                {
                    entity.Activity = new Activity($"Tending to {hostage.Handle}", ActivityTypes.HOSTAGETENDING);
                    entity.Activity.Funding = 20;
                    entity.Activity.Hostage = hostage;
                    break;
                }
                else if (keyinput == 'd')
                {
                    entity.Activity = new Activity($"Tending to {hostage.Handle}", ActivityTypes.HOSTAGETENDING);
                    entity.Activity.Funding = 50;
                    entity.Activity.Hostage = hostage;
                    break;
                }
                else if (keyinput == 'e')
                {
                    entity.Activity = new Activity($"Tending to {hostage.Handle}", ActivityTypes.HOSTAGETENDING);
                    entity.Activity.Funding = 100;
                    entity.Activity.Hostage = hostage;
                    break;
                }
                else if (keyinput == 'f')
                {
                    entity.Activity = new Activity($"Tending to {hostage.Handle}", ActivityTypes.HOSTAGETENDING);
                    entity.Activity.Funding = 500;
                    entity.Activity.Hostage = hostage;
                    break;
                }
                else if (keyinput == 'k')
                {
                    entity.Activity = new Activity($"Tending to {hostage.Handle}", ActivityTypes.HOSTAGETENDING);
                    entity.Activity.Funding = 666;
                    entity.Activity.Hostage = hostage;
                    break;
                }
                else if (keyinput == 'x')
                {
                    entity.Activity = new Activity("Hanging Out", ActivityTypes.NONE);
                    break;
                }
            }
        }

        static void MakeClothes(Entity entity)
        {
            int currenty;
            int letter;
            int count;
            int position;
            int page = 0;
            int maxpage = liberals.CraftableArmours.Count / 17;

            while (true)
            {
                currenty = 5;
                letter = 65;
                position = page * 17;

                if (liberals.CraftableArmours.Count - page * 17 > 17)
                {
                    count = 17;
                }
                else
                {
                    count = liberals.CraftableArmours.Count - page * 17;
                }

                Console.Clear();
                Border();

                Print(4, 2, $"Which will {entity.Handle} try to make? (Note: Half Cost if you have cloth)");
                Print(106, 2, "Page:" + page.ToString() + "/" + maxpage.ToString());
                Print(3, 4, "#----------------------------------------------------------------------------------------------------------------#");
                Print(7, 4, str_name);
                Print(55, 4, str_difficulty);
                Print(91, 4, str_cost);

                foreach (Armour armour in liberals.CraftableArmours.GetRange(position, count))
                {
                    Print(3, currenty, (char)letter + " - " + armour.Name);

                    switch (armour.MakeDifficulty(entity))
                    {
                        case 0:
                            Print(55, currenty, "Simple", ConsoleColor.Green);
                            break;
                        case 1:
                            Print(55, currenty, "Very Easy", ConsoleColor.Cyan);
                            break;
                        case 2:
                            Print(55, currenty, "Easy", ConsoleColor.Cyan);
                            break;
                        case 3:
                            Print(55, currenty, "Below Average", ConsoleColor.Blue);
                            break;
                        case 4:
                            Print(55, currenty, "Average", ConsoleColor.White);
                            break;
                        case 5:
                            Print(55, currenty, "Above Average", ConsoleColor.White);
                            break;
                        case 6:
                            Print(55, currenty, "Hard", ConsoleColor.Yellow);
                            break;
                        case 7:
                            Print(55, currenty, "Very Hard", ConsoleColor.DarkMagenta);
                            break;
                        case 8:
                            Print(55, currenty, "Extremely Difficult", ConsoleColor.Magenta);
                            break;
                        case 9:
                            Print(55, currenty, "Nearly Impossible", ConsoleColor.DarkRed);
                            break;
                        default:
                            Print(55, currenty, "Impossible", ConsoleColor.Red);
                            break;
                    }

                    Print(91, currenty, "$" + armour.Cost.ToString(), ConsoleColor.Green);
                    currenty++;
                    letter++;
                }

                Print(3, 22, "#----------------------------------------------------------------------------------------------------------------#");

                Print(4, 24, "Press a Letter to select a Type of Clothing");
                Print(4, 25, "[] to view other liberal pages.");

                char keyinput = Console.ReadKey(true).KeyChar;

                if (keyinput >= 'a' && keyinput <= 'l')
                {
                    try
                    {
                        switch (keyinput)
                        {
                            case 'a':
                                entity.Activity = new Activity($"Make {liberals.CraftableArmours[0 + page * 17].Name}", ActivityTypes.MAKE_ARMOUR);
                                entity.Activity.Armour = liberals.CraftableArmours[0 + page * 17];
                                break;
                            case 'b':
                                entity.Activity = new Activity($"Make {liberals.CraftableArmours[1 + page * 17].Name}", ActivityTypes.MAKE_ARMOUR);
                                entity.Activity.Armour = liberals.CraftableArmours[1 + page * 17];
                                break;
                            case 'c':
                                entity.Activity = new Activity($"Make {liberals.CraftableArmours[2 + page * 17].Name}", ActivityTypes.MAKE_ARMOUR);
                                entity.Activity.Armour = liberals.CraftableArmours[2 + page * 17];
                                break;
                            case 'd':
                                entity.Activity = new Activity($"Make {liberals.CraftableArmours[3 + page * 17].Name}", ActivityTypes.MAKE_ARMOUR);
                                entity.Activity.Armour = liberals.CraftableArmours[3 + page * 17];
                                break;
                            case 'e':
                                entity.Activity = new Activity($"Make {liberals.CraftableArmours[4 + page * 17].Name}", ActivityTypes.MAKE_ARMOUR);
                                entity.Activity.Armour = liberals.CraftableArmours[4 + page * 17];
                                break;
                            case 'f':
                                entity.Activity = new Activity($"Make {liberals.CraftableArmours[5 + page * 17].Name}", ActivityTypes.MAKE_ARMOUR);
                                entity.Activity.Armour = liberals.CraftableArmours[5 + page * 17];
                                break;
                            case 'g':
                                entity.Activity = new Activity($"Make {liberals.CraftableArmours[6 + page * 17].Name}", ActivityTypes.MAKE_ARMOUR);
                                entity.Activity.Armour = liberals.CraftableArmours[6 + page * 17];
                                break;
                            case 'h':
                                entity.Activity = new Activity($"Make {liberals.CraftableArmours[7 + page * 17].Name}", ActivityTypes.MAKE_ARMOUR);
                                entity.Activity.Armour = liberals.CraftableArmours[7 + page * 17];
                                break;
                            case 'i':
                                entity.Activity = new Activity($"Make {liberals.CraftableArmours[8 + page * 17].Name}", ActivityTypes.MAKE_ARMOUR);
                                entity.Activity.Armour = liberals.CraftableArmours[8 + page * 17];
                                break;
                            case 'j':
                                entity.Activity = new Activity($"Make {liberals.CraftableArmours[9 + page * 17].Name}", ActivityTypes.MAKE_ARMOUR);
                                entity.Activity.Armour = liberals.CraftableArmours[9 + page * 17];
                                break;
                            case 'k':
                                entity.Activity = new Activity($"Make {liberals.CraftableArmours[10 + page * 17].Name}", ActivityTypes.MAKE_ARMOUR);
                                entity.Activity.Armour = liberals.CraftableArmours[10 + page * 17];
                                break;
                            case 'l':
                                entity.Activity = new Activity($"Make {liberals.CraftableArmours[11 + page * 17].Name}", ActivityTypes.MAKE_ARMOUR);
                                entity.Activity.Armour = liberals.CraftableArmours[11 + page * 17];
                                break;
                            case 'm':
                                entity.Activity = new Activity($"Make {liberals.CraftableArmours[12 + page * 17].Name}", ActivityTypes.MAKE_ARMOUR);
                                entity.Activity.Armour = liberals.CraftableArmours[12 + page * 17];
                                break;
                            case 'n':
                                entity.Activity = new Activity($"Make {liberals.CraftableArmours[13 + page * 17].Name}", ActivityTypes.MAKE_ARMOUR);
                                entity.Activity.Armour = liberals.CraftableArmours[13 + page * 17];
                                break;
                            case 'o':
                                entity.Activity = new Activity($"Make {liberals.CraftableArmours[14 + page * 17].Name}", ActivityTypes.MAKE_ARMOUR);
                                entity.Activity.Armour = liberals.CraftableArmours[14 + page * 17];
                                break;
                            case 'p':
                                entity.Activity = new Activity($"Make {liberals.CraftableArmours[15 + page * 17].Name}", ActivityTypes.MAKE_ARMOUR);
                                entity.Activity.Armour = liberals.CraftableArmours[15 + page * 17];
                                break;
                            case 'q':
                                entity.Activity = new Activity($"Make {liberals.CraftableArmours[16 + page * 17].Name}", ActivityTypes.MAKE_ARMOUR);
                                entity.Activity.Armour = liberals.CraftableArmours[16 + page * 17];
                                break;
                        }
                        break;
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                    }
                }
                else if (keyinput == ']')
                {
                    if (page < maxpage)
                    {
                        page++;
                    }
                }
                else if (keyinput == '[')
                {
                    if (page > 0)
                    {
                        page--;
                    }
                }
                else
                {
                    break;
                }
            }
        }

        static void Titlescreen()
        {
            Console.Clear();
            Border();

            string str = "Liberal Crime Squad (Remake)";
            Print((Console.BufferWidth / 2) - (str.Length / 2), 4, str);

            str = "Inspired by the 1983 version of Oubliette";
            Print((Console.BufferWidth / 2) - (str.Length / 2), 6, str);

            str = "v1 Copyright (C) 2020, Josh Carter";
            Print((Console.BufferWidth / 2) - (str.Length / 2), 8, str);

            str = "A remake of the original game by";
            Print((Console.BufferWidth / 2) - (str.Length / 2), 14, str);

            str = "Tarn Adams, v3.06 Copyright (C) 2002-4";
            Print((Console.BufferWidth / 2) - (str.Length / 2), 15, str);

            str = "A Bay 12 Games Production";
            Print((Console.BufferWidth / 2) - (str.Length / 2), 16, str);

            str = "www.bay12games.com";
            Print((Console.BufferWidth / 2) - (str.Length / 2), 17, str);

            str = "Press ESC now to quit.  Quitting later causes your progress to be saved.";
            Print((Console.BufferWidth / 2) - (str.Length / 2), 20, str);

            str = "Press any other key to pursue your Liberal Agenda!";
            Print((Console.BufferWidth / 2) - (str.Length / 2), 22, str);

            if (Console.ReadKey().Key == ConsoleKey.Escape)
            {
                return;
            }

            CharacterCreation();
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

                Print(4, 2, "Insight into a Revolution:  My Traumatic Childhood");

                switch (q)
                {
                    case 0:
                        Print(4, 4, "The day I was born in 1984...");
                        Print(4, 6, "A - was the day the Sandinista Front won the elections in Nicaragua.");
                        Print(4, 8, "B - was the 3rd anniversary of the assassination attempt on Ronald Reagan.");
                        Print(4, 10, "C - was the day the Macintosh was introduced.");
                        Print(4, 14, "My parents named me " + newcharacter.Fullname + ".");
                        break;

                    case 1:
                        Print(4, 4, "When I was bad...");
                        Print(4, 6, "A - my parents argued with each other about me, but I was never punished.");
                        Print(4, 8, "B - my father beat me.  I learned to take a punch earlier than most.");
                        Print(4, 10, "C - I was sent to my room, where I studied quietly by myself, alone.");
                        break;

                    case 2:
                        Print(4, 4, "In elementary school...");
                        Print(4, 6, "A - I was the class clown.  I even had some friends.");
                        Print(4, 8, "B - I was unruly and often fought with the other children.");
                        Print(4, 10, "C - I was at the head of the class, and I worked very hard.");
                        break;

                    case 3:
                        Print(4, 4, "When I turned 10...");
                        Print(4, 6, "A - my parents divorced.  Acrimoniously.  I once tripped over the paperwork!");
                        Print(4, 8, "B - my parents divorced.  Violently.");
                        Print(4, 10, "C - my parents divorced.  My studies suffered but I continued working.");
                        break;

                    case 4:
                        Print(4, 4, "When I hit junior high school...");
                        Print(4, 6, "A - I broke into lockers and was into punk rock.");
                        Print(4, 8, "B - I was into knives and broke things with bats.  My anger was unmanaged.");
                        Print(4, 10, "C - I got into chess and go.  I was a total outcast.");
                        break;

                    case 5:
                        Print(4, 4, "Things were getting really bad...");
                        Print(4, 6, "A - when I stole my first car.  I got a few blocks before I totalled it.");
                        Print(4, 8, "B - and I went to live with my dad.  He had been in Nam and he still drank.");
                        Print(4, 10, "C - and I went completely goth.  I had no friends and made costumes by myself.");
                        break;

                    case 6:
                        Print(4, 4, "Well, you know it has reached a crescendo when...");
                        Print(4, 6, "A - you steal a cop car and you're only 14.  I went to juvie for 6 months.");
                        Print(4, 8, "B - your mom shoots her ex-husband, your dad, with a shotgun.  She got off.");
                        Print(4, 10, "C - you try sports for a quarter, desperate to fit in.");
                        break;

                    case 7:
                        Print(4, 4, "I was only 15 when I ran away, and...");
                        Print(4, 6, "A - I started robbing houses:  rich people only.  I was fed up with their crap.");
                        Print(4, 8, "B - Hung out with thugs and beat the shit out of people.");
                        Print(4, 10, "C - volunteered for a left-wing candidate.  It wasn't *real*, though, you know?");
                        break;

                    case 8:
                        Print(4, 4, "Life went on.  For my 18th birthday...");
                        Print(4, 6, "A - I stole a security uniform.");
                        Print(4, 8, "B - I bought myself an assault rifle.");
                        Print(4, 10, "C - I celebrated.  I'd saved a thousand bucks!");
                        break;

                    case 9:
                        Print(4, 4, "For the past few years, I've been...");
                        Print(4, 6, "A - stealing from Corporations, but I want to do more.");
                        Print(4, 8, "B - a violent criminal.  Nothing can change that.");
                        Print(4, 10, "C - volunteering for prominent liberals, but I know there's a better way.");
                        Print(4, 14, "I live in " + maincity.Cityname + ", and it's about to experience real change.");
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
                            newcharacter.MaxHealth += 1;
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
                            newcharacter.MaxHealth += 1;
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
                            newcharacter.MaxHealth += 1;
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
                            newcharacter.Armour = new Armour("Security Uniform", ArmourTypes.SECURITYUNIFORM, 0, 40);
                        }
                        if (keyinput == 'b')
                        {
                            newcharacter.Weapon = new Weapon("AK47", SkillTypes.ASSAULTRIFLE, ClipTypes.ASSAULT, new Clip("Aslt.Rifle Clip", ClipTypes.ASSAULT, 9), true);
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
                            newcharacter.MaxHealth += 1;
                            newcharacter.Disguise += 2;
                            newcharacter.Security += 2;
                            newcharacter.Driving += 1;
                        }
                        if (keyinput == 'b')
                        {
                            newcharacter.Agility += 2;
                            newcharacter.Strength += 1;
                            newcharacter.MaxHealth += 2;
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
                            newcharacter.MaxHealth += 1;
                            newcharacter.Law += 2;
                            newcharacter.Writing += 2;
                            newcharacter.Persuasion += 1;
                        }
                        break;
                }
            }

            newcharacter.Health = newcharacter.MaxHealth;

            Console.Clear();
            Border();

            Print(4, 2, "What is your name to the People?");
            Console.SetCursorPosition(4, 3);

            string nameinput = Console.ReadLine();

            if (nameinput == "")
            {
                newcharacter.Handle = newcharacter.Fullname;
            }
            else
            {
                newcharacter.Handle = nameinput;
            }

            newcharacter.AssignedSquad = newsquad;
            newcharacter.Activity = new Activity("Hanging Out", ActivityTypes.NONE);

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

            newlocation = new Location("Abandoned " + RandomLastName() + " ", null, "warehouse", false, null);
            newlocation.RandomName(new List<string> { "Meat Plant", "Warehouse", "Paper Mill", "Cement Factory", "Fertilizer Plant" });
            maincity.Locations.Add(newlocation);

            newlocation = new Location("Abandoned " + RandomLastName() + " ", null, "warehouse", false, null);
            newlocation.RandomName(new List<string> { "Meat Plant", "Warehouse", "Paper Mill", "Cement Factory", "Fertilizer Plant" });
            maincity.Locations.Add(newlocation);

            newlocation = new Location("Abandoned " + RandomLastName() + " ", null, "warehouse", false, null);
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

            // TESTING
            Entity test = new Entity();
            Entity test2 = new Entity();
            Entity test3 = new Entity();
            Entity test4 = new Entity();
            Entity test5 = new Entity();
            //------------

            for (int i = 0; i < maincity.Locations.Count; i++)
            {
                if (maincity.Locations[i].Type == "shelter")
                {
                    newcharacter.Mybase = maincity.Locations[i];
                    newcharacter.Location = maincity.Locations[i];

                    //TESTING
                    test.Mybase = maincity.Locations[i];
                    test2.Mybase = maincity.Locations[i];
                    test3.Mybase = maincity.Locations[i];
                    test4.Mybase = maincity.Locations[i];
                    test5.Mybase = maincity.Locations[i];
                    test.Location = maincity.Locations[i];
                    test2.Location = maincity.Locations[i];
                    test3.Location = maincity.Locations[i];
                    test4.Location = maincity.Locations[i];
                    test5.Location = maincity.Locations[i];
                    //----------

                    newsquad.Location = maincity.Locations[i];
                    break;
                }
            }

            if (newcharacter.Armour == null)
            {
                newcharacter.Armour = new Armour("Clothes", ArmourTypes.CLOTHES, 0, 10);
            }

            liberals.Active.Add(newcharacter);

            //TESTING
            liberals.Active.Add(test);
            liberals.Active.Add(test2);
            liberals.Active.Add(test3);
            liberals.Active.Add(test4);
            liberals.Active.Add(test5);

            test.AssignedTo = newcharacter;
            test2.AssignedTo = newcharacter;
            test3.AssignedTo = test2;
            test4.AssignedTo = test3;
            test5.AssignedTo = test3;

            test.Activity = new Activity("Hanging Out", ActivityTypes.NONE);
            test2.Activity = new Activity("Hanging Out", ActivityTypes.NONE);
            test3.Activity = new Activity("Hanging Out", ActivityTypes.NONE);
            test4.Activity = new Activity("Hanging Out", ActivityTypes.NONE);
            test5.Activity = new Activity("Hanging Out", ActivityTypes.NONE);
            //-----------

            liberals.Squads.Add(newsquad);
            liberals.Activesquad = newsquad;

            liberals.Activesquad.Location.Stash.Add(new Armour("Security Uniform", ArmourTypes.SECURITYUNIFORM, 0, 40));
            liberals.Activesquad.Location.Stash.Add(new Weapon("Carbine", SkillTypes.ASSAULTRIFLE, ClipTypes.ASSAULT, new Clip("Aslt.Rifle Clip", ClipTypes.ASSAULT, 9), true));
            liberals.Activesquad.Location.Stash.Add(new Clip("Aslt.Rifle Clip", ClipTypes.ASSAULT, 5));

            liberals.Vehicles.Add(new Vehicle(VehicleTypes.AGENTCAR, maincity.Locations[11], theDate));
            liberals.Vehicles.Add(new Vehicle(VehicleTypes.POLICECAR, maincity.Locations[11], theDate));
            liberals.Vehicles.Add(new Vehicle(VehicleTypes.BUG, maincity.Locations[11], theDate));
            liberals.Vehicles.Add(new Vehicle(VehicleTypes.JEEP, maincity.Locations[11], theDate));
            liberals.Vehicles.Add(new Vehicle(VehicleTypes.PICKUP, maincity.Locations[11], theDate));
            liberals.Vehicles.Add(new Vehicle(VehicleTypes.POLICECAR, maincity.Locations[11], theDate));
            liberals.Vehicles.Add(new Vehicle(VehicleTypes.SPORTSCAR, maincity.Locations[11], theDate));
            liberals.Vehicles.Add(new Vehicle(VehicleTypes.STATIONWAGON, maincity.Locations[11], theDate));
            liberals.Vehicles.Add(new Vehicle(VehicleTypes.SUV, maincity.Locations[11], theDate));
            liberals.Vehicles.Add(new Vehicle(VehicleTypes.POLICECAR, maincity.Locations[11], theDate));
            liberals.Vehicles.Add(new Vehicle(VehicleTypes.TAXICAB, maincity.Locations[11], theDate));
            liberals.Vehicles.Add(new Vehicle(VehicleTypes.VAN, maincity.Locations[11], theDate));
            liberals.Vehicles.Add(new Vehicle(VehicleTypes.VAN, maincity.Locations[11], theDate));

            Mainscreen();
        }

        static void Mainscreen()
        {

            while (true)
            {
                Console.Clear();
                Border();

                Print(5, 2, liberals.Activesquad.Location.Name + ", " + theDate.PrintDate());
                Print((Console.BufferWidth / 2) - (liberals.Activesquad.GetActivityInfo().Length / 2), 2, liberals.Activesquad.GetActivityInfo(), ConsoleColor.White);
                Print(Console.BufferWidth - 13, 2, "$" + liberals.Funds, ConsoleColor.Green);

                Print(3, 4, "#----------------------------------------------------------------------------------------------------------------#");
                Print(5, 4, str_codename);
                Print(26, 4, str_skill);
                Print(43, 4, str_weapon);
                Print(61, 4, str_armour);
                Print(79, 4, str_health);
                Print(97, 4, str_transport);
                Print(3, 5, "1");
                Print(3, 6, "2");
                Print(3, 7, "3");
                Print(3, 8, "4");
                Print(3, 9, "5");
                Print(3, 10, "6");

                for (int member = 0; member < liberals.Activesquad.Entities.Count; member++)
                {
                    Entity selectedmember = liberals.Activesquad.Entities[member];

                    Print(5, 5 + member, selectedmember.Handle);
                    Print(26, 5 + member, selectedmember.GetTotalSkillLevel() + "/" + selectedmember.GetWeaponSkill());
                    Print(43, 5 + member, selectedmember.GetWeaponName());
                    Print(61, 5 + member, selectedmember.GetArmourName());
                    GetHealthLabel(79, 5 + member, selectedmember);
                    Print(97, 5 + member, selectedmember.AssignedSquad.GetVehicle(selectedmember));
                }

                Print(3, 11, "#----------------------------------------------------------------------------------------------------------------#");

                Print(5, 14, "F - Go forth to stop EVIL", ConsoleColor.DarkGray);
                Print(5, 15, "E - Equipment");

                if (liberals.Vehicles.Count > 0)
                {
                    Print(5, 16, "V - Vehicles");
                }
                else
                {
                    Print(5, 16, "V - Vehicles", ConsoleColor.DarkGray);
                }

                Print(5, 17, "R - Review and reorganize liberals");
                Print(5, 18, "A - Activate the uninvolved");
                Print(5, 19, "C - Cancel this squads departure", ConsoleColor.DarkGray);
                Print(5, 20, "X - Live to fight EVIL another day");
                Print(5, 21, "W - Wait a day");
                Print(76, 14, "# - Check the status of a squad liberal");
                Print(76, 15, "O - Change the squad's liberal order", ConsoleColor.DarkGray);

                if (liberals.Squads.Count > 1)
                {
                    Print(76, 16, "Tab - Next squad");
                }
                else
                {
                    Print(76, 16, "Tab - Next squad", ConsoleColor.DarkGray);
                }

                Print(76, 17, "Z - Next location");
                Print(76, 18, "L - The status of the liberal agenda");

                if (liberals.Activesquad.Location.HasFlag)
                {
                    Print(76, 19, "P - PROTEST: burn the flag");
                }
                else
                {
                    Print(76, 19, "P - PATRIOTISM: Fly a flag here ($20)");
                }

                Print(76, 20, "S - FREE SPEECH: The liberal slogan");

                Print((Console.BufferWidth / 2) - (liberals.Slogan.Length / 2), 24, liberals.Slogan, ConsoleColor.White);

                if (liberals.Activesquad.Location.HasFlag)
                {
                    for (int y = 0; y < 7; y++)
                    {
                        for (int x = 0; x < 21; x++)
                        {
                            if (x < 6 && y < 3)
                            {
                                Print(50 + x, 14 + y, ":", ConsoleColor.White, ConsoleColor.DarkBlue);
                            }
                            else
                            {
                                if (y % 2 == 0)
                                {
                                    Print(50 + x, 14 + y, "\u2588", ConsoleColor.DarkRed);
                                }
                                else
                                {
                                    Print(50 + x, 14 + y, "\u2588", ConsoleColor.White);
                                }
                            }
                        }
                    }
                }

                char keyinput = Console.ReadKey(true).KeyChar;

                if (keyinput == 'f')
                {
                }

                if (keyinput == 'e')
                {
                    Equipment();
                }

                if (keyinput == 'v')
                {
                    Vehicles();
                }

                if (keyinput == 'r')
                {
                    Review();
                }

                if (keyinput == 'a')
                {
                    AssignActivity();
                }

                if (keyinput == 'c')
                {
                }

                if (keyinput == 'x')
                {
                    break;
                }

                if (keyinput == 'w')
                {
                    theDate.Advancetime();
                }

                if (keyinput >= '1' && keyinput <= '6')
                {
                    try
                    {
                        Fullstatus(liberals.Activesquad.Entities[(int)Char.GetNumericValue(keyinput) - 1]);
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                    }
                }

                if (keyinput == 'o')
                {
                }

                if (keyinput == 9)
                {
                    if (liberals.Squads.Count > 1)
                    {
                        try
                        {
                            liberals.Activesquad = liberals.Squads[liberals.Squads.IndexOf(liberals.Activesquad) + 1];
                        }
                        catch (ArgumentOutOfRangeException)
                        {
                            liberals.Activesquad = liberals.Squads[0];
                        }
                    }
                }

                if (keyinput == 'z')
                {
                }

                if (keyinput == 'l')
                {
                }

                if (keyinput == 'p')
                {
                    if (liberals.Activesquad.Location.HasFlag)
                    {
                        int x = 70;
                        int y = 20;

                        while (x + 12 > 50)
                        {
                            if (x > 49)
                            {
                                Print(x, y, "\u2591", ConsoleColor.DarkYellow);
                            }
                            if (x + 2 > 49 && x + 2 < 71)
                            {
                                Print(x + 2, y - 1, "\u2591", ConsoleColor.DarkYellow);
                            }
                            if (x + 4 > 49 && x + 4 < 71)
                            {
                                Print(x + 4, y - 2, "\u2591", ConsoleColor.DarkYellow);
                            }
                            if (x + 6 > 49 && x + 6 < 71)
                            {
                                Print(x + 6, y - 3, "\u2591", ConsoleColor.DarkYellow);
                            }
                            if (x + 8 > 49 && x + 8 < 71)
                            {
                                Print(x + 8, y - 4, "\u2591", ConsoleColor.DarkYellow);
                            }
                            if (x + 10 > 49 && x + 10 < 71)
                            {
                                Print(x + 10, y - 5, "\u2591", ConsoleColor.DarkYellow);
                            }
                            if (x + 12 > 49 && x + 12 < 71)
                            {
                                Print(x + 12, y - 6, "\u2591", ConsoleColor.DarkYellow);
                            }

                            Thread.Sleep(10);
                            x--;
                        }
                        liberals.Activesquad.Location.HasFlag = false;
                    }
                    else
                    {
                        if (liberals.Funds >= 20)
                        {
                            liberals.Funds -= 20;
                            liberals.Activesquad.Location.HasFlag = true;
                        }
                    }
                }

                if (keyinput == 's')
                {
                    Print(5, 25, "What is your new slogan?");
                    Console.SetCursorPosition(5, 26);
                    string newslogan = Console.ReadLine();
                    if (newslogan.Length <= 50)
                    {
                        liberals.Slogan = newslogan;
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            Console.SetWindowSize(120, 30);
            Console.SetBufferSize(120, 30);
            Console.CursorVisible = false;

            Titlescreen();
            //Save();
        }
    }
}
