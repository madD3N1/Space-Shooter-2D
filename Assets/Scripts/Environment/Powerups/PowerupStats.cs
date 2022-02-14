using UnityEngine;

namespace SpaceShooter
{
    public class PowerupStats : Powerup
    {
        public enum EffectType
        {
            AddAmmo,
            AddEnergy,
            AddSpeed
        }

        [SerializeField] private EffectType m_EffectType;

        [SerializeField] private float m_Value;

        [SerializeField] private float m_TimeDuration;

        protected override void OnPickedUp(SpaceShip ship)
        {
            if (m_EffectType == EffectType.AddEnergy)
                ship.AddEnergy((int)m_Value);

            if (m_EffectType == EffectType.AddAmmo)
                ship.AddAmmo((int)m_Value);

            if (m_EffectType == EffectType.AddSpeed)
                ship.AddSpeed(m_Value, m_TimeDuration);
        }
    }
}
