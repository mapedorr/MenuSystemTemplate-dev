using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Utilities
{
	public class ScreenFader : MonoBehaviour
	{
		// ═════════════════════════════════════════════════════════ PROPERTIES ════
		[Tooltip ("The time it will take to fade off each UI element.")]
		[SerializeField]
		protected float _fadeOffDuration = 1f;
		public float FadeOffDuration { get { return _fadeOffDuration; } }

		[Tooltip ("The time it will take to fade on each UI element.")]
		[SerializeField]
		protected float _fadeOnDuration = 1f;
		public float FadeOnDuration { get { return _fadeOnDuration; } }

		// ═══════════════════════════════════════════════════════════ PRIVATES ════
		[Tooltip ("The alpha value to use when the UI elements are visible.")]
		[SerializeField]
		protected float _solidAlpha = 1f;

		[Tooltip ("The alpha value to use when the UI elements aren't visible.")]
		[SerializeField]
		protected float _clearAlpha = 0f;

		[Tooltip ("The array of UI elements to which the fading transitions will be applied.")]
		[SerializeField]
		MaskableGraphic[] _uiElementsToFade;

		// ════════════════════════════════════════════════════════════ METHODS ════
		/// <summary>
		/// Sets the alpha value for all the UI elements in the array.
		/// </summary>
		/// <param name="targetAlpha">The value to set on the alpha property.</param>
		void SetAlpha (float targetAlpha)
		{
			foreach (MaskableGraphic uiElement in _uiElementsToFade)
			{
				if (uiElement != null)
				{
					uiElement.canvasRenderer.SetAlpha (targetAlpha);
				}
			}
		}

		/// <summary>
		/// Sets the alpha value for all the UI elements in the array using a transition.
		/// </summary>
		/// <param name="targetAlpha">The final alpha value that will has the element.</param>
		/// <param name="fadeDuration">The time that the transition will last.</param>
		void Fade (float targetAlpha, float fadeDuration)
		{
			foreach (MaskableGraphic uiElement in _uiElementsToFade)
			{
				if (uiElement != null)
				{
					// change the alpha of the element
					// in the game pauses, continue changing the alpha (that's what the third
					// parameter does)
					uiElement.CrossFadeAlpha (targetAlpha, fadeDuration, true);
				}
			}
		}

		/// <summary>
		/// Fades off all the UI elements.
		/// </summary>
		public void FadeOff ()
		{
			// set the starting alpha value
			SetAlpha (_solidAlpha);

			// fade the alpha value
			Fade (_clearAlpha, _fadeOffDuration);
		}

		/// <summary>
		/// Fades on all the UI elements.
		/// </summary>
		public void FadeOn ()
		{
			// set the starting alpha value
			SetAlpha (_clearAlpha);

			// fade the alpha value
			Fade (_solidAlpha, _fadeOffDuration);
		}
	}
}