using System;
using System.Management.Instrumentation;
using System.Windows.Forms;

[assembly: Instrumented("root\\my_net_sample_2")]

// A simple tree of instances declared with attributes
// TopInstance2--Branch1Instance2--Leaf1AInstance2
//           \                   \-Leaf1BInstance2
//            \
//             Branch2Instance2--Leaf2AInstance2
// Only the leafs of the tree can be concrete instances.
// All other nodes on the tree must be abstract.

// This is a top level abstract class.
[InstrumentationClass(InstrumentationType.Abstract)]
public class TopInstance2
{

    private string myProperty;
    [ManagedName("MyOtherName")]
    public string MyProperty
    {
        get { return myProperty; }
        set { myProperty = value; }
    }

    [ManagedName("MyMethod")]
    public void MyMethod()
    {
        MessageBox.Show("MyMethod executed");
    }

    public TopInstance2()
    {
        myProperty = Guid.NewGuid().ToString();
    }

}

// This class inherits the 
// 'InstrumentationType.Abstract' attribute
public class Branch1Instance2 : TopInstance2
{
}

// This is a leaf class which can be concrete
[InstrumentationClass(InstrumentationType.Instance)]
public class Leaf1AInstance2 : Branch1Instance2
{
}

// This is a leaf class which can be concrete
[InstrumentationClass(InstrumentationType.Instance)]
public class Leaf1BInstance2 : Branch1Instance2
{
}

// This class inherits the 
// 'InstrumentationType.Abstract' attribute
public class Branch2Instance2 : TopInstance2
{
}

// This is a leaf class which can be concrete
[InstrumentationClass(InstrumentationType.Instance)]
public class Leaf2AInstance2 : Branch2Instance2
{
}

class App
{
    static void Main(string[] args)
    {
        // Publish an instance of each leaf
        Leaf1AInstance2 leaf1a = new Leaf1AInstance2();
        Leaf1BInstance2 leaf1b = new Leaf1BInstance2();
        Leaf2AInstance2 leaf2a = new Leaf2AInstance2();

        Instrumentation.Publish(leaf1a);
        Instrumentation.Publish(leaf1b);
        Instrumentation.Publish(leaf2a);

        // Instances now visible through WMI
        Console.WriteLine(
            "Instances now visible through WMI");
        Console.ReadLine();

        // Revoke all instances
        Instrumentation.Revoke(leaf1a);
        Instrumentation.Revoke(leaf1b);
        Instrumentation.Revoke(leaf2a);
    }
}