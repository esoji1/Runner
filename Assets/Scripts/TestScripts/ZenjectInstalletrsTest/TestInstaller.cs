using Assets.Scripts.TestScripts.ZenjectInstalletrsTest;
using Zenject;
using UnityEngine;
using TMPro;

public class TestInstaller : MonoInstaller
{
    [SerializeField] private TextMeshProUGUI _textPrefab;
    [SerializeField] private Canvas _canvas;

    public override void InstallBindings()
    {
        Container.Bind<TextMeshProUGUI>().FromComponentInNewPrefab(_textPrefab).AsSingle();

        Container.Bind<Canvas>().FromInstance(_canvas).AsSingle();

        Container.BindInterfacesTo<Greeter>().AsSingle();
    }
}