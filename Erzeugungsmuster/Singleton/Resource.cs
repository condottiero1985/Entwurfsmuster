namespace Erzeugungsmuster.Singleton;

public class Resource
{
    private static Resource _instance;

    private Resource() { }

    public static Resource GetInstance()
    {
        if (_instance == null)
            _instance = new Resource();

        return _instance;
    }

    public void AccessToCritcalResource()
    {
        Console.WriteLine("Access to critical resource");
    }
}