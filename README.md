## Erzeugungsmuster (Creational Design Patterns)

### 1. Abstract Factory

**Zweck:** Bietet eine Schnittstelle zum Erstellen von Familien verwandter oder abhängiger Objekte, ohne deren konkrete Klassen anzugeben.

**Erklärung der Implementierung:**

In diesem Beispiel haben wir eine GUI-Anwendung, die auf verschiedenen Betriebssystemen laufen kann (Windows, Mac). Die `IGUIFactory`-Schnittstelle definiert Methoden zum Erstellen von Buttons und Checkboxes.

- **Abstrakte Produkte:** `IButton` und `ICheckbox` sind Schnittstellen für die Produkte.
- **Konkrete Produkte:** `WinButton`, `WinCheckbox`, `MacButton` und `MacCheckbox` implementieren die jeweiligen Produkt-Schnittstellen.
- **Abstrakte Fabrik:** `IGUIFactory` deklariert die Erzeugungsmethoden.
- **Konkrete Fabriken:** `WinFactory` und `MacFactory` erstellen konkrete Produkte.
- **Client:** Die `Application`-Klasse verwendet die Fabrik, um die Produkte zu erzeugen.

Dieses Muster ermöglicht es, Familien von Objekten zu erstellen, ohne die konkreten Klassen im Code festzulegen.

---

### 2. Builder

**Zweck:** Trennt den Aufbau eines komplexen Objekts von seiner Repräsentation, sodass derselbe Aufbau unterschiedliche Darstellungen erzeugen kann.

**Erklärung der Implementierung:**

- **Produkt:** Die Klasse `House` repräsentiert das zu erstellende Objekt.
- **Builder-Schnittstelle:** `IHouseBuilder` definiert die Methoden zum Erstellen der Teile des Produkts.
- **Konkreter Builder:** `StoneHouseBuilder` implementiert die Erstellungsschritte.
- **Director:** Die Klasse `Engineer` orchestriert die Bauanleitung.
- **Client:** Im `Program` erstellt der Client einen `Engineer` mit einem bestimmten `IHouseBuilder`.

Dieses Muster ist nützlich, wenn ein Objekt aus vielen Teilen besteht und die Erstellungsschritte variieren können.

---

### 3. Factory Method

**Zweck:** Definiert eine Schnittstelle zum Erstellen eines Objekts, überlässt aber den Unterklassen die Entscheidung, welche Klasse instanziiert wird.

**Erklärung der Implementierung:**

- **Produkt-Schnittstelle:** `IProduct` definiert das Interface für Produkte.
- **Konkrete Produkte:** `ConcreteProductA` und `ConcreteProductB` implementieren `IProduct`.
- **Creator-Klasse:** `Creator` enthält die Fabrikmethode `FactoryMethod()`.
- **Konkrete Creators:** `ConcreteCreatorA` und `ConcreteCreatorB` überschreiben die Fabrikmethode, um konkrete Produkte zu erstellen.
- **Client:** Im `Program` wählt der Client den Creator aus und ruft `Operation()` auf.

Dieses Muster ermöglicht es, die Erstellung von Objekten zu kapseln und flexibel zu gestalten.

---

### 4. Prototype

**Zweck:** Ermöglicht das Erstellen neuer Objekte durch Kopieren eines vorhandenen Objekts (Prototyp).

**Erklärung der Implementierung:**

- **Prototyp-Schnittstelle:** `Shape` enthält die Methode `Clone()`.
- **Konkreter Prototyp:** `Circle` implementiert die Clone-Methode.
- **Client:** Im `Program` wird ein `Circle`-Objekt erstellt und dann geklont.

Dieses Muster ist nützlich, wenn die Erstellung eines Objekts teuer ist und ein Klon schneller erstellt werden kann.

---

### 5. Singleton

**Zweck:** Stellt sicher, dass eine Klasse nur eine Instanz hat, und bietet einen globalen Zugriffspunkt darauf.

**Erklärung der Implementierung:**

- **Private Konstruktor:** Verhindert die Erstellung von Instanzen außerhalb der Klasse.
- **Statische Methode:** `Instance` liefert die einzige Instanz zurück.
- **Thread-Sicherheit:** Die doppelte Prüfung mit `lock` stellt sicher, dass nur eine Instanz erstellt wird.
- **Client:** Im `Program` wird die Singleton-Instanz abgerufen und verwendet.

Dieses Muster wird verwendet, wenn genau ein Objekt benötigt wird, z.B. ein Logger oder eine Konfiguration.

---

## Strukturmuster (Structural Design Patterns)

### 1. Adapter

**Zweck:** Wandelt die Schnittstelle einer Klasse in eine andere um, die der Client erwartet.

**Erklärung der Implementierung:**

