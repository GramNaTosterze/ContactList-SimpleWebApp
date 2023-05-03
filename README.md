# ContactList-SimpleWebApp

## Zadanie do zrobienia:

- logowanie
- przeglądanie listy kontaktów
- Szczególy kontaktu
    - imię,
    - nazwisko,
    - email - unikalny
    - hasło - spełniające standardy złożoności
    - kategoria (służbowy, prywatny, inny)
    - podkategoria (dla słyżbowy - szef, klient, itp. , dla inny dodanie własnej)
    - telefon
    - data urodzenia

# Specyfikacja techniczna

Projekt został wykonany na platformie Windows za pomocą **Microsoft Visual Studio 2022**. Użytą bazą danych jest lokalna baza SQL Server.

## Wykorzystane biblioteki:
Wszystkie biblioneki pobrane poprzez manadżer pakietów NuGet
Wykorzystane biblioteki:
- Microsoft.AspNetCore.Identity - Logowania
- Microsoft.EntityFrameworkCore - Operacje na bazie danych
## Kompilacja:

Projekt jest robiony za pomocą **Microsoft Visual Studio 2022** i po odpaleniu wystarczy kliknąć prawym na projekt i ko skompilować alternatywnie kliknąć w opcję debugowania co automatycznie skompiluje projekt.

## Opis klas:

### Dane:

**ContactList_SimpleWebAppContext** - Kontekst umożliwiający dostęp do bazy danych.

### Modele:

**Contact** - model reprezentujący Kontakt w bazie danych.

**ContactCategory** - model reprezentujący kategorię kontaktu w bazie danych.

**SeedData** - klasa z jedną metodą statyczną **Initialize** służąca do inicjalizacji bazy danych. 

### Kontrolery:

**ContactsController** - Kontroler służący do obsługi zapytań GET oraz POST od strony Contacts. Metody służą do obsługi tworzenia oraz edycji elementów oraz wyświetlania odpowiedzniego widoku. Metoda **Categories** służy do pozyskania kategorii z bazy danych i wpisania do SelectList.

### Migracje
klasy migracji automatycznie wygenerowane przez EntityFrameworkCore w celach zmian w bazie danych.
