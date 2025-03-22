using System;

class Moderator : User
{
    public Moderator(string userName, string email) : base(userName, email)
    {
    }

    public void ModerateContent()
    {
        Console.WriteLine("Контент модеровано.");
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine("Роль: Модератор");
    }
}