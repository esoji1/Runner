using Assets.Scripts;
using System;
using UnityEngine;
using TMPro;

public class FactoryBuffInscriptionSpawner
{
    private Canvas _ui;
    private TextMeshProUGUI _textPrefab;
    private BuffInscriptionSpawner _inscriptionSpawner;

    private TextMeshProUGUI _textInfo;
    private float _deleteTextTime = 2f;
    private BuffInscriptionView _buffInscriptionView;

    public FactoryBuffInscriptionSpawner(BuffInscriptionSpawner inscriptionSpawner, TextMeshProUGUI textPrefab, Canvas ui)
    {
        _ui = ui;
        _textPrefab = textPrefab;
        _inscriptionSpawner = inscriptionSpawner;

        _buffInscriptionView = new BuffInscriptionView();
    }

    public TextMeshProUGUI BuffSpawn(Buff buff, float value)
    {
        switch (buff)
        {
            case Buff.BuffSpeedLine:
                return ShowText(value, "к скорости");

            case Buff.BuffHorizontalSpeed:
                return ShowText(value, "к скорости горизонтали");

            case Buff.BuffAddHealth:
                return ShowText(value, "к хп");

            default:
                throw new ArgumentException(nameof(buff));
        }
    }

    private TextMeshProUGUI ShowText(float value, string str)
    {
        _textInfo = UnityEngine.Object.Instantiate(_textPrefab, _ui.transform);
        _textInfo.transform.SetSiblingIndex(0);

        _textInfo.text += value.ToString() + " " + str;

        _buffInscriptionView.ShowAnimation(_textInfo);

        _inscriptionSpawner.StartDestroyCoroutine(_textInfo, _deleteTextTime);
        return _textInfo;
    }
}