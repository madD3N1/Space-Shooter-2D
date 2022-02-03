using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace SpaceShooter
{
    public class TimerUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI m_Text;

        private Timer m_Timer;
        private int m_Minutes;
        private int m_Seconds;

        private void Start()
        {
            m_Timer = GameObject.Find("Timer").GetComponent<Timer>(); 
        }

        private void Update()
        {
            m_Minutes = (int)m_Timer.GetCurrentTime() / 60;
            m_Seconds = (int)(m_Timer.GetCurrentTime() % 60);

            if (m_Minutes < 10)
            {
                m_Text.text = $"0{m_Minutes}:{m_Seconds}";

                if (m_Seconds < 10)
                {
                    m_Text.text = $"0{m_Minutes}:0{m_Seconds}";
                }
            }

            if(m_Seconds < 10)
            {
                m_Text.text = $"{m_Minutes}:0{m_Seconds}";

                if (m_Minutes < 10)
                { 
                    m_Text.text = $"0{m_Minutes}:0{m_Seconds}";
                }            
            }
            
        }
    }
}
