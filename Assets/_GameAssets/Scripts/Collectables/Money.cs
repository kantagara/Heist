using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : Interactable
{
    [SerializeField] private int _amount;

    public override void Interact()
    {
        //TODO: INSTANTIATE + DOLLAR SIGN, ADD MONEY TO THE TOTAL MONEY AMOUNT
        Destroy(gameObject);
    }
}
