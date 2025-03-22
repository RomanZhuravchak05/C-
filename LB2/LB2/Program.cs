using System;
using System.Collections.Generic;
using System.Text;

class Program
{
    static void Main()
    {
        List<User> users = new List<User>();
        users.Add(new Admin("AdminUser", "admin@example.com"));
        users.Add(new Moderator("ModUser", "mod@example.com"));
        users.Add(new RegularUser("RegUser", "user@example.com"));

        users[0].SetPassword("admin123");
        users[1].SetPassword("mod123");
        users[2].SetPassword("user123");

        Console.WriteLine("=== Інформація про користувачів ===");
        for (int i = 0; i < users.Count; i++)
        {
            users[i].DisplayInfo();
            Console.WriteLine();
        }

        Console.WriteLine("=== Тестування методів ===");
        for (int i = 0; i < users.Count; i++)
        {
            if (users[i] is Admin)
            {
                ((Admin)users[i]).BlockUser(users[2]);
            }
            else if (users[i] is Moderator)
            {
                ((Moderator)users[i]).ModerateContent();
            }
            else if (users[i] is RegularUser)
            {
                ((RegularUser)users[i]).PostComment();
            }
        }

        Console.WriteLine("\n=== Перевірка аутентифікації ===");

        if (users[0].Authenticate("admin123"))
            Console.WriteLine("AdminUser: Успішна аутентифікація");
        else
            Console.WriteLine("AdminUser: Невірний пароль");

        if (users[1].Authenticate("wrongpass"))
            Console.WriteLine("ModUser: Успішна аутентифікація");
        else
            Console.WriteLine("ModUser: Невірний пароль");

        if (users[2].Authenticate("user123"))
            Console.WriteLine("RegUser: Успішна аутентифікація");
        else
            Console.WriteLine("RegUser: Невірний пароль");
    }
}
