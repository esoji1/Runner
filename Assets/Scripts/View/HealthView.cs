using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class HealthView : MonoBehaviour
{
    [SerializeField] private ObstacleDetection _obstacleDetection;
    [SerializeField] private Image _health;
    [SerializeField] private Player _player;

    private int _hp;
    private Tween _animation;

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

    public void KillAnimatonAddHealth()
    {
        _animation.Kill();
    }

    private void Damage(int damege)
    {
        KillAnimatonAddHealth();

        _hp -= damege;

        _animation = _health
            .DOFillAmount(_hp / 100f, 1f)
            .SetUpdate(true)
            .SetEase(Ease.OutQuad);
    }

    private void AddHealh(int health)
    {
        KillAnimatonAddHealth();

        _hp += health;

        _animation = _health
            .DOFillAmount(_hp / 100f, 1f)
            .SetEase(Ease.OutQuad);
    }
}