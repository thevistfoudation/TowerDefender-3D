using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DataAccount;
using UnityEngine.UI;
using Base.Core;
using UI.LoadingScene;

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
        GameManager.Instance.LoadScene(SceneName.GamePlayScreen);
    }
}
