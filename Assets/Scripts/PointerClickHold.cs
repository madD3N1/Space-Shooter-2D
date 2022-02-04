using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace SpaceShooter
{
    public class PointerClickHold : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
    {
        private bool m_Hold;
        public bool IsHold => m_Hold;

        void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
        {
            m_Hold = true;
        }

        void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
        {
            m_Hold = false;        
        }
    }
}
