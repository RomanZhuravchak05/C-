using System;

class RegularUser : User
{
    public RegularUser(string userName, string email) : base(userName, email)
    {
    }

    public void PostComment()
    {
        Console.WriteLine("Коментар опубліковано.");
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine("Роль: Звичайний користувач");
    }
}