using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameOver : MonoBehaviour
{

    [SerializeField] private TMPro.TextMeshProUGUI _balance;
    [SerializeField] private TMPro.TextMeshProUGUI _name;
    Animator _animator;

    private Money _money;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void ShowWinner(string name, int balance)
    {
        _name.text = name;
        _balance.text = balance.ToString();
        _animator.SetBool("PlayerWin", true);
    }

}
