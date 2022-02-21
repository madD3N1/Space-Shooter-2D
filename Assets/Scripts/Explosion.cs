using UnityEngine;

namespace SpaceShooter
{
    public class Explosion : MonoBehaviour
    {
        [SerializeField] private GameObject m_Explosion;

        [SerializeField] private Destructible m_Target;

        private void Awake()
        {
            m_Target.EventOnDeath.AddListener(OnShipDeath);
        }

        private void OnShipDeath()
        {
            Instantiate(m_Explosion, m_Target.transform.position, m_Explosion.transform.rotation);
        }
    }
}
