PasswordValidator pv = new PasswordValidator();

while (true)
{
    Console.WriteLine("Enter a password to validate");
    string pass = Console.ReadLine();

    pv.Validate(pass);
}

class PasswordValidator
{
    private int min = 6;
    private int max = 13;
    public PasswordValidator()
    {

    }

    public void Validate(string pass)
    {
        if (pass.Length >= min && pass.Length <= max && CheckForCapitals(pass) && CheckForLowerCase(pass)
            && CheckForNumbers(pass) && CheckForT(pass) && CheckForAmpersand(pass))
        {
            Console.WriteLine("Valid password");
        }
        else
        {
            Console.WriteLine("Invalid password");
        }
    }

    private bool CheckForCapitals(string pass)
    {
        foreach (char c in pass)
        {
            if (char.IsUpper(c))
            {
                return true;
            }
        }
        return false;
    }

    private bool CheckForLowerCase(string pass)
    {
        foreach (char c in pass)
        {
            if (char.IsLower(c))
            {
                return true;
            }
        }
        return false;
    }

    private bool CheckForNumbers(string pass)
    {
        foreach (char c in pass)
        {
            if (char.IsNumber(c)) ;
            {
                return true;
            }
        }
        return false;
    }

    private bool CheckForT(string pass)
    {
        foreach (char c in pass)
        {
            if (c == 't' || c == 'T')
            {
                return false;
            }
        }
        return true;
    }

    private bool CheckForAmpersand(string pass)
    {
        foreach (char c in pass)
        {
            if (c == '&')
            {
                return false;
            }
        }
        return true;
    }
}