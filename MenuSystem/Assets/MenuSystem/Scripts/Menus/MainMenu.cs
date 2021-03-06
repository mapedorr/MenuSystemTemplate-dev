﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MenuSystem
{
	public class MainMenu : Menu<MainMenu>
	{
		// ═══════════════════════════════════════════════════════════ PRIVATES ════
		[SerializeField]
		Button _quitButton;

		// ════════════════════════════════════════════════════════════ METHODS ════
		/// <summary>
		/// Awake is called when the script instance is being loaded.
		/// </summary>
		public override void Awake ()
		{
			base.Awake ();

			// check if the game is running on the web
			if (Application.platform == RuntimePlatform.WebGLPlayer)
			{
				// remove the quit button
				if (_quitButton != null)
				{
					_quitButton.gameObject.SetActive (false);
				}
			}
		}

		public void PlayGame ()
		{
			// load the next level in the build
			LevelLoader.LoadNextLevel ();

			// open the game menu
			GameMenu.Open ();
		}

		public void OpenSettings ()
		{
			// open the settings menu
			SettingsMenu.Open ();
		}

		public void OpenCredits ()
		{
			// open the credits menu
			CreditsMenu.Open ();
		}

		/// <summary>
		/// Quit the game.
		/// </summary>
		public override void OnBackPressed ()
		{
			Application.Quit ();
		}
	}
}