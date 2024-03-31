public class Person
{
    private string _name;
    private int _age;

    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }
    public int Age
    {
        get { return _age; }
        set { _age = value; }
    }

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Name: {_name}, Age: {_age}");
    }

    static void Main(string[] args)
    {
        Person person = new Person("John Doe", 25);
        person.Age = 26;
        person.DisplayInfo();
        Console.ReadLine();
    }
}
