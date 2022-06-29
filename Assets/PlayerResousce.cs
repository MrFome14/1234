using UnityEngine;
using System;
using UnityEngine.Events;


public class PlayerResousce : MonoBehaviour
{
    public static PlayerResousce Find(string name)
    {
        foreach (var resource in FindObjectsOfType<PlayerResousce>())
        {
            if (resource.resourceName == name)
            {
                return resource;
            }
        }
        return null;
    }

    [SerializeField] private float value = 0;
    public float GetValue() => value;
    [SerializeField] private float maxValue = 9999;
    public float GetMaxValue() => maxValue;

    public string resourceName = "money";

    public void ChangeValue(float change)
    {
        value = Mathf.Clamp(value + change, 0, maxValue);
        if (ValueChangeEvent != null)
        {
            ValueChangeEvent(value);
        }
        if (value == 0)
        {
            OnZero.Invoke();
        }
    }

    public event Action<float> ValueChangeEvent;
    public UnityEvent OnZero;
}