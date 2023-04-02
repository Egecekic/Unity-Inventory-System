using Assets.Scripts.InterFaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Iteam
{
    public class HealIteam : AbstractIteams, IPickAble
    {
        public void Pick()
        {
            
            onPick(gameObject);
        }
        public override void UseIteam()
        {
            base.UseIteam();
            
        }
        
        
    }
}