using UnityEngine;
using System.Collections;

namespace SpaceShooter
{
    /// <summary>
    /// �����, ������� ��������� ��������� ������.
    /// </summary>
    public class Player : MonoBehaviour
    {
        /// <summary>
        /// ���-�� ������.
        /// </summary>
        [SerializeField] private int m_NumLives;

        /// <summary>
        /// �������, ������� ��������� �����.
        /// </summary>
        [SerializeField] private SpaceShip m_Ship;

        /// <summary>
        /// ������ �������.
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
            StartCoroutine(Death());
        }

        IEnumerator Death()
        {
            yield return new WaitForSecondsRealtime(2.0f);

            m_NumLives--;

            if (m_NumLives > 0)
            {
                Respawn();
            }
        }

        /// <summary>
        /// �����, ������� ��������� ������.
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
