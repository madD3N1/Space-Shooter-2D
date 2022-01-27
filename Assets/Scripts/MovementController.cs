using UnityEngine;

namespace SpaceShooter
{
    /// <summary>
    /// Класс для управления перемещением.
    /// </summary>
    public class MovementController : MonoBehaviour
    {
        /// <summary>
        /// Перечисление вариантов управления.
        /// </summary>
        public enum ControlMode
        {
            Keyboard,
            Mobile
        }

        /// <summary>
        /// Корабль, которым управляет Игрок.
        /// </summary>
        [SerializeField] private SpaceShip m_TargetShip;
        public void SetTargetShip(SpaceShip ship) => m_TargetShip = ship;

        [SerializeField] private VirtualJoystick m_MobileJoystick;

        [SerializeField] private ControlMode m_ControlMode;

        private void Start()
        {
            if(m_ControlMode == ControlMode.Mobile)
                m_MobileJoystick.gameObject.SetActive(true);
            else
                m_MobileJoystick.gameObject.SetActive(false);
        }

        private void Update()
        {
            if (m_TargetShip == null) return;

            if (m_ControlMode == ControlMode.Keyboard)
                ControlKeyboard();
            if (m_ControlMode == ControlMode.Mobile)
                ControlMobile();
        }

        /// <summary>
        /// Метод для управления с помощью телефона.
        /// </summary>
        private void ControlMobile()
        {
            var dir = m_MobileJoystick.Value;

            m_TargetShip.ThrustControl = dir.y;
            m_TargetShip.TorqueControl = -dir.x;
        }

        /// <summary>
        /// Метод для управления с помощью клавиатуры.
        /// </summary>
        private void ControlKeyboard()
        {
            float thrust = 0;
            float torque = 0;

            if (Input.GetKey(KeyCode.UpArrow))
                thrust = 1.0f;

            if (Input.GetKey(KeyCode.DownArrow))
                thrust = -1.0f;

            if (Input.GetKey(KeyCode.LeftArrow))
                torque = 1.0f;

            if (Input.GetKey(KeyCode.RightArrow))
                torque = -1.0f;

            m_TargetShip.ThrustControl = thrust;
            m_TargetShip.TorqueControl = torque;
        }
    }
}
