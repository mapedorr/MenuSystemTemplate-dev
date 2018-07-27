using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utilities
{
	public class ScreenTransition : ScreenFader
	{
		// ═══════════════════════════════════════════════════════════ PRIVATES ════
		[SerializeField]
		float _transitionTime;

		[SerializeField]
		float _delay;
		public float Delay { get { return _delay; } }
	}
}