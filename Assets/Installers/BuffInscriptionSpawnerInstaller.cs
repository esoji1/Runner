using TMPro;
using UnityEngine;
using Zenject;

public class BuffInscriptionSpawnerInstaller : MonoInstaller
{
    [SerializeField] private Canvas _ui;
    [SerializeField] private TextMeshProUGUI _textPrefab;

    public override void InstallBindings()
    {
        ParameterBinding();

        Container
            .BindInterfacesAndSelfTo<BuffInscriptionSpawner>()
            .FromComponentInHierarchy() 
            .AsSingle();

        Container
            .Bind<FactoryBuffInscriptionSpawner>()
            .AsSingle();
    }

    private void ParameterBinding()
    {
        Container
           .Bind<TextMeshProUGUI>()
           .FromInstance(_textPrefab)
           .AsSingle();

        Container
            .Bind<Canvas>()
            .FromInstance(_ui)
            .AsSingle();

        Container
            .Bind<Player>()
            .FromComponentInHierarchy()
            .AsSingle();
    }
}