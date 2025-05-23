# Moderne Architekturen und Designprinzipien
Kurs Repository zu Kurs .NET - Moderne Architekturen und Designprinzipien der ppedv AG

## M001 | Was Architektur ist

- [ ] Ebenenmodell
- [ ] Aspekte, Richtlinien, Analyse
- [ ] 3P-Regel: Product, Process, People
- [ ] Funktional vs. Nicht-Funktional
- [ ] Kosten und Technische Schulden

## M002 | Architektur�berblick

- [ ] Cargo Cult Programming
- [ ] �berblick verschiedener Architekturen
- [ ] Beispiel Clean-Architecture "Todo List"

```bash
dotnet new install Clean.Architecture.Solution.Template
```

## M003 | Design Patterns

- [ ] Relevanz und Entwicklung der Muster
- [ ] Creational Patterns: Wie werden Objekte erzeugt?
  *  FactoryMethod als PizzaShop
  *  BuilderPattern als PizzaConfigurator
- [ ] Structural Patterns: Wie werden Objekte verbunden und integriert?
  *  Decorator: Pizza schneiden und verpacken
  *  Adapter: Pfannen-Pizza als "normale" Pizza bestellen
- [ ] Behavioral Patterns: Wie verhalten sich Objekte und Objektstrukturen?
  *  Strategy: Pizza mit einem Fahrzeug ausliefern
- [ ] Lab Payment-Service

## M004 | Design Principles

- [ ] Prinzipien und Code-Smells
- [ ] SOLID Bewertung
- [ ] S�ulen der OOP, Koh�sion und Kopplung
- [ ] Beispiele zu ISP und DIP
- [ ] Lab Artikel: Ist Architektur �berbewertet?

## M005 | Event Sourcing

- [ ] Domain Driven Design
- [ ] Datenpersistenz
- [ ] Beispiel Student Course
- [ ] Lab Bankkonto

## M006 | WebAPI mit CQRS

- [ ] Repository Pattern
- [ ] Mediator Pattern
- [ ] Service API
- [ ] Beispiel Auftragsverwaltung
- [ ] Lab Bankkonto API

## M007 | Business Anwendung

- [ ] Eigene Gesch�ftsanwendung entwerfen
- [ ] Klassendiagramm erstellen mit draw.io
- [ ] Dom�nen-modell generieren lassen
- [ ] Testdatenbank mit Entity Framework
- [ ] [�berblick Strategien](https://learn.microsoft.com/de-de/ef/core/testing/)
- [ ] Testdaten generieren lassen
- [ ] Gesch�ftslogik implementieren
- [ ] WebAPI erstellen
- [ ] WebAPI mit [http-files testen](https://learn.microsoft.com/de-de/aspnet/core/test/http-files)
- [ ] Weitere Front-Ends erstellen