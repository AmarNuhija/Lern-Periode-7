using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

public class PferderennenGUI
{
    private List<Pferd> pferdeListe;
    private Pferderennen rennen;

    public PferderennenGUI()
    {
        // Initialisiere Pferdeliste mit Namen und Quoten
        pferdeListe = new List<Pferd>
        {
            new Pferd("Storm", 2.5m),
            new Pferd("Goku", 3.0m),
            new Pferd("Whittaker", 1.8m),
            new Pferd("AlfaAdrian", 1.7m)
        };

        rennen = new Pferderennen(pferdeListe);
    }

    public void StarteRennenMitWette()
    {
        Console.WriteLine("Willkommen beim Pferderennen!");

        // Pferdeliste anzeigen
        Console.WriteLine("Auf welches Pferd möchten Sie wetten? Bitte wählen Sie die Nummer des Pferdes:");
        for (int i = 0; i < pferdeListe.Count; i++)
        {
            Console.WriteLine($"{i}: {pferdeListe[i].Name} (Quote: {pferdeListe[i].Quote})");
        }

        // Auswahl des Pferdes
        int pferdIndex;
        while (!int.TryParse(Console.ReadLine(), out pferdIndex) || pferdIndex < 0 || pferdIndex >= pferdeListe.Count)
        {
            Console.WriteLine("Ungültige Auswahl. Bitte geben Sie eine gültige Pferdenummer ein:");
        }

        // Einsatzbetrag eingeben
        Console.WriteLine("Wie viel möchten Sie setzen?");
        decimal einsatz;
        while (!decimal.TryParse(Console.ReadLine(), out einsatz) || einsatz <= 0)
        {
            Console.WriteLine("Ungültiger Betrag. Bitte geben Sie einen gültigen Einsatz ein:");
        }

        // Wette platzieren
        rennen.WettePlatzieren(pferdIndex, einsatz);

        // Rennen starten und Ergebnis anzeigen
        rennen.RennenStarten();
    }
}
