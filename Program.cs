using System;
using System.Collections.Generic;
using System.Linq;
using JsonData;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Collections to work with
            List<Artist> Artists = MusicStore.GetData().AllArtists;
            List<Group> Groups = MusicStore.GetData().AllGroups;

            //========================================================
            //Solve all of the prompts below using various LINQ queries
            //========================================================

            //There is only one artist in this collection from Mount Vernon, what is their name and age?
            Artist theOne = Artists.FirstOrDefault(art=>art.Hometown == "Mount Vernon");
            System.Console.WriteLine(theOne.ArtistName + " "+ theOne.Age);

            //Who is the youngest artist in our collection of artists?
            Artist youngest = Artists.OrderByDescending(a => a.Age).Last();
            Console.WriteLine(youngest.ArtistName + " " + youngest.Age);

            //Display all artists with 'William' somewhere in their real name
            IEnumerable<Artist> certainArtists = Artists.Where(art=>art.RealName.Contains("William"));
            foreach(var a in certainArtists){
                System.Console.WriteLine(a.RealName +" "+ a.ArtistName); 
            }

            //Display all groups with names less than 8 characters in length
            IEnumerable<Group> shortName = Groups.Where(g => g.GroupName.Length<8);
            foreach(var g in shortName){
                System.Console.WriteLine(g.GroupName);
            }

            //Display the 3 oldest artist from Atlanta
            IEnumerable<Artist> oldestArtists = Artists.Where(art=>art.Hometown == "Atlanta").OrderByDescending(art=>art.Age).Take(3);
            foreach(var a in oldestArtists){
                System.Console.WriteLine(a.ArtistName +" "+ a.Age);
            }

            //(Optional) Display the Group Name of all groups that have members that are not from New York City
            var Id = Artists.Where(a=>a.Hometown != "New York City").Select(a => a.GroupId);
         
            //(Optional) Display the artist names of all members of the group 'Wu-Tang Clan'

            var memberArtists = Groups.Where(g => g.GroupName == "Wu-Tang Clan").Select(g => g.Members.Select(m => m.ArtistName));
            foreach (var a in memberArtists)
            {
                Console.WriteLine(a);
            }	        
        }
    }
}
