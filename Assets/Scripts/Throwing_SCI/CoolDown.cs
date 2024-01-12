using System.Collections;
using System.Collections.Generic;
using UnityEngine;




[System.Serializable]
public class CoolDown 
{
    
    
    
        [SerializeField] private float cooldownTime;
        private float _NextThrowingTime;

        public bool IsCoolingDown => Time.time < _NextThrowingTime;
        public void StartCoolDown() => _NextThrowingTime = Time.time + cooldownTime;
    
}
