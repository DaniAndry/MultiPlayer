using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _healthBar;

    private Player _player;

    public void Init(Player player)
    {
        _player = player;
    }

    private void Start()
    {
        _player.HealthChanged += OnValueChanged;
        _healthBar.value = 1;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= OnValueChanged;
    }

    public void OnValueChanged(float health, float maxHealth)
    {
        _healthBar.value = health / maxHealth;
    }
}
