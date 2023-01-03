using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonColor : MonoBehaviour
{
public Color color;
[Header("References")]
public Image uiImage;
public Player myPlayer;

void OnValidate()
{
    uiImage = GetComponent<Image>();
}

void Start()
{
    uiImage.color = color;
}


public void OnClick()
{
    myPlayer.ChangeColor(color);
}



}
