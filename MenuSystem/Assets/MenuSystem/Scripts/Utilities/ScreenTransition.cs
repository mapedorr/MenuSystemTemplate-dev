using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utilities
{
	public class ScreenTransition : ScreenFader
	{
		// ═══════════════════════════════════════════════════════════ PRIVATES ════
		[Tooltip ("The time the screen will keep visible before fading off.")]
		[SerializeField]
		float _transitionTime;

		[Tooltip ("The time to wait before starting the transition.")]
		[SerializeField]
		float _delay;
		public float Delay { get { return _delay; } }

		// ════════════════════════════════════════════════════════════ METHODS ════
		/// <summary>
		/// Awake is called when the script instance is being loaded.
		/// </summary>
		void Awake ()
		{
			// assign a value to _transitionTime non greater than 10 seconds and smaller
			// than the duration of the fadings plus the delay
			_transitionTime = GetTransitionTime ();
		}

		/// <summary>
		/// Starts the routine that will fade on, wait and fade off the screen.
		/// </summary>
		public void PlayTransition ()
		{
			StartCoroutine (PlayTransitionRoutine ());
		}

		/// <summary>
		/// Routine that triggers the fade on and fade off effects on the screen, waiting
		/// an amount of time beteween them.
		/// </summary>
		/// <returns>An IEnumerator to use as coroutine.</returns>
		IEnumerator PlayTransitionRoutine ()
		{
			SetAlpha (_clearAlpha);
			yield return new WaitForSeconds (_delay);

			// fade on the screen and keep it visible for a moment
			FadeOn ();
			float displayTime = _transitionTime - (FadeOffDuration + _delay);
			yield return new WaitForSeconds (displayTime);

			// fade off the screen and destroy the GameObject when the effect finishes
			FadeOff ();
			Destroy (gameObject, FadeOffDuration);
		}

		/// <summary>
		/// Allows any GameObject on the scene to create and play a screen transition.
		/// </summary>
		/// <param name="screenTransitionPrefab">A prefab with a ScreenTransition component attached to it.</param>
		public static void CreateAndPlay (ScreenTransition screenTransitionPrefab)
		{
			if (screenTransitionPrefab != null)
			{
				ScreenTransition st = Instantiate (screenTransitionPrefab, Vector3.zero, Quaternion.identity);
				st.PlayTransition ();
			}
		}

		public float GetTransitionTime ()
		{
			return Mathf.Clamp (_transitionTime, FadeOffDuration + FadeOnDuration + _delay, 10f);
		}
	}
}