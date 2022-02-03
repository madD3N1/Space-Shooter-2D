using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

namespace SpaceShooter
{
    public class CollectedItems : SingletonBase<CollectedItems>
    {
        [SerializeField] private List<GameObject> m_Items;
        [SerializeField] private Timer m_Timer;

        private int m_CurrentCount;
        private int m_HaveItems;

        [SerializeField] private bool m_Collected;

        public void Start()
        {
            m_CurrentCount = m_Items.Count;
        }

        public void Collect()
        {
            m_HaveItems++;

            if (m_HaveItems == m_CurrentCount)
            {
                m_Timer.IsActive = false;
                m_Collected = true;
            }
        }

        public int GetCurrentCount() => m_CurrentCount;
        public int GetHaveItems() => m_HaveItems;

    }
}
