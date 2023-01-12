using System;
using System.Management.Instrumentation;

[assembly: Instrumented("root\\my_net_sample")]

// A simple tree of instances derived from Instance
// TopInstance--Branch1Instance--Leaf1AInstance
//           \                 \-Leaf1BInstance
//            \
//             Branch2Instance--Leaf2AInstance
// Only the leafs of the tree can be concrete instances.
// All other nodes on the tree must be abstract.

// This is a top-level abstract class.  It must have the
// 'InstrumentationType.Abstract' attribute or it would
// inherit the 'Instance' attribute 
// from the base class 'Instance'
[InstrumentationClass(InstrumentationType.Abstract)]
public class TopInstance : Instance
{
    private string myProperty;

    [ManagedName("MyOtherName")]
    public string MyProperty
    {
        get { return myProperty; }
        set { myProperty = value; }
    }

    public TopInstance()
    {
        myProperty = Guid.NewGuid().ToString();
    }
}

// This class inherits the 
// 'InstrumentationType.Abstract' attribute
public class Branch1Instance : TopInstance
{
}

// This is a leaf class which can be concrete
[InstrumentationClass(InstrumentationType.Instance)]
public class Leaf1AInstance : Branch1Instance
{
}

// This is a leaf class which can be concrete
[InstrumentationClass(InstrumentationType.Instance)]
public class Leaf1BInstance : Branch1Instance
{
}

// This class inherits the 
// 'InstrumentationType.Abstract' attribute
public class Branch2Instance : TopInstance
{
}

// This is a leaf class which can be concrete
[InstrumentationClass(InstrumentationType.Instance)]
public class Leaf2AInstance : Branch2Instance
{
}

class App
{
    static void Main(string[] args)
    {
        // Publish an instance of each leaf
        Leaf1AInstance leaf1a = new Leaf1AInstance();
        Leaf1BInstance leaf1b = new Leaf1BInstance();
        Leaf2AInstance leaf2a = new Leaf2AInstance();

        //leaf1a.Published = true;
        Instrumentation.Publish(leaf1a);
        leaf1b.Published = true;
        leaf2a.Published = true;

        // Instances now visible through WMI
        Console.WriteLine("Instances now visible through WMI");
        Console.ReadLine();

        // Revoke all instances
        leaf1a.Published = false;
        //leaf1b.Published = false;
        //leaf2a.Published = false;
    }
}

