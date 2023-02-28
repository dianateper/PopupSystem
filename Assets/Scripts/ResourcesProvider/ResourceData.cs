using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class ResourceData
{
    [SerializeField] private string _url;
    [SerializeField] private Image _image;
    public string Url => _url;
    public Image Image => _image;
}