- **Ziel-Schnittstelle:** `ITarget` wird vom Client erwartet.
- **Adaptee:** `Adaptee` hat eine inkompatible Schnittstelle.
- **Adapter:** `Adapter` implementiert `ITarget` und übersetzt Aufrufe an `Adaptee`.
- **Client:** Verwendet `ITarget` ohne Kenntnis des `Adaptee`.

Dieses Muster ermöglicht die Zusammenarbeit inkompatibler Schnittstellen.

---

### 2. Bridge

**Zweck:** Trennt eine Abstraktion von ihrer Implementierung, sodass beide unabhängig voneinander verändert werden können.

**Erklärung der Implementierung:**

- **Abstraktion:** `RemoteControl` definiert die Steuerung.
- **Verfeinerte Abstraktion:** `AdvancedRemoteControl` erweitert `RemoteControl`.
- **Implementierer-Schnittstelle:** `IDevice` definiert die Gerätefunktionen.
- **Konkrete Implementierer:** `TV` implementiert `IDevice`.
- **Client:** Verwendet die Abstraktion mit verschiedenen Implementierungen.

Dieses Muster fördert die Entkopplung und erhöht die Flexibilität des Codes.

---

### 3. Composite

**Zweck:** Komponiert Objekte zu Baumstrukturen, um Teil-Ganzes-Hierarchien zu repräsentieren.

**Erklärung der Implementierung:**

- **Komponente:** `IGraphic` definiert die Schnittstelle für alle Objekte im Kompositum.
- **Blatt:** `Circle` ist ein konkretes Element ohne Unterelemente.
- **Kompositum:** `CompositeGraphic` kann aus mehreren `IGraphic`-Objekten bestehen.
- **Client:** Kann sowohl Blätter als auch Komposita gleich behandeln.

Dieses Muster erleichtert die Arbeit mit rekursiven Strukturen.

---

### 4. Decorator

**Zweck:** Fügt einem Objekt zur Laufzeit zusätzliche Verantwortlichkeiten hinzu.

**Erklärung der Implementierung:**

- **Komponente:** `IDataSource` definiert die Schnittstelle.
- **Konkrete Komponente:** `FileDataSource` implementiert die Grundfunktionalität.
- **Dekorierer:** `DataSourceDecorator` erweitert `IDataSource` und hält eine Referenz auf ein `IDataSource`-Objekt.
- **Konkreter Dekorierer:** `EncryptionDecorator` fügt Verschlüsselungslogik hinzu.
- **Client:** Kann mehrere Dekorierer schichten, um zusätzliche Funktionen hinzuzufügen.

Dieses Muster ermöglicht flexible Erweiterungen von Objekten ohne Vererbung.

---

### 5. Facade

**Zweck:** Bietet eine vereinfachte Schnittstelle zu einem komplexen Subsystem.

**Erklärung der Implementierung:**

- **Subsysteme:** `SubsystemA`, `SubsystemB`, `SubsystemC` sind komplexe Klassen.
- **Fassade:** `Facade` bietet eine einfache Methode `Operation()`, die die Subsysteme koordiniert.
- **Client:** Verwendet die Fassade, um mit dem Subsystem zu interagieren.

Dieses Muster reduziert die Komplexität und entkoppelt den Client vom Subsystem.

---

### 6. Flyweight

**Zweck:** Verwendet gemeinsame Objekte, um Speicherplatz zu sparen, wenn viele ähnliche Objekte benötigt werden.

**Erklärung der Implementierung:**

- **Flyweight:** `ITreeType` definiert die gemeinsame Schnittstelle.
- **Konkreter Flyweight:** `TreeType` enthält geteilte Zustände.
- **Flyweight Factory:** `TreeFactory` verwaltet die Flyweight-Objekte.
- **Kontext:** `Tree` enthält externe Zustände (Position).
- **Client:** Erstellt viele `Tree`-Objekte, die sich die `TreeType`-Instanzen teilen.

Dieses Muster ist nützlich bei großen Mengen ähnlicher Objekte.

---

### 7. Proxy

**Zweck:** Stellt einen Ersatz für ein anderes Objekt bereit, um dessen Zugriff zu steuern.

**Erklärung der Implementierung:**

- **Subjekt-Schnittstelle:** `ISubject` definiert die gemeinsame Schnittstelle.
- **Reales Subjekt:** `RealSubject` implementiert die tatsächliche Logik.
- **Proxy:** `Proxy` kontrolliert den Zugriff auf `RealSubject`.
- **Client:** Verwendet den Proxy wie das reale Subjekt.

Dieses Muster fügt zusätzliche Kontrolle oder Funktionalität hinzu, ohne das reale Subjekt zu ändern.

---

## Verhaltensmuster (Behavioral Design Patterns)

### 1. Chain of Responsibility

