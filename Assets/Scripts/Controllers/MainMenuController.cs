#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

namespace SpaceShooter
{
    public class MainMenuController : MonoBehaviour
    {
        [SerializeField] private GameObject m_EpisodeSelection;

        public void OnButtonStartNew()
        {
            m_EpisodeSelection.gameObject.SetActive(true);

            gameObject.SetActive(false);
        }

        public void OnButtonExit()
        {
            #if UNITY_EDITOR
                EditorApplication.ExitPlaymode();
            #else
                Application.Quit();
            #endif
        }
    }
}
