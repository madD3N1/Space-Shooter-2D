using UnityEngine;

namespace SpaceShooter
{
    /// <summary>
    /// Класс, отвечающий за отображение заднего фона.
    /// </summary>
    [RequireComponent(typeof(MeshRenderer))]
    public class BackgroundElement : MonoBehaviour
    {
        /// <summary>
        /// Сила параллакс эффекта.
        /// </summary>
        [Range(0.0f, 4.0f)]
        [SerializeField] private float m_ParallaxPower;

        /// <summary>
        /// Масштаб текстуры.
        /// </summary>
        [SerializeField] private float m_TextureScale;

        private Material m_QuadMaterial;
        private Vector2 m_InitialOffset;

        private void Start()
        {
            m_QuadMaterial = GetComponent<MeshRenderer>().material;
            m_InitialOffset = UnityEngine.Random.insideUnitSphere;

            m_QuadMaterial.mainTextureScale = Vector2.one * m_TextureScale;
        }

        private void Update()
        {
            Vector2 offset = m_InitialOffset;

            offset.x += transform.position.x / transform.localScale.x / m_ParallaxPower;
            offset.y += transform.position.y / transform.localScale.y / m_ParallaxPower;

            m_QuadMaterial.mainTextureOffset = offset;
        }
    }
}
