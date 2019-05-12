using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{

    public bool GameOver = false;
    public List<Player> Players = new List<Player>();
    public int DeathCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Ahoy");

        // Hardcoding 6 players (4 on console, 2 on keyboard)
        // TODO: Replace with player selection screen
        Players.Add(new Player { ID = 0, Controller = 1, Name = "Carrot" });
        Players.Add(new Player { ID = 1, Controller = 2, Name = "Broccoli" });
        Players.Add(new Player { ID = 2, Controller = 3, Name = "Potato" });
        Players.Add(new Player { ID = 3, Controller = 4, Name = "Shrimp" });
        Players.Add(new Player { ID = 4, Controller = 100, Name = "Onion" });
        Players.Add(new Player { ID = 5, Controller = 101, Name = "Egg" });

    }

    // Update is called once per frame
    void Update()
    {
        if (GameOver)
        {
            Time.timeScale = 0;
        }
    }
    
    // Kill off a player (by PlayerID)
    public void Kill(int id)
    {
        Player player = Players.Find(p => p.ID == id);
        player.Alive = false;
        player.DeathIndex = DeathCount++;

        if (Players.TrueForAll(p => p.Alive == false))
            GameOver = true;
    }

    void OnGUI()
    {
        if (GameOver)
        {
            Player winner = Players.Find(p => p.DeathIndex == DeathCount);
            if (winner == null) winner = new Player { ID = -1, Controller = -1, Name = "Nobody" };

            string text = "Game over!\n\nPlayer " + winner.Name + " won!";
            GUI.TextField(new Rect(100, 100, 500, 100), text, 1000);
        }
    }

    // Reset the game
    void RestGame()
    {
        // TODO
    }

}

public class Player
{
    public int ID { get; set; }
    public bool Alive { get; set; } = true;
    public int Controller { get; set; }
    public string Name { get; set; }
    public int DeathIndex { get; set; } = -1;
    public MovementScriptTest MovementScript { get; set; } = null;
}
