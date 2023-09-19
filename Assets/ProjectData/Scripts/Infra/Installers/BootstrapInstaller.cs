using Zenject;
using UnityEngine;
using Adhik.Services;
using Adhik.Infra.Networking;

namespace Adhik.Infra.Installers 
{
    public class BootstrapInstaller : MonoInstaller<BootstrapInstaller>
    {
        [SerializeField] 
        private FpsNetworkManager _networkManager;
        [SerializeField] 
        private CameraService _cameraServicePrefab;

        public override void InstallBindings()
        {
            InstallServices();
            Container.Bind<FpsNetworkManager>()
                .FromComponentInNewPrefab(_networkManager)
                .AsSingle()
                .NonLazy();
        }

        private void InstallServices() 
        {
            Container.Bind<InputService>().FromNewComponentOnNewGameObject().AsSingle().NonLazy();//Install input service
            Container.Bind<CameraService>().FromComponentInNewPrefab(_cameraServicePrefab).AsSingle().NonLazy();//Install camera service
        }
    }
}


