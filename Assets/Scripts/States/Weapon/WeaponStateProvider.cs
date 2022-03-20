using System;
using GameState;
using UnityEngine;

namespace States
{
    public class WeaponStateProvider : ObjectStateProvider<WeaponState>
    {
        // @param count The count of bursts to add 
        public void AddBursts(int count)
        {
            if (count <= 0) 
                throw new Exception("Invalid burst count value in WeaponStateProvider");
            state.burstCount += count;
        }

        public void SubtractBursts(int count)
        {
            if (count <= 0)
                throw new Exception("Invalid burst count to substract!");
            state.burstCount -= count;
        }

        public void SubtractBullets(int count)
        {
            if (count <= 0)
                throw new Exception("Invalid bullet count to subtract!");
            state.bulletCount -= count;
        }

        public void Reload()
        {
            if (state.burstCount <= 0 || state.bulletCount == state.bulletsInBurst) return;
            SubtractBursts(1);
            state.bulletCount = state.bulletsInBurst;
        }
    }
}