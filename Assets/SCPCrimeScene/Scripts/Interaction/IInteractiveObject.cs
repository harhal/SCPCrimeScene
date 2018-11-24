using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InteractionType
{
    Inactive,
    Focus,
    LoseFocus,
    Pressed,
    Active,
    Released
}

public interface IInteractiveObject
{
    void InteractWithObject(InteractionType interactionType, HitInfo hitInfo);

    bool IsEnabled();

    bool ValidateNormalOffset(float normalOffsetCos);
}
