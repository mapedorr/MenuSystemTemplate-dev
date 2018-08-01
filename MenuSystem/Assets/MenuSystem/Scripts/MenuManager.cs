using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace MenuSystem
{
	public class MenuManager : MonoBehaviour
	{
		// ═════════════════════════════════════════════════════════ PROPERTIES ════
		public static MenuManager Instance { get; private set; }

		// ═══════════════════════════════════════════════════════════ PRIVATES ════
		[SerializeField]
		MainMenu _mainMenuPrefab;

		[SerializeField]
		SettingsMenu _settingsMenuPrefab;

		[SerializeField]
		CreditsMenu _creditsMenuPrefab;

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

				// initialize all the menus linked to the manager
				// TODO: this should be optional. Developers should be able to choose if
				// they want the menus to be initialized all at once or only when they are
				// opened.
				InitializeMenus ();

				// make the MenuManager to persist between scenes
				DontDestroyOnLoad (gameObject);
			}
		}

		/// <summary>
		/// Create instances of all of the linked menus.
		/// </summary>
		void InitializeMenus ()
		{
			if (_menusContainer == null)
			{
				// if there isn't a container for the menus defined, create one
				GameObject emptyGameObject = new GameObject ("Menus");
				_menusContainer = emptyGameObject.transform;
				DontDestroyOnLoad (_menusContainer.gameObject);
			}

			// create the array of linked menus
			Menu[] linkedMenus = {
				_mainMenuPrefab,
				_settingsMenuPrefab,
				_creditsMenuPrefab
			};

			// instantiate each of the linked menus
			foreach (Menu menuPrefab in linkedMenus)
			{
				if (menuPrefab != null)
				{
					Menu menuInstance = Instantiate (menuPrefab, _menusContainer);

					// by default, open the main menu and made the others inactive
					if (menuPrefab == _mainMenuPrefab)
					{
						OpenMenu (menuInstance);
					}
					else
					{
						menuInstance.gameObject.SetActive (false);
					}
				}
			}
		}

		/* public void CreateMenuInstance<T> () where T : Menu
		{
			var menuPrefab = GetPrefab<T> ();
			Instantiate (menuPrefab, _menusContainer);
		}

		T GetPrefab<T> () where T : Menu
		{
			// store a reference to the MenuManager type
			System.Type myType = this.GetType ();

			// set the enums that will be used to search through the reflection
			BindingFlags myFlags = BindingFlags.Instance |
				BindingFlags.NonPublic | BindingFlags.DeclaredOnly;

			// get the fields that match the conditions we're looking for
			FieldInfo[] fields = myType.GetFields (myFlags);

			foreach (var item in fields)
			{
				T menuPrefab = item.GetValue (this) as T;
				if (menuPrefab != null)
				{
					return menuPrefab;
				}
			}

			throw new MissingReferenceException ("Prefab not found for type " + typeof (T));
		} */

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
				Debug.LogWarningFormat ("MenuManager.OpenMenu ERROR: no menu specified");
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