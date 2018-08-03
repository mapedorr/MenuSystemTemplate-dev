using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MenuSystem
{
	public class LevelLoader : MonoBehaviour
	{
		// ═══════════════════════════════════════════════════════════ PRIVATES ════
		static int _mainMenuBuildIndex = 0;

		// ════════════════════════════════════════════════════════════ METHODS ════
		/// <summary>
		/// Restarts the current scene.
		/// </summary>
		public static void ReloadLevel ()
		{
			LoadLevel (SceneManager.GetActiveScene ().buildIndex);
		}

		/// <summary>
		/// Loads a scene by its build index. If the scene to load is MainMenu, then
		/// the main menu is opened.
		/// </summary>
		/// <param name="levelBuildIndex">The build index of the level.</param>
		public static void LoadLevel (int levelBuildIndex)
		{
			// check if the scene to load is part of the scenes in the build index.
			if (levelBuildIndex >= 0 && levelBuildIndex < SceneManager.sceneCountInBuildSettings)
			{
				if (levelBuildIndex == _mainMenuBuildIndex)
				{
					MainMenu.Open ();
				}

				SceneManager.LoadScene (levelBuildIndex);
			}
			else
			{
				Debug.LogWarning ("LevelLoader.LoadLevel(int) Error: invalid scene index");
			}
		}

		/// <summary>
		/// Loads the MainMenu scene and opens the Main menu.
		/// </summary>
		public static void LoadMainMenuLevel ()
		{
			LoadLevel (_mainMenuBuildIndex);
		}

		/// <summary>
		/// Loads the next level in the build index, or the main menu if there are no
		/// more levels in the game.
		/// </summary>
		public static void LoadNextLevel ()
		{
			// get the index of the next level
			//   [ note ] if the index of the next level to load IS EQUALS to the
			//            number of scenes in the build, the module (%) will assure the
			//            next level index to load will be the first scene in the build (0).
			int nextLevelIndex = (SceneManager.GetActiveScene ().buildIndex + 1) %
				SceneManager.sceneCountInBuildSettings;
			// TODO: use the following line when the first scene in the build isn't the
			//       main menu
			// nextSceneIndex = Mathf.Clamp (nextSceneIndex, _mainMenuIndex, nextSceneIndex);
			LoadLevel (nextLevelIndex);
		}
	}
}