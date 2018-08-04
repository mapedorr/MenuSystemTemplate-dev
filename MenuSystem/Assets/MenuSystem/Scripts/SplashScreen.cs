using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

namespace MenuSystem
{
	public class SplashScreen : MonoBehaviour
	{
		// ═══════════════════════════════════════════════════════════ PRIVATES ════
		[SerializeField]
		ScreenTransition _screenTransitionPrefab;

		[SerializeField]
		float _toMainMenuDelay = 0.5f;

		// ════════════════════════════════════════════════════════════ METHODS ════
		/// <summary>
		/// Start is called on the frame when a script is enabled just before
		/// any of the Update methods is called the first time.
		/// </summary>
		void Start ()
		{
			StartCoroutine (ShowLogoRoutine ());
		}

		IEnumerator ShowLogoRoutine ()
		{
			// start the transition between scenes
			if (_screenTransitionPrefab != null)
			{
				ScreenTransition.CreateAndPlay (_screenTransitionPrefab);
			}

			// wait a couple of seconds before hiding this menu and openning the game
			// menu
			yield return new WaitForSeconds (_screenTransitionPrefab.GetTransitionTime () + _toMainMenuDelay);

			// load the main menu
			LevelLoader.LoadMainMenuLevel ();
		}
	}
}