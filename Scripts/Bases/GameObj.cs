public abstract class GameObj
{
    public virtual void Draw() { }
    public virtual void Update() { }
    public virtual void LateUpdate() { }
    
    public static void print(object o)
    {
        System.Console.WriteLine(o.ToString());
    }
    public static void print(string o)
    {
        System.Console.WriteLine(o);
    }
    public static void print(int i)
    {
        System.Console.WriteLine(i);
    }
}