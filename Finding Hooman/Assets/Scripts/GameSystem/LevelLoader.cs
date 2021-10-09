using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace GameSystem
{
    public class LevelLoader : MonoBehaviour
    {
        [SerializeField] private GameObject loadingScreen;
        [SerializeField] private Slider loadingBar;
        
        public void LoadLevel(int sceneIndex)
        {
            StartCoroutine(LoadAsynchronously(sceneIndex));
        }

        IEnumerator LoadAsynchronously(int sceneIndex)
        {
            AsyncOperation loadingOperation = SceneManager.LoadSceneAsync(sceneIndex);
            
            loadingScreen.SetActive(true);

            while (!loadingOperation.isDone)
            {
                float progress = Mathf.Clamp01(loadingOperation.progress / .9f);
                loadingBar.value = progress;
            
                yield return null;
            }
        }

        public void QuitApplication()
        {
            Application.Quit();
        }
    }
}
