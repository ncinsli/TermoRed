using UnityEngine;
using Zenject;
using System;
using System.Collections;
using System.Collections.Generic;
public class EntityManager : MonoBehaviour{
    // public List<ICommand> commands = new List<ICommand<ICommandContext>>();
    private ICommand command;
    [Inject]
    public void Construct(ICommand cmd){
        command = cmd;
        // commands = GetComponents<ICommand>();
    }
    private void Update(){
        command.Execute();
    }
}

public class TestCommandContext : ICommandContext{

}