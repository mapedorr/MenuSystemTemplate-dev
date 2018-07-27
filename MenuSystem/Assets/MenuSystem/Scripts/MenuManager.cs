using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MenuSystem
{
	public class MenuManager : MonoBehaviour
	{
		// ═════════════════════════════════════════════════════════ PROPERTIES ════
		public static MenuManager Instance { get; private set; }

		// ═══════════════════════════════════════════════════════════ PRIVATES ════
		// stack of opened menus
		Stack<Menu> _menusStack = new Stack<Menu> ();
		// container for all the menus (to keep things organized in the hierarchy)
		Transform _menusContainer;

		// ════════════════════════════════════════════════════════════ METHODS ════
		/// <summary>
		/// Awake is called when the script instance is being loaded.
		/// </summary>
		void Awake ()
		{
			if (Instance != null)
			{
				Destroy (gameObject);
			}
			else
			{
				Instance = this;

				// make the MenuManager to persist between scenes
				DontDestroyOnLoad (gameObject);
			}
		}

		/// <summary>
		/// This function is called when the MonoBehaviour will be destroyed.
		/// </summary>
		void OnDestroy ()
		{
			Instance = null;
		}

		/// <summary>
		/// Opens the menu received as parameter by putting it on top of the menus
		/// stack and making inactive all the menus beneath it.
		/// </summary>
		/// <param name="menuInstance">The instance of the menu to open.</param>
		public void OpenMenu (Menu menuInstance)
		{
			// prevent opening null menus
			if (menuInstance == null)
			{
				Debug.LogWarning ("MenuManager.OpenMenu ERROR: no menu specified");
				return;
			}

			// set as inactive all the menus that are currently in the stack
			if (_menusStack.Count > 0)
			{
				foreach (Menu menu in _menusStack)
				{
					menu.gameObject.SetActive (false);
				}
			}

			// show the menu and add it to the stack
			menuInstance.gameObject.SetActive (true);
			_menusStack.Push (menuInstance);
		}

		/// <summary>
		/// Closes the menu at top of the stack.
		/// </summary>
		public void CloseMenu ()
		{
			if (_menusStack.Count == 0)
			{
				Debug.LogWarning ("MenuManager.CloseMenu ERROR: there's no menu to close");
				return;
			}

			// TODO: check if the menu should be closed or just deactivated

			// get the menu on top of the stack and inactivate it
			_menusStack.Pop ().gameObject.SetActive (false);

			if (_menusStack.Count > 0)
			{
				// open (activate) the menu that's now on top of the stack
				_menusStack.Peek ().gameObject.SetActive (true);
			}
		}
	}
}