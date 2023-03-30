PasswordValidator pv = new PasswordValidator();

pv.Validate("nope");
pv.Validate("amsterdam");
pv.Validate("aaaaaaaaaaaaaaaaaaaaaaaaaaa");

class PasswordValidator
{
    private int min = 6;
    private int max = 13;
    public PasswordValidator()
    {

    }

    public void Validate(string pass)
    {
        if (pass.Length >= min && pass.Length <= max)
        {
            Console.WriteLine("Valid password");
        }
        else
        {
            Console.WriteLine("Invalid password");
        }
    }
}