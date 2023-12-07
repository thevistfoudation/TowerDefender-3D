using Base.Core;

namespace DataAccount
{
    public class PlayerResourceData 
    {
        public int levelPlayer;
        public bool isFristTime;
        public int gold;
        public int gem;

        public void ChangeStatusFirstTime()
        {
            isFristTime = true;
            DataAccountPlayer.SavePlayerResourceData();
        }

        public void ChangeGold(int value)
        {
            gold += value;        
            DataAccountPlayer.SavePlayerResourceData();
            GameManager.Instance.PostEvent(EventID.ChangeMoneyValue);
        }

        public void ChangeGem(int value)
        {
            gem += value;
            DataAccountPlayer.SavePlayerResourceData();
            GameManager.Instance.PostEvent(EventID.ChangeGemValue);
        }

        public void LevelUp()
        {
            levelPlayer += 1;
            DataAccountPlayer.SavePlayerResourceData();
        }
    }
}