using UnityEngine;

namespace SpaceShooter
{
    public class Timer : SingletonBase<Timer>
    {
        [SerializeField] private float m_StartTime;

        public bool IsActive;

        private float m_CurrentTime;

        private void Start()
        {
            m_CurrentTime = m_StartTime;
        }

        private void Update()
        {
            if (IsActive)
            {
                m_CurrentTime -= Time.deltaTime;

                if (m_CurrentTime <= 0) IsActive = false; 
            }
        }

        public void ResetCurrentTime() => m_CurrentTime = m_StartTime;

        public float GetCurrentTime() => m_CurrentTime;

        public void AddTime(float time) => m_CurrentTime += time;
    }
}
