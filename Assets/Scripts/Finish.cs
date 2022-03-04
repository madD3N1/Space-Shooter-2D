using UnityEngine;

namespace SpaceShooter
{
    public class Finish : MonoBehaviour
    {
        [SerializeField] private bool m_IsAchieved;
        public bool IsAchieved => m_IsAchieved;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.gameObject.tag == "Player")
            {
                m_IsAchieved = true;
            }   
        }
    }
}
