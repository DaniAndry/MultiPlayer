using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using Unity.VisualScripting;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Button _shootButton;
    [SerializeField] private FixedJoystick _joystick;
    [SerializeField] private HealthBar _healthBar;
    [SerializeField] private Money _money;
    [SerializeField] private Sprite[] _sprites;
  
    private Vector2 _spawnPosition;
    private PlayersInGame _playersInGame;

    private void Awake()
    {
        _spawnPosition = new Vector2(Random.Range(-7, 7), Random.Range(-3, 3));

        GameObject player = PhotonNetwork.Instantiate(_player.name, _spawnPosition, Quaternion.identity);
        player.TryGetComponent(out Player itPlayer);

        _playersInGame = GetComponent<PlayersInGame>();
        _playersInGame.SelectName(itPlayer);

        itPlayer.Init(_shootButton, _joystick, _playersInGame);
        _healthBar.Init(itPlayer);
        _money.Init(itPlayer);
        itPlayer.GetComponent<SpriteRenderer>().sprite = SelectSprite();

    }

    private Sprite SelectSprite()
    {
        int randomNumber = Random.Range(0, _sprites.Length);
        Sprite sprite = _sprites[randomNumber];
        return sprite;
    }
}