using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DataAccount;
using UnityEngine.UI;

public class ModuleUiLose : MonoBehaviour, ModuleUiListener
{
    [SerializeField] private Button tryAgainLevel;

    private void Awake()
    {
        ButtonListener();
    }

    public void ButtonListener()
    {
        
    }
}
