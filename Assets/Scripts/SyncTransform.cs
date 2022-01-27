using UnityEngine;

namespace SpaceShooter
{
    /// <summary>
    /// Класс, который реализует движение (слежение) за целью.
    /// </summary>
    public class SyncTransform : MonoBehaviour
    {
        /// <summary>
        /// Цель для движения (слежения).
        /// </summary>
        [SerializeField] private Transform m_Target;

        private void FixedUpdate()
        {
            transform.position = new Vector3(m_Target.position.x, m_Target.position.y, transform.position.z);
        }
    }
}
