using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChangeName : MonoBehaviour
{
    [Header("References")]
    public TextMeshProUGUI uiTextName;
    public TMP_InputField uiInputField;
    public GameObject changeNameInput;
    public Player myPlayer;

    private string playerName;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeNamePlayer()
    {
        playerName = uiInputField.text;
        myPlayer.playerName = playerName;
        uiTextName.text = playerName;
        changeNameInput.SetActive(false);
    }
}
