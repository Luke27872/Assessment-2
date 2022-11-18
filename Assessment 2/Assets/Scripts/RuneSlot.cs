using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RuneSlot : MonoBehaviour
{
    public Sprite[] Runes;
    public string[] Slots;

    public Image Slot1;
    public Image Slot2;
    public Image Slot3;

    public void RuneInv(int runeValue)
    {
        if (Slots[0] == "Empty")
        {
            Slot1.sprite = Runes[runeValue];
        }
        else if (Slots[1] == "Empty")
        {
            Slot2.sprite = Runes[runeValue];
        }
        else if (Slots[2] == "Empty")
        {
            Slot3.sprite = Runes[runeValue];
        }
    }
}
