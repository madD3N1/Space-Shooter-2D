using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace SpaceShooter
{
    public class CollectedItemsUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI m_Text;
        [SerializeField] private CollectedItems m_Collection;

        private void Update()
        {
            m_Text.text = $"{m_Collection.GetHaveItems()}/{m_Collection.GetCurrentCount()}";
        }
    }
}
