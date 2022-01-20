using UnityEngine;

namespace SpaceShooter
{
    /// <summary>
    /// Уничтожаемый объект на сцене. То, что может иметь хит-поинты.
    /// </summary>
    public class Destructible : Entity
    {
        #region Properties
        /// <summary>
        /// Объект игнорирует повреждения.
        /// </summary>
        [SerializeField] private bool m_Indestructible;
        public bool IsIndestructible => m_Indestructible;

        /// <summary>
        /// Стартовое кол-во хит-поинтов.
        /// </summary>
        [SerializeField] private int m_HitPoints;

        /// <summary>
        /// Текущие хит-поинты.
        /// </summary>
        private int m_CurrentHitPoints;
        public int HitPoints => m_CurrentHitPoints;
        #endregion

        #region Unity Events

        protected virtual void Start()
        {
            m_CurrentHitPoints = m_HitPoints;
        }

        #endregion

        #region Public API

        /// <summary>
        /// Применение урона к объекту.
        /// </summary>
        /// <param name="damage"> Урон, наносимый объекту. </param>
        public void ApplyDamage(int damage)
        {
            if (m_Indestructible) return;

            m_CurrentHitPoints -= damage;

            if (m_CurrentHitPoints <= 0)
            {
                OnDeath();
            }
        }

        #endregion

        /// <summary>
        /// Переопределяемое событие уничтожения объекта, когда хит-поинты ниже нуля.
        /// </summary>
        protected virtual void OnDeath()
        {
            Destroy(gameObject);
        }
    }
}