**Zweck:** Vermeidet die Kopplung zwischen Sender und Empfänger, indem mehr als ein Objekt die Möglichkeit hat, die Anfrage zu bearbeiten.

**Erklärung der Implementierung:**

- **Handler:** `Handler` ist die abstrakte Klasse mit einer Referenz auf den nächsten Handler.
- **Konkrete Handler:** `ConcreteHandlerA` und `ConcreteHandlerB` implementieren die spezifische Logik.
- **Client:** Verkettet die Handler und sendet die Anfrage an den ersten Handler.

Dieses Muster ermöglicht es, Anfragen flexibel durch eine Kette von Handlern zu leiten.

---

### 2. Command

**Zweck:** Kapselt einen Auftrag als Objekt, sodass man Parameter, Warteschlangen oder Logs für Aufträge einführen kann.

**Erklärung der Implementierung:**

- **Command-Schnittstelle:** `ICommand` definiert die Methode `Execute()`.
- **Empfänger:** `Receiver` führt die eigentliche Aktion aus.
- **Konkreter Command:** `ConcreteCommand` implementiert `ICommand` und ruft die Aktion des Empfängers auf.
- **Invoker:** `Invoker` hält den Command und führt ihn aus.
- **Client:** Erstellt den Command und konfiguriert den Invoker.

Dieses Muster ermöglicht die Entkopplung zwischen Sender und Empfänger und erleichtert Undo/Redo-Operationen.

---

### 3. Interpreter

**Zweck:** Definiert eine Grammatik für eine Sprache und einen Interpreter, um Sätze dieser Sprache zu interpretieren.

**Erklärung der Implementierung:**

- **Abstrakter Ausdruck:** `IExpression` definiert die `Interpret()`-Methode.
- **Terminal-Ausdruck:** `NumberExpression` repräsentiert Zahlen.
- **Nichtterminaler Ausdruck:** `AddExpression` repräsentiert die Addition von Ausdrücken.
- **Client:** Baut einen Ausdrucksbaum und interpretiert ihn.

Dieses Muster eignet sich für einfache Sprachen oder Ausdrucksberechnungen.

---

### 4. Iterator

**Zweck:** Bietet eine Möglichkeit, die Elemente eines Aggregats sequentiell zu durchlaufen, ohne seine interne Darstellung offenzulegen.

**Erklärung der Implementierung:**

- **Aggregate-Schnittstelle:** `IAggregate` definiert die Methode `CreateIterator()`.
- **Iterator-Schnittstelle:** `IIterator` definiert `HasNext()` und `Next()`.
- **Konkretes Aggregate:** `Collection` implementiert `IAggregate` und enthält die Elemente.
- **Konkreter Iterator:** `Iterator` implementiert `IIterator` und durchläuft die `Collection`.
- **Client:** Verwendet den Iterator, um über die `Collection` zu iterieren.

Dieses Muster ermöglicht eine einheitliche Traversierung von Aggregaten.

---

### 5. Mediator

**Zweck:** Definiert ein Objekt (Mediator), das die Interaktion einer Menge von Objekten kapselt. Der Mediator fördert die lose Kopplung, indem er Objekte davon abhält, sich explizit aufeinander zu beziehen.

**Erklärung der Implementierung:**

- **Mediator-Schnittstelle:** `IMediator` definiert die Methode `Notify`, um Nachrichten zwischen Komponenten zu vermitteln.
- **Konkreter Mediator:** `ConcreteMediator` implementiert die Vermittlungslogik zwischen `Component1` und `Component2`.
- **Komponenten:** `Component1` und `Component2` sind die Kollegen, die miteinander interagieren, ohne direkt voneinander abhängig zu sein.
- **Basis-Komponente:** `BaseComponent` ermöglicht das Setzen des Mediators.
- **Client:** Im `Program` erstellt der Client die Komponenten und den Mediator, und löst Aktionen aus.

Dieses Muster ermöglicht eine zentrale Steuerung der Kommunikation zwischen Objekten und reduziert die Abhängigkeiten zwischen ihnen.

---

### 6. Memento

**Zweck:** Ermöglicht es, den internen Zustand eines Objekts zu erfassen und außerhalb zu speichern, sodass es später wiederhergestellt werden kann, ohne die Kapselung zu verletzen.

**Erklärung der Implementierung:**

- **Memento:** `Memento` speichert den Zustand des `Originator`.
- **Originator (Ursprung):** `Originator` erstellt ein Memento seines aktuellen Zustands und kann diesen später wiederherstellen.
- **Caretaker (Verwalter):** `Caretaker` verwaltet die Mementos und kann den Zustand des `Originator` zurücksetzen.
- **Client:** Im `Program` ändert der Client den Zustand des `Originator` und verwendet den `Caretaker`, um Zustände zu speichern und wiederherzustellen.

