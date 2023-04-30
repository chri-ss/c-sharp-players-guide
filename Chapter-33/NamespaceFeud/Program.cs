using iField;
using McDroid;
using swine = iField.Pig;
using hog = McDroid.Pig;

Sheep sheep = new Sheep();
Cow cow = new Cow();
swine pig1 = new swine();
hog pig2 = new hog();

namespace iField
{
    public class Sheep
    {
        public Sheep()
        {
            Console.WriteLine("baa");
        }
    }

    public class Pig
    {
        public Pig()
        {
            Console.WriteLine("I'm an iField Pig");
        }
    }
}

namespace McDroid
{
    public class Cow
    {
        public Cow()
        {
            Console.WriteLine("moo");
        }
    }

    public class Pig
    {
        public Pig()
        {
            Console.WriteLine("I'm a McDroid pig");
        }
    }
}