using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Iteam
{
    public abstract class AbstractIteams : MonoBehaviour
    {
        public virtual void test()
        {
            Debug.Log("sa");
        }
        public virtual void UseIteam()
        {
            Debug.Log("Kullanıldı");
        }
        protected void onPick(GameObject @object)
        {

            Destroy(@object);
        }
    }
}