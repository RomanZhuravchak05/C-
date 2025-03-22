using System;

class User
{
    public string UserName;
    public string Email;
    private string _password;

    public User(string userName, string email)
    {
        UserName = userName;
        Email = email;
    }

    public void SetPassword(string newPassword)
    {
        _password = newPassword;
    }

    public bool Authenticate(string inputPassword)
    {
        if (_password == inputPassword)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public virtual void DisplayInfo()
    {
        Console.WriteLine("Ім'я: " + UserName + " | Email: " + Email);
    }
}