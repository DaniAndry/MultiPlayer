using UnityEngine;
using UnityEngine.Events;
using Photon.Pun;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public string Name;
    public bool IsLive;
    public event UnityAction<float, float> HealthChanged;

    public static bool PointerDown = false;

    public event UnityAction<int> MoneyChanged;
    public Vector2 Direction => _direction;

    [SerializeField] private Transform _shootPoint;
    [SerializeField] private Bullet _bullet;
    [SerializeField] private Rigidbody2D _rigidbody;

    private FixedJoystick _joystick;
    private int _moneyBalance;
    private float _health;
    private float _maxHealth = 100f;
    private Button _shootButton;
    private PhotonView _view;
    private float _speed = 5.0f;
    private Vector2 _direction;
    private float _zAxis;
    private PlayersInGame _playersInGame;
    public int Balance => _moneyBalance;

    public void Init(Button shootButton, FixedJoystick joystick, PlayersInGame playersInGame)
    {
        _shootButton = shootButton;
        _shootButton.onClick.AddListener(Attack);
        _joystick = joystick;
        _playersInGame = playersInGame;
    }

    public void Attack()
    {
        GameObject bulletClone = PhotonNetwork.Instantiate(_bullet.name, _shootPoint.position, transform.rotation);
        bulletClone.TryGetComponent(out Bullet bullet);
        bullet.Init(_shootPoint);
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
        HealthChanged?.Invoke(_health, _maxHealth);

        if (_health <= 0)
        {
            IsLive = false;
            _playersInGame.SelectWinner();
        }
    }

    private void Start()
    {
        _health = _maxHealth;
        _view = GetComponent<PhotonView>();
    }

    private void FixedUpdate()
    {
        if (PointerDown)
        {
            _rigidbody.velocity = Vector3.zero;
        }
        else if (_view.IsMine)
        {
            _direction = Vector2.up * _joystick.Vertical + Vector2.right * _joystick.Horizontal;
            _zAxis = Mathf.Atan2(_direction.x, _direction.y) * Mathf.Rad2Deg;

            _rigidbody.MovePosition(_rigidbody.position + _direction * _speed * Time.deltaTime);
            transform.eulerAngles = new Vector3(0f, 0f, -_zAxis);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Coin coin))
        {
            _moneyBalance += coin.Price;
            MoneyChanged?.Invoke(_moneyBalance);
            Destroy(coin.gameObject);
        }
    }
}
