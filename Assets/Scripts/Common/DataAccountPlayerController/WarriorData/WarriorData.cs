using Base.Core;

namespace DataAccount
{
    public class WarriorData
    {
        public int levelWarrior = 1;

        public void SetWarriorLevel(int level)
        {
            levelWarrior = level;
            DataAccountPlayer.SaveWarriorData();
        }

        public void UpgradeWarriorLevel()
        {
            levelWarrior += 1;
            DataAccountPlayer.SaveWarriorData();
        }
    }
}