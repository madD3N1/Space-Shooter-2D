#if UNITY_EDITOR
using UnityEditor;
#endif

using UnityEngine;

namespace SpaceShooter
{
    /// <summary>
    /// Класс, который реализует гравитационную яму.
    /// </summary>
    [RequireComponent(typeof(CircleCollider2D))]
    public class GravityWell : MonoBehaviour
    {
        /// <summary>
        /// Сила притяжения.
        /// </summary>
        [SerializeField] private float m_Force;

        /// <summary>
        /// Радиус ямы.
        /// </summary>
        [SerializeField] private float m_Radius;

        private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.attachedRigidbody == null) return;

            Vector2 dir = transform.position - collision.transform.position;

            float dist = dir.magnitude;

            if(dist < m_Radius)
            {
                Vector2 force = dir.normalized * m_Force * (dist / m_Radius);
                collision.attachedRigidbody.AddForce(force, ForceMode2D.Force);
            }
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            GetComponent<CircleCollider2D>().radius = m_Radius;
        }
#endif
    }
}
