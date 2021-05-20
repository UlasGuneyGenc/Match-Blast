using Game.Levels;

namespace Game.Core.Level
{
    public static class LevelDataFactory
    {
        public static LevelData CreateLevelData(int no)
        {
            LevelData levelData;
            switch (no)
            {
                
                case 0:
                    levelData = new LevelData_0();
                    break;
                default:
                    levelData = new LevelData_0();
                    break;
            }
            levelData.Initialize();
            return levelData;
        }
    }
}