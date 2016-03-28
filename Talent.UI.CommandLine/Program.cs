using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talent.Domain;
using Talent.Domain.TestData;

namespace Talent.UI.CommandLine
{
    class Program
    {

        #region Main

        static void Main(string[] args)
        {
            Console.WriteLine("Talent Application Command Line Client");

            DomainObjectStore store = new DomainObjectStore();
   
            Console.WriteLine("\r\nMPAA Ratings:");
            foreach (var m in store.MpaaRatings)
            {
                Console.WriteLine(String.Format(
                    "{0}: {1} - {2}\r\n Description: {3}\r\n",
                    m.Id, m.Code, m.Name, m.Description));
            }

            Console.WriteLine("\r\nGenres:");
            foreach (var g in store.Genres)
            {
                Console.WriteLine(String.Format("{0}: {1} - {2}",
                    g.Id, g.Code, g.Name));
            }

            Console.WriteLine("\r\nCreditTypes:");
            foreach (var g in store.CreditTypes)
            {
                Console.WriteLine(String.Format("{0}: {1} - {2}",
                    g.Id, g.Code, g.Name));
            }

            Console.WriteLine("\r\nHair Colors:");
            foreach (var g in store.HairColors)
            {
                Console.WriteLine(String.Format("{0}: {1} - {2}",
                    g.Id, g.Code, g.Name));
            }

            Console.WriteLine("\r\nEye Colors:");
            foreach (var g in store.EyeColors)
            {
                Console.WriteLine(String.Format("{0}: {1} - {2}",
                    g.Id, g.Code, g.Name));
            }

            Console.WriteLine("\r\nShows:");
            foreach (var show in store.Shows)
            {
                Console.WriteLine(String.Format("{0}: {1} - {2}",
                    show.Id, show.Title,
                    show.MpaaRatingId.HasValue ? 
                        DomainObjectStore.FindMpaaRatingById(
                            store.MpaaRatings, 
                            show.MpaaRatingId.Value).Code : ""));
                Console.Write("\tGenres: ");
                foreach (var sg in show.ShowGenres)
                {
                    Console.Write(DomainObjectStore.FindGenreById(
                        store.Genres, sg.GenreId).Name + " ");
                }
                Console.Write("\r\n");
                foreach (var cr in show.Credits)
                {
                    Console.WriteLine("\t"
                        + DomainObjectStore.FindCreditTypeById(
                            store.CreditTypes, cr.CreditTypeId).Name + " "
                        + DomainObjectStore.FindPersonById(
                            store.People, cr.PersonId).FullName + " "
                        + cr.Character);
                }
            }

            Console.WriteLine("\r\nPeople:");
            foreach (var person in store.People)
            {
                Console.WriteLine(String.Format("{0} - {1}",
                    person.FullName, person.Age));
                foreach (var cr in person.Credits)
                {
                    Console.WriteLine("\t"
                        + DomainObjectStore.FindCreditTypeById(
                            store.CreditTypes, cr.CreditTypeId).Name + " "
                        + DomainObjectStore.FindShowById(
                            store.Shows, cr.ShowId).Title + " "
                        + cr.Character);
                }
            }

            Console.ReadLine();
        }

        #endregion

    }
}
