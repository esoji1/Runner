using System;
using System.Collections;
using TMPro;
using UnityEngine;
using Zenject;

public class BuffInscriptionSpawner : MonoBehaviour, IDisposable
{
    private Player _player;
    private Canvas _ui;
    private TextMeshProUGUI _textPrefab;

    private TextMeshProUGUI _textInfo;
    private FactoryBuffInscriptionSpawner _factory;

    [Inject]
    private void Construct(Player player, Canvas ui, TextMeshProUGUI textPrefab, FactoryBuffInscriptionSpawner factoryBuffInscriptionSpawner)
    {
        _player = player;
        _ui = ui;
        _textPrefab = textPrefab;

        _factory = factoryBuffInscriptionSpawner; //new FactoryBuffInscriptionSpawner(this, _textPrefab, _ui);

        if (_player != null)
            _player.OnPickedUpBuff += _factory.BuffSpawn;
    }

    public void Dispose()
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