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
			// TODO: pause the game
			// open the pause menu
			if (MenuManager.Instance != null)
			{
				MenuManager.Instance.OpenMenu (PauseMenu.Instance);
			}
		}
	}
}