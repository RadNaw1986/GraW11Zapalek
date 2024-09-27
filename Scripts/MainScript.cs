/*Informatyka PUW 23_24_gr.D1_ZTP_Gra_w_11_zapalek
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

    public override void _Ready()
    {
        gameStatusLabel = GetNode<Label>("GameStatusLabel");
        take1Button = GetNode<Button>("Take1Button");
        take2Button = GetNode<Button>("Take2Button");
        take3Button = GetNode<Button>("Take3Button");

        take1Button.Connect("pressed", Callable.From(OnTake1ButtonPressed));
        take2Button.Connect("pressed", Callable.From(OnTake2ButtonPressed));
        take3Button.Connect("pressed", Callable.From(OnTake3ButtonPressed));

        UpdateGameStatus();
    }

    private void UpdateGameStatus()
    {
        gameStatusLabel.Text = $"Pozostało zapałek: {matchesRemaining}";
        if (matchesRemaining <= 0)
        {
            GameOver();
        }
    }

    private void OnTake1ButtonPressed()
    {
        GD.Print("Kliknięto Zabierz 1"); // Debug message
        if (isPlayerTurn) TakeMatches(1);
    }

    private void OnTake2ButtonPressed()
    {
        GD.Print("Kliknięto Zabierz 2"); // Debug message
        if (isPlayerTurn) TakeMatches(2);
    }

    private void OnTake3ButtonPressed()
    {
        GD.Print("Kliknięto Zabierz 3"); // Debug message
        if (isPlayerTurn) TakeMatches(3);
    }

    private void TakeMatches(int count)
    {
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
        }
    }

    private void OpponentTurn()
    {
        int opponentMove = Math.Min(random.Next(1, 4), matchesRemaining);
        matchesRemaining -= opponentMove;
        GD.Print($"Komputer zabrał: {opponentMove}");
        UpdateGameStatus(); // Aktualizacja etykiety po ruchu przeciwnika
        isPlayerTurn = true; // Przeciwnik zakończył turę
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
