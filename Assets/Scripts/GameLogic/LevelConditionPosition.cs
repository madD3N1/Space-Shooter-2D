using UnityEngine;

namespace SpaceShooter
{
    public class LevelConditionPosition : MonoBehaviour, ILevelCondition
    {
        [SerializeField] private Finish position;

        private bool isAchieved;

        bool ILevelCondition.IsCompleted
        {
            get
            {
                isAchieved = position.IsAchieved;

                return isAchieved;
            }
        }
    }
}
