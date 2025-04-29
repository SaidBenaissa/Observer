
# Observer Design Pattern

The Observer Design Pattern allows an object (the Subject) to notify multiple observers about changes in its state.

```mermaid
classDiagram
    direction LR

    class Subject {
        +event Notify OnNotify
        +void NotifyObservers(string message)
    }

    class Observer {
        +void Update(string message)
    }

    class Notify {
        <<delegate>>
        +void Invoke(string message)
    }

    Subject --> "triggers" Notify
    Observer <-- "subscribes to" Subject
    Notify --> "defines signature for" Observer.Update
```
