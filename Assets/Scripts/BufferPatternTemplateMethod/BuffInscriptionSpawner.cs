using System.Collections;
using TMPro;
using UnityEngine;

public class BuffInscriptionSpawner : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Canvas _ui;
    [SerializeField] private TextMeshProUGUI _textPrefab;

    private TextMeshProUGUI _textInfo;
    private FactoryBuffInscriptionSpawner _factory;

    private void Awake()
    {
        _factory = new FactoryBuffInscriptionSpawner(this, _textPrefab, _ui);
    }

    private void OnEnable()
    {
        if (_player != null)
            _player.OnPickedUpBuff += _factory.BuffSpawn;
    }

    private void OnDisable()
    {
        if (_player != null)
            _player.OnPickedUpBuff -= _factory.BuffSpawn;
    }

    public void StartDestroyCoroutine(TextMeshProUGUI textInfo, float deleteTextTime)
    {
        StartCoroutine(DestroyText(textInfo, deleteTextTime));
    }

    private IEnumerator DestroyText(TextMeshProUGUI textInfo, float deleteTextTime)
    {
        yield return new WaitForSeconds(deleteTextTime);
        Destroy(textInfo.gameObject);
    }
}