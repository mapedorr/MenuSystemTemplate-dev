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
			UnpauseGame ();

			// ask the level manager to restart the level
			LevelLoader.ReloadLevel ();
		}

		/// <summary>
		/// Opens the Main menu using the LevelManager.
		/// </summary>
		public void OpenMainMenu ()
		{
			UnpauseGame ();
			// open the main menu
			LevelLoader.LoadMainMenuLevel ();
		}

		public void ResumeGame ()
		{
			UnpauseGame ();
		}

		void UnpauseGame ()
		{
			// unpause the game
			Time.timeScale = 1;

			// close the menu
			base.OnBackPressed ();
		}
	}
}