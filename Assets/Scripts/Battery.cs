using UnityEngine;

namespace SpaceShooter
{
    public class Battery : MonoBehaviour
    { 
        [SerializeField] private float m_Charge;

        private Timer m_Timer;
        private CollectedItems m_Collection;

        private void Start()
        {
            m_Timer = GameObject.Find("Timer").GetComponent<Timer>();
            m_Collection = GameObject.Find("Player").GetComponent<CollectedItems>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.tag == "Player")
            {
                m_Collection.Collect();
                m_Timer.AddTime(m_Charge);
                Destroy(gameObject);
            }
        }

    }
}