Dieses Muster ist nützlich für Undo-Funktionen und Zustandsspeicherung.

---

### 7. Observer

**Zweck:** Definiert eine Eins-zu-Viele-Abhängigkeit zwischen Objekten, sodass bei einer Zustandsänderung eines Objekts alle abhängigen Objekte benachrichtigt und automatisch aktualisiert werden.

**Erklärung der Implementierung:**

- **Subjekt:** `Subject` hält den Zustand und eine Liste von Beobachtern.
- **Observer-Schnittstelle:** `IObserver` definiert die Methode `Update`.
- **Konkrete Beobachter:** `ConcreteObserverA` und `ConcreteObserverB` reagieren auf Änderungen im `Subject`.
- **Client:** Im `Program` fügt der Client Beobachter zum Subjekt hinzu und löst Änderungen aus.

Dieses Muster fördert die Entkopplung und ermöglicht ein dynamisches Abhängigkeitsmanagement.

---

### 8. State

**Zweck:** Ermöglicht einem Objekt, sein Verhalten zu ändern, wenn sich sein interner Zustand ändert. Das Objekt wirkt, als hätte es seine Klasse geändert.

**Erklärung der Implementierung:**

- **State-Schnittstelle:** `IState` definiert die Methode `Handle`.
- **Konkrete Zustände:** `ConcreteStateA` und `ConcreteStateB` implementieren unterschiedliches Verhalten.
- **Kontext:** `Context` hält eine Referenz auf das aktuelle State-Objekt und delegiert Anfragen an dieses.
- **Client:** Im `Program` ändert der Client den Zustand durch Aufrufe von `Request`.

Dieses Muster erleichtert die Zustandsverwaltung und die Zustandsabhängigkeit von Verhalten.

---

### 9. Strategy

**Zweck:** Definiert eine Familie von Algorithmen, kapselt jeden einzelnen und macht sie austauschbar. Strategy ermöglicht das Variieren des Algorithmus unabhängig von den Clients, die ihn verwenden.

**Erklärung der Implementierung:**

- **Strategie-Schnittstelle:** `IStrategy` definiert die Methode `DoAlgorithm`.
- **Konkrete Strategien:** `ConcreteStrategyA` und `ConcreteStrategyB` implementieren unterschiedliche Algorithmen.
- **Kontext:** `Context` verwendet eine Strategie, die zur Laufzeit festgelegt werden kann.
- **Client:** Im `Program` setzt der Client verschiedene Strategien und führt die Geschäftslogik aus.

Dieses Muster ermöglicht Flexibilität und Austauschbarkeit von Algorithmen.

---

### 10. Template Method

**Zweck:** Definiert das Skelett eines Algorithmus in einer Methode und lässt zu, dass Unterklassen bestimmte Schritte überschreiben, ohne die Struktur des Algorithmus zu ändern.

**Erklärung der Implementierung:**

- **Abstrakte Klasse:** `AbstractClass` enthält die `TemplateMethod`, die den Algorithmus definiert.
- **Abstrakte Methoden:** `RequiredOperation1` und `RequiredOperation2` müssen von Unterklassen implementiert werden.
- **Hooks:** `Hook1` und `Hook2` sind optionale Erweiterungspunkte.
- **Konkrete Klassen:** `ConcreteClass1` und `ConcreteClass2` implementieren die erforderlichen Methoden und können Hooks überschreiben.
- **Client:** Im `Program` verwendet der Client die abstrakte Klasse, ohne die konkreten Implementierungen zu kennen.

Dieses Muster fördert die Wiederverwendbarkeit und Flexibilität von Algorithmen.

---

### 11. Visitor

**Zweck:** Repräsentiert eine Operation, die auf Elementen einer Objektstruktur ausgeführt werden soll. Das Visitor-Muster ermöglicht es, neue Operationen hinzuzufügen, ohne die Klassen der Elemente zu ändern.

**Erklärung der Implementierung:**

- **Visitor-Schnittstelle:** `IVisitor` deklariert Besuchermethoden für jede konkrete Elementklasse.
- **Element-Schnittstelle:** `IElement` definiert die `Accept`-Methode.
- **Konkrete Elemente:** `ConcreteElementA` und `ConcreteElementB` implementieren `Accept`, um Besucher zu akzeptieren.
- **Konkrete Besucher:** `ConcreteVisitor1` und `ConcreteVisitor2` implementieren die Operationen für die Elemente.
- **Objektstruktur:** `ObjectStructure` hält eine Sammlung von Elementen und ermöglicht Besuchern, diese zu traversieren.
- **Client:** Im `Program` erstellt der Client die Objektstruktur und Besucher und führt die Besuche aus.

Dieses Muster erleichtert das Hinzufügen neuer Operationen und trennt Algorithmen von Objekten, auf denen sie arbeiten.
