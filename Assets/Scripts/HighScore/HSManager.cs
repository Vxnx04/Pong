using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HSManager : MonoBehaviour
{
    public static HSManager Instance;
    private string keyToSave = "keyhighscore";

    [Header("References")]
    public TextMeshProUGUI uiTextHighscore;

    void Awake()
    {
        Instance = this;
    }

    void OnEnable()
    {
        UpdateText();
    }

    void UpdateText()
    {
    uiTextHighscore.text = PlayerPrefs.GetString(keyToSave, "No Winners");
    }

    public void SavePlayerWin(Player p)
    {
        PlayerPrefs.SetString(keyToSave, p.playerName);
        UpdateText();

    }
}
