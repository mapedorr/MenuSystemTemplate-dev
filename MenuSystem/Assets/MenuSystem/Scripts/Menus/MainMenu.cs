using System.Collections;
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
			// TODO: start the game
		}

		public void OpenSettings ()
		{
			// open the settings menu
			if (MenuManager.Instance != null)
			{
				MenuManager.Instance.OpenMenu (SettingsMenu.Instance);
			}
		}

		public void OpenCredits ()
		{
			// open the credits menu
			if (MenuManager.Instance != null)
			{
				MenuManager.Instance.OpenMenu (CreditsMenu.Instance);
			}
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