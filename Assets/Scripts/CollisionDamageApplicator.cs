using UnityEngine;

namespace SpaceShooter
{
    /// <summary>
    /// �����, ����������� ��������� ����� ��� ������������.
    /// </summary>
    public class CollisionDamageApplicator : MonoBehaviour
    {
        /// <summary>
        /// ���, ������� ���������� ��������� �����.
        /// </summary>
        public static string IgnoreTag = "WorldBoundary";

        /// <summary>
        /// ����������� ��������� ����� �� ��������.
        /// </summary>
        [SerializeField] private float m_VelocityDamageModifier;

        /// <summary>
        /// ���� ��� ������������.
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
