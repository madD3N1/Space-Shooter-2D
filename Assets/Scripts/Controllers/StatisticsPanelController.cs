using UnityEngine;
using TMPro;

namespace SpaceShooter
{
    public class StatisticsPanelController : MonoBehaviour
    {
        [SerializeField] private GlobalPlayerStatistics m_Statistics;

        [SerializeField] private TextMeshProUGUI m_TotalScore;

        [SerializeField] private TextMeshProUGUI m_TotalKills;

        [SerializeField] private TextMeshProUGUI m_TotalGameTime;

        private void Start()
        {
            m_Statistics = GlobalPlayerStatistics.Instance;
            UpdateStatistics();
        }

        public void UpdateStatistics()
        {
            m_TotalScore.text = $"Total Score: {m_Statistics.Score}";
            m_TotalKills.text = $"Total Kills: {m_Statistics.Kills}";
            m_TotalGameTime.text = $"Total Game Time: {m_Statistics.Time}";
        }

        public void OnButtonBackToMenu()
        {
            gameObject.SetActive(false);
            MainMenuController.Instance?.gameObject.SetActive(true);
        }
    }
}
