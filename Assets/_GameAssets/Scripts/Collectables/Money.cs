using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour,IInteractable
{
    [SerializeField] private int _amount;

    public void Interact()
    {
        //TODO: INSTANTIATE + DOLLAR SIGN, ADD MONEY TO THE TOTAL MONEY AMOUNT
        gameObject.SetActive(false);
    }

    public void InteractionStopped()
    {
        
    }
}
