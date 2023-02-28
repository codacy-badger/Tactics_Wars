using System;
using UnityEngine;

public class AnimationEventSystem : MonoBehaviour
{
    public static Action AnimationFinishedEvent;

    // called in an animation
    public void FinishAnimation()
    {
        AnimationFinishedEvent?.Invoke();
    }
}
