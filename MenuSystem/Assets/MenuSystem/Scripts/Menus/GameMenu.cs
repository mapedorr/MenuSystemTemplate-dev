using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MenuSystem
{

	public class GameMenu : Menu<GameMenu>
	{
		// ════════════════════════════════════════════════════════════ METHODS ════
		/// <summary>
		/// Pauses the game and opens the Pause menu.
		/// </summary>
		public void PauseGame ()
		{
			// pause the game (stop gameplay)
			// Time.timeScale = 0;

			// open the pause menu
			PauseMenu.Open ();
		}
	}
}