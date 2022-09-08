public class Foo {
    private int num = 1;
    public Foo() {}

    public void First(Action printFirst) 
    {
        while(num != 1){}
        printFirst.Invoke();
        num++;
    }

    public void Second(Action printSecond) 
    {
        while(num != 2){}
        printSecond();
        num++;
    }

    public void Third(Action printThird) 
    {
        while(num != 3){}
        printThird();
        num++;
    }
}