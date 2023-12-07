using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DataAccount;
using UnityEngine.UI;

public class ModuleUiMain : MonoBehaviour, ModuleUiListener
{
    [Header("Header")]
    [SerializeField] private TextMeshProUGUI _goldText;
    [SerializeField] private TextMeshProUGUI _gemText;

    [Header("Warrior")]
    [SerializeField] private Button _createWarriorBtn;
    [SerializeField] private Button _upgradeWarriorBtn;
    [Header("Archer")]
    [SerializeField] private Button _createArcherBtn;
    [SerializeField] private Button _upgradeArcherBtn;
    [Header("Wizzard")]
    [SerializeField] private Button _createWizzardBtn;
    [SerializeField] private Button _upgradeWizzardBtn;

    [Header("Popup")]
    [SerializeField] private GameObject _winPopup;
    [SerializeField] private GameObject _losePopup;

    private int goldValue;
    private int gemValue;

    private void Awake()
    {
        ButtonListener();
        EventListener();
        InitData();
    }

    private void InitData()
    {
        goldValue = DataAccountPlayer.PlayerResourceData.gold;
        gemValue = DataAccountPlayer.PlayerResourceData.gem;
        _goldText.text = goldValue.ToString();
        _gemText.text = gemValue.ToString();
    }

    private void EventListener()
    {
        this.RegisterListener(EventID.ChangeMoneyValue, (sender, param) => InitData());
        this.RegisterListener(EventID.ChangeGemValue, (sender, param) => InitData());
        this.RegisterListener(EventID.Win, (sender, param) => Win());
        this.RegisterListener(EventID.Lose, (sender, param) => Lose());
    }

    public void ButtonListener()
    {
        _createWarriorBtn.onClick.AddListener(CreateWarrior);
        _upgradeWarriorBtn.onClick.AddListener(UpgradeWarrior);

        _createArcherBtn.onClick.AddListener(CreateArcher);
        _upgradeArcherBtn.onClick.AddListener(UpgradeArcher);

        _createWizzardBtn.onClick.AddListener(CreateWizzard);
        _upgradeWizzardBtn.onClick.AddListener(UpgradeWizzard);
    }

    private void CreateWarrior()
    {
        if(goldValue >= 10)
        {
            GameController.Instance.CreateAndInitWarriorPlayerClass();
            DataAccountPlayer.PlayerResourceData.ChangeGold(-10);
        }
    }

    private void UpgradeWarrior()
    {
        if(goldValue >= 15)
        {
            DataAccountPlayer.WarriorData.UpgradeWarriorLevel();
            DataAccountPlayer.PlayerResourceData.ChangeGold(-15);
        }
    }

    private void CreateArcher()
    {
        if (goldValue >= 10)
        {
            GameController.Instance.CreateAndInitWarriorPlayerClass();
            DataAccountPlayer.PlayerResourceData.ChangeGold(-10);
        }
    }

    private void UpgradeArcher()
    {
        if (goldValue >= 15)
        {
            DataAccountPlayer.WarriorData.UpgradeWarriorLevel();
            DataAccountPlayer.PlayerResourceData.ChangeGold(-15);
        }
    }

    private void CreateWizzard()
    {
        if (goldValue >= 10)
        {
            GameController.Instance.CreateAndInitWarriorPlayerClass();
            DataAccountPlayer.PlayerResourceData.ChangeGold(-10);
        }
    }

    private void UpgradeWizzard()
    {
        if (goldValue >= 15)
        {
            DataAccountPlayer.WarriorData.UpgradeWarriorLevel();
            DataAccountPlayer.PlayerResourceData.ChangeGold(-15);
        }
    }

    private void Win()
    {
        _winPopup.SetActive(true);
        DataAccountPlayer.PlayerResourceData.ChangeGold(100);
    }

    private void Lose()
    {
        _losePopup.SetActive(true);
        DataAccountPlayer.PlayerResourceData.ChangeGold(30);
    }
}
