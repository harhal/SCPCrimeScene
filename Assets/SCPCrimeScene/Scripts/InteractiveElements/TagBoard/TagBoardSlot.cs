using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TagBoardSlot : MonoBehaviour 
{
    public TagBoardPart SlotContent;
    public TagBoardSlot[] Connected;

    public TagBoard BorderOwner;

    private void Start()
    {
        TagBoard borderOwner = transform.parent.GetComponent<TagBoard>();
        if (borderOwner == null)
        {
            return;
        }

        BorderOwner = borderOwner;
    }

    public int? GetValue()
    {
        if (SlotContent == null)
        {
            return null;
        }
        else
        {
            return SlotContent.Value;
        }
    }

    public bool IsFree()
    {
        return SlotContent == null;
    }

    public void Swap(TagBoardSlot anotherSlot)
    {
        if (anotherSlot == this)
        {
            return;
        }
        
        TagBoardPart buffer = anotherSlot.SlotContent;

        if (SlotContent != null)
        {
            SlotContent.SlotOwner = anotherSlot;
        }

        anotherSlot.SlotContent = SlotContent;
        
        SlotContent = buffer;
        if (SlotContent != null)
        {
            SlotContent.SlotOwner = this;
        }
    }

    public bool MoveContentToFree()
    {
        foreach (var connection in Connected)
        {
            if (connection.IsFree())
            {
                Swap(connection);
                if (connection.SlotContent != null)
                {
                    connection.SlotContent.UpdatePosition();
                }

                if (SlotContent != null)
                {
                    SlotContent.UpdatePosition();
                }

                BorderOwner.OnBoardUpdated();

                return true;
            }
        }
        return false;
    }

    private void OnDrawGizmos()
    {
        if (Connected == null)
        {
            return;
        }

        if (Connected.Length <= 0)
        {
            Gizmos.DrawWireSphere(transform.position, .5f);
            return;
        }

        foreach (var connection in Connected)
        {
            if (connection == null)
            {
                return;
            }

            Gizmos.DrawLine(transform.position, connection.transform.position);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        
        if (Connected == null)
        {
            return;
        }
        
        Gizmos.DrawWireSphere(transform.position, .3f);

        Gizmos.color = Color.red;
        
        foreach (var connection in Connected)
        {
            if (connection == null)
            {
                return;
            }

            Gizmos.DrawLine(transform.position, connection.transform.position);
            Gizmos.DrawWireSphere(connection.transform.position, .2f);
        }
    }
}
