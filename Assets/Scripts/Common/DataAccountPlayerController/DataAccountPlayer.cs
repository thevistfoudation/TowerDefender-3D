namespace DataAccount
{
    public static class DataAccountPlayer
    {
        private static PlayerSettings _playerSettings;
        private static PlayerTutorialData _playerTutorialData;
        private static WarriorData _warriorData;
        private static PlayerResourceData _playerResourceData;

        #region Getters

        public static PlayerResourceData PlayerResourceData
        {
            get
            {
                if (_playerResourceData != null)
                {
                    return _playerResourceData;
                }

                var playerResourceData = new PlayerResourceData();
                _playerResourceData = ES3.Load(DataAccountPlayerConstants.PlayerResourceData, playerResourceData);
                return _playerResourceData;
            }
        }

        public static WarriorData WarriorData
        {
            get
            {
                if (_warriorData != null)
                {
                    return _warriorData;
                }

                var warriorData = new WarriorData();
                _warriorData = ES3.Load(DataAccountPlayerConstants.WarriorData, warriorData);
                return _warriorData;
            }
        }


        public static PlayerSettings PlayerSettings
        {
            get
            {
                if (_playerSettings != null)
                {
                    return _playerSettings;
                }

                var playerSettings = new PlayerSettings();
                _playerSettings = ES3.Load(DataAccountPlayerConstants.PlayerSettings, playerSettings);
                return _playerSettings;
            }
        }


        public static PlayerTutorialData PlayerTutorialData
        {
            get
            {
                if (_playerTutorialData != null)
                    return _playerTutorialData;

                var playerTutorialData = new PlayerTutorialData();
                _playerTutorialData = ES3.Load(DataAccountPlayerConstants.PlayerTutorialData, playerTutorialData);
                return _playerTutorialData;
            }
        }

        #endregion

        #region Save

        public static void SaveWarriorData()
        {
            ES3.Save(DataAccountPlayerConstants.WarriorData, _warriorData);
        }

        public static void SavePlayerSettings()
        {
            ES3.Save(DataAccountPlayerConstants.PlayerSettings, _playerSettings);
        }

        public static void SavePlayerTutorialData()
        {
            ES3.Save(DataAccountPlayerConstants.PlayerTutorialData, _playerTutorialData);
        }

        public static void SavePlayerResourceData()
        {
            ES3.Save(DataAccountPlayerConstants.PlayerResourceData, _playerResourceData);
        }

        #endregion
    }
}