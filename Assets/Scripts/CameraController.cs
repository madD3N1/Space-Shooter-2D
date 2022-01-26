using UnityEngine;

namespace SpaceShooter
{
    /// <summary>
    /// Класс для управление игровой камерой.
    /// </summary>
    public class CameraController : MonoBehaviour
    {
        /// <summary>
        /// Камера, которой управляют.
        /// </summary>
        [SerializeField] private Camera m_Camera;

        /// <summary>
        /// Цель камеры.
        /// </summary>
        [SerializeField] private Transform m_Target;

        /// <summary>
        /// Скорость перемещения камеры.
        /// </summary>
        [SerializeField] private float m_InterpolationLinear;

        /// <summary>
        /// Скорость поворота камеры.
        /// </summary>
        [SerializeField] private float m_InterpolationAngular;

        /// <summary>
        /// Смещение камеры по Z оси (высота камеры).
        /// </summary>
        [SerializeField] private float m_CameraZOffset;

        /// <summary>
        /// Смещение слежения камеры.
        /// </summary>
        [SerializeField] private float m_ForwardOffset;

        private void FixedUpdate()
        {
            if (m_Target == null || m_Camera == null) return;

            Vector2 camPos = m_Camera.transform.position;
            Vector2 targetPos = m_Target.position + m_Target.transform.up * m_ForwardOffset;

            Vector2 newCamPos = Vector2.Lerp(camPos, targetPos, m_InterpolationLinear * Time.deltaTime);

            m_Camera.transform.position = new Vector3(newCamPos.x, newCamPos.y, m_CameraZOffset);

            if(m_InterpolationAngular > 0)
            {
                m_Camera.transform.rotation = Quaternion.Slerp(m_Camera.transform.rotation, 
                                                               m_Target.rotation, m_InterpolationAngular * Time.deltaTime);
            }
        }
    }
}
