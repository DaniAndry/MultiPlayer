using Photon.Pun.Demo.Asteroids;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Coin _coin;
    private Vector2 _position;

    private float _timeAfterLastSpawn = 0f;
    private float _needTime = 1.5f;


    private void Update()
    {
        _timeAfterLastSpawn += Time.deltaTime;

        if (_timeAfterLastSpawn >= _needTime)
        {
            SelectRandomPossition();
            Spawn();
            _timeAfterLastSpawn = 0f;
        }
    }

    private void Spawn()
    {
        GameObject coinClone = PhotonNetwork.Instantiate(_coin.name, _position, Quaternion.identity);
    }

    private void SelectRandomPossition()
    {
        _position.x = Random.Range(-8, 8);
        _position.y = Random.Range(-4, 4);
    }
}
