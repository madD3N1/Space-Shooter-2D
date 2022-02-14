using UnityEngine;

namespace SpaceShooter
{
    public class Asteroid : MonoBehaviour
    {
        [SerializeField] private GameObject m_PrefabSmallAsteroid;

        [SerializeField] private int m_Number;

        private void Start()
        {
            gameObject.GetComponent<Destructible>().EventOnDeath.AddListener(OnDeath);
        }

        private void OnDeath()
        {
            for(int i = 0; i < m_Number; i++)
            {
                var asteroid = Instantiate(m_PrefabSmallAsteroid);
                asteroid.transform.position = transform.position;

                var rb = asteroid.GetComponent<Rigidbody2D>();

                if(rb != null)
                {
                    rb.velocity = (Vector2)Random.insideUnitSphere * 3;
                }                
            }
        }
    }
}
