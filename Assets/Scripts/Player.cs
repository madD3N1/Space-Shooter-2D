using UnityEngine;

namespace SpaceShooter
{
    /// <summary>
    /// Класс, который описывает поведение Игрока.
    /// </summary>
    public class Player : MonoBehaviour
    {
        /// <summary>
        /// Кол-во жизней.
        /// </summary>
        [SerializeField] private int m_NumLives;

        /// <summary>
        /// Корабль, которым управляет Игрок.
        /// </summary>
        [SerializeField] private SpaceShip m_Ship;

        /// <summary>
        /// Префаб корабля.
        /// </summary>
        [SerializeField] private GameObject m_PlayerShipPrefab;


        [SerializeField] private CameraController m_CameraController;
        [SerializeField] private MovementController m_MovementController;

        private void Start()
        {
            m_Ship.EventOnDeath.AddListener(OnShipDeath);
        }

        private void OnShipDeath()
        {
            m_NumLives--;

            if (m_NumLives > 0)
            {
                Respawn();
            }
        }

        /// <summary>
        /// Метод, который респавнит Игрока.
        /// </summary>
        private void Respawn()
        {
            var newPlayerShip = Instantiate(m_PlayerShipPrefab);

            m_Ship = newPlayerShip.GetComponent<SpaceShip>();
            m_Ship.EventOnDeath.AddListener(OnShipDeath);

            m_CameraController.SetTarget(m_Ship.transform);
            m_MovementController.SetTargetShip(m_Ship);
        }
    }
}
