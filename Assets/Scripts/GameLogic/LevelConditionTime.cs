using UnityEngine;

namespace SpaceShooter
{
    public class LevelConditionTime : MonoBehaviour, ILevelCondition
    {
        [SerializeField] private int time;

        private int currentTime;

        private void Start()
        {
            currentTime = time;
        }

        private void Update()
        {
            currentTime -= (int)Time.deltaTime;
        }

        bool ILevelCondition.IsCompleted
        {
            get
            {
                if(currentTime <= 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }      
            }
        }
    }
}
