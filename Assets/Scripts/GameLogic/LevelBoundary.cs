#if UNITY_EDITOR
using UnityEditor;
#endif

using UnityEngine;

namespace SpaceShooter
{
    /// <summary>
    /// �����, ������� ��������� ������� ������.
    /// </summary>
    public class LevelBoundary : SingletonBase<LevelBoundary>
    {
        /// <summary>
        /// ������ �������.
        /// </summary>
        [SerializeField] private float m_Radius;
        public float Radius => m_Radius;

        /// <summary>
        /// ������������ ��������� ��������� �������� �������.
        /// </summary>
        public enum Mode
        {
            Limit,
            Teleport
        }
        [SerializeField] private Mode m_LimitMode;
        public Mode LimitMode => m_LimitMode;

#if UNITY_EDITOR
        private void OnDrawGizmosSelected()
        {
            UnityEditor.Handles.color = Color.green;
            UnityEditor.Handles.DrawWireDisc(transform.position, transform.forward, m_Radius);
        }
#endif
    }
}
