using UnityEngine;

namespace SpaceShooter
{
    /// <summary>
    /// Класс, реализующий получение урона при столкновении.
    /// </summary>
    public class CollisionDamageApplicator : MonoBehaviour
    {
        /// <summary>
        /// Тег, который игнорирует получение урона.
        /// </summary>
        public static string IgnoreTag = "WorldBoundary";

        /// <summary>
        /// Модификатор получения урона от скорости.
        /// </summary>
        [SerializeField] private float m_VelocityDamageModifier;

        /// <summary>
        /// Урон при столкновении.
        /// </summary>
        [SerializeField] private float m_DamageConstant;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.transform.tag == IgnoreTag)
                return;

            var destructible = transform.root.GetComponent<Destructible>();

            if(destructible != null)
            {
                destructible.ApplyDamage((int)m_DamageConstant + 
                                        (int)(m_VelocityDamageModifier * collision.relativeVelocity.magnitude));
            }
        }
    }
}
