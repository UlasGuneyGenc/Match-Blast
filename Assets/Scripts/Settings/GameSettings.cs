using UnityEngine;

namespace Settings
{
	public class GameSettings : MonoBehaviour
	{
		public static int row =4;
		public static int column=6;
		public static int cubeChoice=4;
		public static int firstHint = 3;
		public static int secondHint=4;
		public static int thirdHint=5;

		void Awake ()
		{
			Application.targetFrameRate = 60;
		}
	}
}

