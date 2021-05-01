using Zenject;
using UnityEngine;
public class UntitledInstaller : MonoInstaller{
    public override void InstallBindings(){
        Container.Bind<ICommand<ICommandContext>>().To<MoveCommand<MoveCommandContext>>();
    }
}