using Core.Screens.View.City;
using Core.Screens.View.Loader;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class ViewInstaller : MonoInstaller
    {
        [SerializeField] private CityView _cityView;
        [SerializeField] private LoaderView _loaderView;

        [SerializeField] private AlchemyView _alchemyView;
        [SerializeField] private DealerView _dealerView;
        [SerializeField] private TavernView _tavernView;

        public override void InstallBindings()
        {
            Container.BindFactory<CityView, CityView.Factory>().FromComponentInNewPrefab(_cityView);
            Container.BindFactory<LoaderView, LoaderView.Factory>().FromComponentInNewPrefab(_loaderView);

            Container.BindFactory<AlchemyView, AlchemyView.Factory>().FromComponentInNewPrefab(_alchemyView);
            Container.BindFactory<TavernView, TavernView.Factory>().FromComponentInNewPrefab(_tavernView);
        }
    }
}
