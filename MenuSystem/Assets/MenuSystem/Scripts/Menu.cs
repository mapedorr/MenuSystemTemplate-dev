using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MenuSystem
{
	public abstract class Menu<T> : Menu where T : Menu<T>
	{
		// ═════════════════════════════════════════════════════════ PROPERTIES ════
		static Menu<T> _instance;
		public static Menu<T> Instance { get { return _instance; } }

		// ════════════════════════════════════════════════════════════ METHODS ════
		/// <summary>
		/// Awake is called when the script instance is being loaded.
		/// </summary>
		public virtual void Awake ()
		{
			if (_instance != null)
			{
				Destroy (gameObject);
			}
			else
			{
				_instance = (T) this;
			}
		}

		/// <summary>
		/// This function is called when the MonoBehaviour will be destroyed.
		/// </summary>
		protected virtual void OnDestroy ()
		{
			_instance = null;
		}

		/// <summary>
		/// Opens the menu itself.
		/// </summary>
		public static void Open ()
		{
			// TODO: add a block of code for instancing the menu if there's no
			// an instance of it

			// open the menu
			if (MenuManager.Instance != null && Instance != null)
			{
				MenuManager.Instance.OpenMenu (Instance);
			}
		}

		/// <summary>
		/// Closes the menu itself.
		/// </summary>
		public static void Close ()
		{
			if (Instance == null)
			{
				Debug.LogErrorFormat ("Trying to close menu {0} but Instance is null",
					typeof (T));
				return;
			}

			if (MenuManager.Instance != null)
			{
				MenuManager.Instance.CloseMenu ();
			}
		}

		/// <summary>
		/// Closes the menu itself.
		/// </summary>
		public override void OnBackPressed ()
		{
			Close ();
		}
	}

	[RequireComponent (typeof (Canvas))]
	public abstract class Menu : MonoBehaviour
	{
		// ════════════════════════════════════════════════════════════ METHODS ════
		public abstract void OnBackPressed ();
	}
}