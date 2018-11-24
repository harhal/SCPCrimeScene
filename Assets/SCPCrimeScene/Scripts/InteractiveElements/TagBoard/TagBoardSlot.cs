using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagBoardSlot : MonoBehaviour 
{
    public TagBoardPart SlotContent;
    public TagBoardSlot Next;
    public TagBoardSlot Previous;

    public int? GetValue()
    {
        if (SlotContent == null)
        {
            return null;
        }
        else
        {
            return SlotContent.Value();
        }
    }
}
