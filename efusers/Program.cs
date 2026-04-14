using efusers.Data;
using efusers.Models;
using System;

namespace efusers {
    public class Program
    {
        public static void Main()
        {
            using var context = new ApplicationDbContext();

            // Crear i guardar una nova adreça abans d'assignar-la a un usuari
            var direction = new Address { Street = "Carrer Major", City = "Barcelona", PostalCode = "08001" };
            context.Direction.Add(direction);
            context.SaveChanges(); // Aquí es guarda l'adreça i se li assigna un Id

            // Ara afegim un usuari i li assignem l'Id de l'adreça guardada
            var user = new User { Name = "Joan", Surname = "Fuster" };
            context.Users.Add(user);
            context.SaveChanges(); // Aquí es guarda l'usuari amb la seva adreça assignada

            // Modificar un usuari
            var userToUpdate = context.Users.Find(user.Id);
            if (userToUpdate != null)
            {
                userToUpdate.Name = "Joan Antoni";
                context.SaveChanges();
            }

            // Eliminar un usuari
            var userToDelete = context.Users.Find(user.Id);
            if (userToDelete != null)
            {
                context.Users.Remove(userToDelete);
                context.SaveChanges();
            }

            // Obtenir un usuari per Id
            var userId = 1; // Exemple d'Id
            var userById = context.Users.Find(userId);
            if (userById != null)
            {
                Console.WriteLine($"Usuari trobat: ID:{userById.Id}, Nom: {userById.Name}, Cognoms: {userById.Surname}");
            }
            else
            {
                Console.WriteLine($"No s'ha trobat cap usuari amb l'ID {userId}");
            }

            // Mostrar la llista d'usuaris
            var usuaris = context.Users.ToList();
            foreach (var usuari in usuaris)
            {
                Console.WriteLine($"ID:{usuari.Id}, Nom: {usuari.Name}, Cognoms: {usuari.Surname}");
            }
            Console.WriteLine("***** Versió amb ForEach *********");
            // Mostrar la llista d'usuaris
            context.Users.ToList().ForEach(usuari =>
                Console.WriteLine($"ID:{usuari.Id}, Nom: {usuari.Name}, Cognoms: {usuari.Surname}")
            );
        }
    }
}