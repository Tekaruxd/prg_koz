using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ProgrammingLanguagesDatabase.Data;
using ProgrammingLanguagesDatabase.Models;

namespace ProgrammingLanguagesDatabase
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new ProgrammingLanguageContext())
            {
                while (true)
                {
                    Console.WriteLine("\n--- Databáze programovacích jazyků ---");
                    Console.WriteLine("1. Seznam jazyků");
                    Console.WriteLine("2. Autoři jazyka");
                    Console.WriteLine("3. Vyhledat jazyk podle roku");
                    Console.WriteLine("4. Konec");
                    
                    Console.Write("Vyberte akci: ");
                    string choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            ListLanguages(context);
                            break;
                        case "2":
                            ShowLanguageAuthors(context);
                            break;
                        case "3":
                            SearchLanguagesByYear(context);
                            break;
                        case "4":
                            return;
                        default:
                            Console.WriteLine("Neplatná volba. Zkuste znovu.");
                            break;
                    }
                }
            }
        }

        static void ListLanguages(ProgrammingLanguageContext context)
        {
            Console.WriteLine("Dostupné programovací jazyky:");
            var languages = context.Languages
                .OrderBy(l => l.YearCreated)
                .ToList();
            
            foreach (var lang in languages)
            {
                Console.WriteLine($"- {lang.Name} (vytvořen v roce {lang.YearCreated})");
            }
        }

        static void ShowLanguageAuthors(ProgrammingLanguageContext context)
        {
            Console.Write("Zadejte název jazyka: ");
            string languageName = Console.ReadLine();
            var language = context.Languages
            .Include(l => l.CreatedBy)
            .ThenInclude(cb => cb.Author)
            .FirstOrDefault(l => l.Name.ToLower() == languageName.ToLower());

            if (language != null)
            {
                Console.WriteLine($"Autoři jazyka {language.Name}:");
        
                foreach (var createdBy in language.CreatedBy)
                {
                    var author = createdBy.Author;
                    Console.WriteLine($"- {author.FirstName} {author.Surname} " +
                    $"{(string.IsNullOrEmpty(author.Company) ? "" : $"({author.Company})")}");
                }
            }
            else
            {
            Console.WriteLine($"Jazyk {languageName} nebyl nalezen.");
            }
        }

        static void SearchLanguagesByYear(ProgrammingLanguageContext context)
        {
            Console.Write("Zadejte rok vzniku: ");
            if (int.TryParse(Console.ReadLine(), out int year))
            {
                var languages = context.Languages
                    .Where(l => l.YearCreated == year)
                    .ToList();

                if (languages.Any())
                {
                    Console.WriteLine($"Jazyky vytvořené v roce {year}:");
                    foreach (var lang in languages)
                    {
                        Console.WriteLine($"- {lang.Name}");
                    }
                }
                else
                {
                    Console.WriteLine($"Žádné jazyky nebyly v roce {year} vytvořeny.");
                }
            }
            else
            {
                Console.WriteLine("Neplatný formát roku.");
            }
        }
    }
}

