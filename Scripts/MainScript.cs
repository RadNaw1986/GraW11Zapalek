<<<<<<< HEAD
/*Informatyka PUW 23_24_gr.D1_ZTP_Gra_w_11_zapalek
=======
/*Informatyka PUW 23_24_gr.D1_ZTP_Gra_w_11_zapalek_ver2
Wykonal Radoslaw Nawrot_150064*/

using Godot;
using System;

public partial class MainScript : Node2D
{
    private int matchesRemaining = 11;
    private bool isPlayerTurn = true;
    private Random random = new Random();
    private Label gameStatusLabel;
    private Button take1Button;
    private Button take2Button;
    private Button take3Button;
<<<<<<< HEAD
=======
    private Sprite2D[] zapalki = new Sprite2D[11]; // Tablica na Sprite'y zapałek
>>>>>>> 9f65761 (Ukrywanie zapalek po zabraniu)

    public override void _Ready()
    {
        gameStatusLabel = GetNode<Label>("GameStatusLabel");
        take1Button = GetNode<Button>("Take1Button");
        take2Button = GetNode<Button>("Take2Button");
        take3Button = GetNode<Button>("Take3Button");

<<<<<<< HEAD
=======
        // Połącz przyciski z metodami
>>>>>>> 9f65761 (Ukrywanie zapalek po zabraniu)
        take1Button.Connect("pressed", Callable.From(OnTake1ButtonPressed));
        take2Button.Connect("pressed", Callable.From(OnTake2ButtonPressed));
        take3Button.Connect("pressed", Callable.From(OnTake3ButtonPressed));

<<<<<<< HEAD
=======
        // Inicjalizacja sprite'ów zapałek
        for (int i = 0; i < 11; i++)
        {
            zapalki[i] = GetNode<Sprite2D>($"Zapalka{i + 1}"); // Zakładając, że nazwałeś sprite'y Zapalka1, Zapalka2 itd.
        }

>>>>>>> 9f65761 (Ukrywanie zapalek po zabraniu)
        UpdateGameStatus();
    }

    private void UpdateGameStatus()
    {
        gameStatusLabel.Text = $"Pozostało zapałek: {matchesRemaining}";
<<<<<<< HEAD
=======

        // Ukryj odpowiednią liczbę sprite'ów
        for (int i = 0; i < 11; i++)
        {
            zapalki[i].Visible = i < matchesRemaining; // Widoczna jest tylko odpowiednia liczba zapałek
        }

>>>>>>> 9f65761 (Ukrywanie zapalek po zabraniu)
        if (matchesRemaining <= 0)
        {
            GameOver();
        }
    }

    private void OnTake1ButtonPressed()
    {
<<<<<<< HEAD
        GD.Print("Kliknięto Zabierz 1"); // Debug message
=======
>>>>>>> 9f65761 (Ukrywanie zapalek po zabraniu)
        if (isPlayerTurn) TakeMatches(1);
    }

    private void OnTake2ButtonPressed()
    {
<<<<<<< HEAD
        GD.Print("Kliknięto Zabierz 2"); // Debug message
=======
>>>>>>> 9f65761 (Ukrywanie zapalek po zabraniu)
        if (isPlayerTurn) TakeMatches(2);
    }

    private void OnTake3ButtonPressed()
    {
<<<<<<< HEAD
        GD.Print("Kliknięto Zabierz 3"); // Debug message
=======
>>>>>>> 9f65761 (Ukrywanie zapalek po zabraniu)
        if (isPlayerTurn) TakeMatches(3);
    }

    private void TakeMatches(int count)
    {
<<<<<<< HEAD
        GD.Print($"Zabieram {count} zapałek"); // Debug message
        if (count > matchesRemaining) return;

        matchesRemaining -= count;
        UpdateGameStatus(); // Aktualizujemy etykietę po ruchu gracza

        if (matchesRemaining <= 0)
        {
            GameOver(); // Sprawdzamy, czy gra się skończyła
        }
        else
        {
            isPlayerTurn = false; // Zakończenie tury gracza
            GD.Print($"Po Twoim ruchu zostało: {matchesRemaining} zapałek");
            OpponentTurn(); // Rozpoczyna ruch przeciwnika
=======
        if (count > matchesRemaining) return;

        matchesRemaining -= count;
        GD.Print($"Zabrałeś: {count} zapałek"); // Komunikat dla gracza
        UpdateGameStatus();

        if (matchesRemaining <= 0)
        {
            GameOver();
        }
        else
        {
            isPlayerTurn = false;
            OpponentTurn();
>>>>>>> 9f65761 (Ukrywanie zapalek po zabraniu)
        }
    }

    private void OpponentTurn()
    {
        int opponentMove = Math.Min(random.Next(1, 4), matchesRemaining);
        matchesRemaining -= opponentMove;
<<<<<<< HEAD
        GD.Print($"Komputer zabrał: {opponentMove}");
        UpdateGameStatus(); // Aktualizacja etykiety po ruchu przeciwnika
        isPlayerTurn = true; // Przeciwnik zakończył turę
=======
        GD.Print($"Komputer zabrał: {opponentMove} zapałek"); // Komunikat dla komputera
        UpdateGameStatus();
        isPlayerTurn = true;
>>>>>>> 9f65761 (Ukrywanie zapalek po zabraniu)
    }

    private void GameOver()
    {
        if (matchesRemaining <= 0)
        {
            if (isPlayerTurn)
            {
                gameStatusLabel.Text = "Przegrałeś!";
                GD.Print("Gratulacje! Wygrałeś!");
            }
            else
            {
                gameStatusLabel.Text = "Wygrałeś!";
                GD.Print("Przegrałeś! Komputer wygrał!");
            }

            take1Button.Disabled = true;
            take2Button.Disabled = true;
            take3Button.Disabled = true;
        }
    }
}
