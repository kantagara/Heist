using System;
using UnityEngine;

namespace Heist.Deposit
{
    public class DepositSafe : MonoBehaviour
    {
        //public DepositBox[] Boxes;

        private void Awake()
        {
            var boxes = FindObjectsOfType<DepositBox>();
            
            foreach (var depositBox in boxes)
                depositBox.gameObject.SetActive(UnityEngine.Random.value >= .3f);
        }
    }
}
