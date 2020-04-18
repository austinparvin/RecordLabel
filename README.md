# Record Label

A console app that stores our artist information in a database.

# Objectives

- Create a console app that uses an ORM to talk to a database
- Working with EF Core
- Reenforce SQL basics
- One to many relationships
- Integrate 3rd party packages

# Includes: 

- [C#](https://docs.microsoft.com/en-us/dotnet/csharp/)
- [LINQ](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/)
- [EF CORE](https://docs.microsoft.com/en-us/ef/core/)
- [POSTGRESQL](https://www.postgresql.org/)
- [CONSOLE MENU](https://www.nuget.org/packages/ConsoleMenu-simple/)
- [MVC](https://dotnet.microsoft.com/apps/aspnet/mvc)

## Featured Code

### One to many relationship POCO

```C#
  public class Album
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsExplicit { get; set; }
        public DateTime ReleaseDate { get; set; }

        // Navigation Properties
        public int BandId { get; set; }
        public Band Band { get; set; }

        public List<Song> Songs { get; set; } = new List<Song>();

    }
 ```
 
## User Actions

- Sign a band
- Produce an album
- Let go a band
- Resign a band
- View all albums for a band
- View all albums, ordered by ReleaseDate
- View an Album's songs
- View All bands that are signed
- View all bands that are not signed
- Exit

## App In Action

### CONSOLE MENU
![record it](http://g.recordit.co/IQAXEJN0TA.gif)

### SIGN A BAND
![record it](http://g.recordit.co/AYF7TqzAcO.gif)

### PRODUCE AN ALBUM
![record it](http://g.recordit.co/g9LVmhZGZP.gif)

### LET GO A BAND & RESIGN A BAND
![record it](http://g.recordit.co/ZiwszBUqer.gif)

### VIEW
![record it](http://g.recordit.co/R6CztbO3Ej.gif)

