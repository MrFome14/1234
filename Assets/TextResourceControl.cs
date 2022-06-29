using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextResourceControl : MonoBehaviour
{
    public Text text;
    public string Name;

    private void ChangeText(float resourceValue)
    {
        text.text = ((int)resourceValue).ToString();
    }

    private void Start()
    {
        var resource = PlayerResousce.Find(Name);
        ChangeText(resource.GetValue());
        resource.ValueChangeEvent += ChangeText;
    }
}
