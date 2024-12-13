using System;
using System.Collections.Generic;

public class PferderennenGUI
{
    private List<Pferd> pferdeListe;
    private Pferderennen rennen;
    private decimal konto = 1000m; // Startguthaben des Spielers

    public PferderennenGUI()
    {
        // Initialisiere Pferdeliste mit Namen und Quoten
        pferdeListe = new List<Pferd>
        {
            new Pferd("Denis", 2.5m),
            new Pferd("Anes", 3.0m),
            new Pferd("Berin", 1.8m),
            new Pferd("Omer", 1.7m)
        };

        rennen = new Pferderennen(pferdeListe);
    }

    public void StarteRennenMitWette()
    {
        Console.WriteLine("Willkommen beim Pferderennen!");
        bool weiterspielen = true;

        while (weiterspielen)
        {
            Console.WriteLine("\nIhr aktuelles Guthaben: {0:C}", konto);

            // Rennen zurücksetzen, bevor ein neues beginnt
            rennen.ResetRennen();

            // Pferdeliste anzeigen
            Console.WriteLine("\nAuf welches Pferd möchten Sie wetten? Bitte wählen Sie die Nummer des Pferdes:");
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
            while (!decimal.TryParse(Console.ReadLine(), out einsatz) || einsatz <= 0 || einsatz > konto)
            {
                Console.WriteLine("Ungültiger Betrag. Bitte geben Sie einen gültigen Einsatz ein (maximal {0:C}):", konto);
            }

            // Wette platzieren
            rennen.WettePlatzieren(pferdIndex, einsatz);

            // Rennen starten und Ergebnis anzeigen
            rennen.RennenStarten();

            // Konto aktualisieren basierend auf dem Rennergebnis
            if (rennen.GewaehltGewonnen)
            {
                konto += rennen.GewinnBetrag - einsatz;
            }
            else
            {
                konto -= einsatz;
            }

            Console.WriteLine("\nIhr neues Guthaben: {0:C}", konto);

            // Spiel beenden, falls Guthaben aufgebraucht
            if (konto <= 0)
            {
                Console.WriteLine("Ihr Guthaben ist aufgebraucht. Vielen Dank fürs Spielen!");
                break;
            }

            // Fragen, ob der Spieler weiterspielen möchte
            weiterspielen = WillWeiterSpielen();
        }

        Console.WriteLine("\nVielen Dank fürs Spielen! Bis zum nächsten Mal.");
    }


    private bool WillWeiterSpielen()
    {
        while (true)
        {
            Console.WriteLine("Möchten Sie weiterspielen? (ja/nein)");
            string antwort = Console.ReadLine()?.Trim().ToLower();

            if (antwort == "ja")
            {
                return true;
            }
            else if (antwort == "nein")
            {
                return false;
            }
            else
            {
                Console.WriteLine("Ungültige Eingabe. Bitte antworten Sie mit 'ja' oder 'nein'.");
            }
        }
    }
}
