using Zenject;
using UnityEngine;
using Adhik.Services;

namespace Adhik.Infra.Installers 
{
    public class BootstrapInstaller : MonoInstaller<BootstrapInstaller>
    {
        public override void InstallBindings()
        {
            InstallServices();
        }

        private void InstallServices() 
        {
            Container.Bind<InputService>().FromNewComponentOnNewGameObject().AsSingle().NonLazy();//Install input service
        }
    }
}


