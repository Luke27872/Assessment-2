using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunePickup : MonoBehaviour
{
    public RuneSlot runeSlot;

    public int runeValue;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Target")
        {
            runeSlot.RuneInv(runeValue);
            Destroy(gameObject);
        }
    }
}
