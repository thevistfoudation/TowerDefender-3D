using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DataAccount;
using UnityEngine.UI;

public class ModuleUiWin : MonoBehaviour, ModuleUiListener
{

    [SerializeField] private Button nextLevel;

    private void Awake()
    {
        ButtonListener();
    }

    public void ButtonListener()
    {
        DataAccountPlayer.PlayerResourceData.LevelUp();
    }
}
