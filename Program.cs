using Microsoft.VisualBasic.FileIO;
using System;
using System.Runtime.CompilerServices;
using System.Xml.Linq;
using static System.Reflection.Metadata.BlobBuilder;
using static Task3.CinemaTicketSystem;
namespace Task3
{
    public class CinemaTicketSystem()
    {
        public List<String> movies = new List<String>();
        public List<String> users = new List<String>();
        string user_name;
        string movie_name;
        
        public class Ticket(int user_id, int movie_id)
        {
            
            public int t_user = user_id;
            public int t_movie = movie_id;

        }
        public List<Ticket> tickets = new List<Ticket>();

        public static void Main(string[] args)
        {
            CinemaTicketSystem cts = new CinemaTicketSystem();
        
            bool showMenu = true;
            while (showMenu)
            {
                showMenu = Menu();
            }

            bool Menu()
            {
                Console.Clear();
                Console.WriteLine("Здравствуйте, у вас есть следующие доступные функции:");
                Console.WriteLine("1. Добавить новый фильм; ");
                Console.WriteLine("2. Показать все доступные фильмы;");
                Console.WriteLine("3. Добавить нового пользователя;");
                Console.WriteLine("4. Купить билет;");
                Console.WriteLine("5. Отменить покупку билета;");

                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("Введите название фильма");
                        addMovie(Console.ReadLine());
                        return true;
                    case "2":
                        //Console.Clear();
                        showAllMovies();
                        return true;
                    case "3":
                        Console.Clear();
                        Console.WriteLine("Введите имя:");
                        addUser(Console.ReadLine());
                        return true;
                    case "4":
                        Console.Clear();
                        Console.WriteLine("Введите ID пользователя:");
                        string user_id = Console.ReadLine();
                        int user = Convert.ToInt32(user_id);
                        Console.WriteLine("Введите ID фильма:");                        
                        string movie_id = Console.ReadLine();
                        int movie = Convert.ToInt32(movie_id);
                        buyTicket(user, movie);
                        return true;
                    case "5":
                        Console.Clear();
                        Console.WriteLine("Введите имя:");
                        string user_name = Console.ReadLine();
                        user = Convert.ToInt32(user_name);
                        Console.WriteLine("Введите название фильма:");
                        string movie_name = Console.ReadLine();
                        movie = Convert.ToInt32(movie_name);
                        buyTicket(user, movie);
                        return true;
                }
                return true;
            }
            void showAllMovies()
            {
                foreach (var movie in cts.movies)
                {
                    Console.WriteLine(movie);
                }
            }
            void buyTicket(int userId, int movieId)
            {
                Ticket t = new Ticket(userId, movieId);
                cts.tickets.Add(t);
                
            }
            void cancelTicket(int ticketId)
            {
                cts.tickets.RemoveAt(ticketId);
            }

            void addUser(string userName)
            {
                cts.users.Add(userName);
            }

            void addMovie(string movieName)
            {
                cts.movies.Add(movieName);
            }
        }
    }
}