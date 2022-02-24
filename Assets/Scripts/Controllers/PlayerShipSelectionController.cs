using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace SpaceShooter
{
    public class PlayerShipSelectionController : MonoBehaviour
    {
        [SerializeField] private SpaceShip m_Prefab;

        [SerializeField] private TextMeshProUGUI m_Shipname;

        [SerializeField] private TextMeshProUGUI m_Hitpoints;

        [SerializeField] private TextMeshProUGUI m_Speed;

        [SerializeField] private TextMeshProUGUI m_Agility;

        [SerializeField] private Image m_Preview;

        private void Start()
        {
            if(m_Prefab != null)
            {
                m_Shipname.text = m_Prefab.Nickname;
                m_Hitpoints.text = $"HP: {m_Prefab.HitPoints}";
                m_Speed.text = $"Speed: {m_Prefab.MaxLinearVelocity}";
                m_Agility.text = $"Agility: {m_Prefab.MaxAngularVelocity}";
                m_Preview.sprite = m_Prefab.PreviewImage;
            }
        }

        public void OnSelectShip()
        {
            LevelSequenceController.PlayerShip = m_Prefab;

            MainMenuController.Instance.gameObject.SetActive(true);
        }
    }
}
