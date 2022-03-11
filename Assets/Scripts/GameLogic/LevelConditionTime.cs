using UnityEngine;

namespace SpaceShooter
{
    public class LevelConditionTime : MonoBehaviour, ILevelCondition
    {
        [SerializeField] private int time;

        private void Start()
        {
            LevelController.Instance.ReferenceTime = time;
        }

        private void Update()
        {
            time -= (int)Time.deltaTime;
        }

        bool ILevelCondition.IsCompleted
        {
            get
            {
                return true;
            }
        }
    }
}
