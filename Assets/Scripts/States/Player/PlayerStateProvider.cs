using System;
using GameState;
using UnityEngine;

namespace States
{
    public class PlayerStateProvider : ObjectStateProvider<PlayerState>
    {
        public void TakeDamage(int damage)
        {
            if (damage <= 0) 
                throw new Exception("Invalid damage value in PlayerStateProvider");

            state.health -= damage;
            
            Save();
        }
    }
}