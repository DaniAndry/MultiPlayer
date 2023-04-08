using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{
    public TMPro.TextMeshProUGUI Balance;
    private Player _player;

    public void Init(Player player)
    {
        _player= player;
    }
    private void Start()
    {
      _player.MoneyChanged += OnValueChanged;
    }

    private void OnDisable()
    {
        _player.MoneyChanged -= OnValueChanged;
    }

    private void OnValueChanged(int money)
    {
        Balance.text = money.ToString();
    }
}
