using UnityEngine;

namespace SpaceShooter
{
    public class Explosion : MonoBehaviour
    {
        [SerializeField] private GameObject m_Explosion;

        [SerializeField] private SpaceShip m_Ship;

        private void Awake()
        {
            m_Ship.EventOnDeath.AddListener(OnShipDeath);
        }

        private void OnShipDeath()
        {
            Instantiate(m_Explosion, m_Ship.transform.position, m_Explosion.transform.rotation);
        }
    }
}
