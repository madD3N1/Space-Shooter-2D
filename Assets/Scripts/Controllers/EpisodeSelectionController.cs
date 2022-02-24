using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace SpaceShooter
{
    public class EpisodeSelectionController : MonoBehaviour
    {
        [SerializeField] private Episode m_Episode;

        [SerializeField] private TextMeshProUGUI m_EpisodeNickname;

        [SerializeField] private Image m_PreviewImage;

        private void Start()
        {
            if (m_EpisodeNickname != null)
                m_EpisodeNickname.text = m_Episode.EpisodeName;

            if (m_PreviewImage != null)
                m_PreviewImage.sprite = m_Episode.PreviewImage;
        }

        public void OnStartEpisodeButtonClicked()
        {
            LevelSequenceController.Instance.StartEpisode(m_Episode);
        }
    }
}
