using System;
using Settings;
using UnityEngine;

namespace Utils
{
    public class CellPositionManager : MonoBehaviour
    {
      

        private void Awake()
        {
            var position = transform.position;
            var offSetX = (9.0f - (float)GameSettings.column) / 2.0f;
            var offSetY = (9.0f - (float)GameSettings.row) / 2.0f;
            position = new Vector3(position.x+offSetX, position.y+offSetY, position.z);
            transform.position = position;
        }
        
    }
}
