using System;
using System.Collections.Generic;

// Define a new namespace for event logic
namespace EventNamespace
{
    // Define the delegate for the event
    public delegate void Notify(string message);

    // Define the Subject (Publisher)
    public class Subject
    {
        // Declare the event using the delegate
        public event Notify OnNotify;

        public void NotifyObservers(string message)
        {
            // Trigger the event
            OnNotify?.Invoke(message);
        }
    }

    // Define the Observer
    public class Observer
    {
        private string _name;

        public Observer(string name)
        {
            _name = name;
        }

        // Method to handle the event 
        public void Update(string message)
        {
            Console.WriteLine($"{_name} received message: {message}");
        }

    }

}

// Define the main namespace
namespace MyNamespace
{
    using EventNamespace; // Import the namespace containing the event logic

    public class Program
    {
        static void Main(string[] args)
        {
            // Create the Subject (Publisher)
            Subject subject = new Subject();

            // Create Observers (Subscribers)
            Observer observer1 = new Observer("Observer 1");
            Observer observer2 = new Observer("Observer 2");

            // Subscribe observers to the event
            subject.OnNotify += observer1.Update;
            subject.OnNotify += observer2.Update;

            // Notify all observers
            subject.NotifyObservers("Hello, Observers!");

            // Unsubscribe an observer
            subject.OnNotify -= observer1.Update;

            // Notify remaining observers
            subject.NotifyObservers("Observer 1 has unsubscribed.");
        }
    }
}