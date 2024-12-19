using UnityEngine;
using UnityEngine.Events;

public class AudioFeedBack : MonoBehaviour
{
    public UnityEvent OnAnimationAction;
    public void InvokeAnimationAction()
    {
        OnAnimationAction?.Invoke();
    }

}
