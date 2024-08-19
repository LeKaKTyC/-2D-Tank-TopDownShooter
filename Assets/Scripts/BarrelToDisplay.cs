using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarrelToDisplay : MonoBehaviour
{
    [SerializeField] private Barrel _barrel;
    [SerializeField] private Text _titleTxt; 
    [SerializeField] private Text _descriptionTxt;
    [SerializeField] private Text _radiusTxt;
    [SerializeField] private Text _radiusValueTxt;
    [SerializeField] private Image _image;

    private void Start()
    {
        _titleTxt.text = _barrel.title;
        _descriptionTxt.text = _barrel.description;
        _radiusValueTxt.text = _barrel.radius.ToString();
        _image.sprite = _barrel.sprite;
    }
}
