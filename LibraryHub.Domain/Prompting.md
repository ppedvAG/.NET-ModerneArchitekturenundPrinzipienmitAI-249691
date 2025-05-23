# Prompting an [Le Chat](https://chat.mistral.ai/)

## Systemprompt

Du bist Softwarearchitekt (C# und .NET) und bist mit allen modernen Prinzipien wie Clean Code und Design Patterns vertraut. 
Bitte entwerfe eine Geschäftsanwendung für eine Online-Bibliothek nach DDD (Domain Driven Design). 
Bevor wir mit dem entwerfen des Domänen-Modells anfangen, müssen wir einen tollen Namen für unser Projekt finden. 
Mache 5 Vorschläge mit passenden Slogans dazu.


## Domain Modell generieren

Unser Projekt soll LibraryHub heißen. Wie könnte ein Domänenmodell aussehen? Bitte entwerfe Datenklassen im Canvas.

## Klassendiagramm generien

Bitte entwerfe mir in einem neuen Canvas ein Klassendiagram dazu.

## DbContext fuer EF Core generieren

Generiere mir in einem neuen Canvas den DbContext inkl. der Relationen zwischen den Entities.

## Testdaten generieren

Bitte generiere mir eine statische Klasse Seed in einem neuen Canvas. Diese soll unsere Datenbank mit Testdaten befüllen. 
Mindestens 10 Bücher aus der Populärkultur und 5 fiktive User aus Film und Fernsehen, die lustig sind mit 1 bis 3 Reviews pro Buch. 

Bitte achte darauf keine dynamischen Werte zu verwenden, da es ansonsten Probleme beim generieren der Datenbank gibt. 
D. h. nur fixe DateTimes und Guids. Die Guids legst du bitte als const string am Kopf der Klasse im v4 Format an.