using UnityEngine;
using UnityEngine.UI;

public class HealthView : MonoBehaviour
{
    [SerializeField] private ObstacleDetection _obstacleDetection;
    [SerializeField] private Image _health;
    [SerializeField] private Player _player;

    private int _hp;

    private void Start()
    {
        _hp = _obstacleDetection.Health;
        _health.fillAmount = _hp / 100f;
    }

    private void OnEnable()
    {
        _obstacleDetection.OnDamageHealthPlayer += Damage;
        _player.OnAddHealth += AddHealh;
    }

    private void OnDisable()
    {
        _obstacleDetection.OnDamageHealthPlayer -= Damage;
        _player.OnAddHealth -= AddHealh;
    }

    private void Damage(int damege)
    {
        _hp -= damege;
        _health.fillAmount = _hp / 100f;
    }

    private void AddHealh(int health)
    {
        _hp += health;
        _health.fillAmount = _hp / 100f;
    }
}