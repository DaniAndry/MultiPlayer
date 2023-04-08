using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersInGame : MonoBehaviour
{
    public List<Player> Players;
    [SerializeField] private GameOver _gameOver;

    public void SelectName(Player player)
    {
        Players.Add(player);

        for (int i = 0; i < Players.Count; i++)
        {
            Players[i].Name = "Player" + i + 1;
        }
    }

    public void SelectWinner()
    {
        _gameOver.ShowWinner(Players[0].Name, Players[0].Balance);
    }
}

