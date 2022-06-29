using UnityEngine;
using UnityEngine.Events;


public class ResourceEvent : MonoBehaviour
{
    public string Name = "firstKey";
    public float requiredAmount = 1;
    public UnityEvent OnEnoughResource;

    public void TryInvoke()
    {
        var resource = PlayerResousce.Find(Name);
        if (resource && resource.GetValue() >= requiredAmount)
        {
            OnEnoughResource.Invoke();
        }
    }
}