using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MenuSystem
{
	public class PauseMenu : Menu<PauseMenu>
	{
		// ════════════════════════════════════════════════════════════ METHODS ════
		/// <summary>
		/// Restarts the level using the LevelManager.
		/// </summary>
		public void RestartLevel ()
		{
			// TODO: ask the level manager to restart the level
		}

		/// <summary>
		/// Opens the main menu by loading the MainMenu scene.
		/// </summary>
		public void OpenMainMenu ()
		{
			// TODO: open the main menu
		}
	}
}