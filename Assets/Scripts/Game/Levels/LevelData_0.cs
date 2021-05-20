using Game.Core.Board;
using Game.Core.Item;
using Game.Core.Level;
using Settings;
using UnityEngine;

namespace Game.Levels
{
    public class LevelData_0 : LevelData 
    {        
        public override ItemType GetNextFillItemType()
        {
            return GetRandomCubeItemType();
        }

        public override void Initialize()
        {
            
            GridData = new ItemType[GameSettings.column, GameSettings.row];

            for (var y = 0; y < GameSettings.row; y++)
            {
                for (var x = 0; x < GameSettings.column; x++)
                {
                    GridData[x, y] = GetRandomCubeItemType();
                }
            } 
            
        }
    }
}
