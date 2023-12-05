using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModuleUiMain : MonoBehaviour, ModuleUiListener
{

    [SerializeField] private Button _createWarriorBtn;

    private void Awake()
    {
        ButtonListener();
    }

    public void ButtonListener()
    {
        _createWarriorBtn.onClick.AddListener(CreateWarrior);
    }

    private void CreateWarrior()
    {
        GameController.Instance.CreateAndInitWarriorPlayerClass();
    }
}
