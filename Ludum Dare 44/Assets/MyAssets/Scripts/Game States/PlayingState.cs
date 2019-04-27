using UnityEngine;

namespace AdrianKovatana
{
    public class PlayingState : StateMachineBehaviour
    {
#pragma warning disable
        [SerializeField]
        private FloatVariable _currentTime; //86400 seconds is 1 day

        [SerializeField]
        private GameEvent _gameOver;
#pragma warning restore

        private Animator _animator;

        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            _animator = animator;
            _gameOver.RegisterListener(ChangeState);
        }

        override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            _currentTime.value += Time.deltaTime;
        }

        override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            _gameOver.UnregisterListener(ChangeState);
        }

        private void ChangeState()
        {
            _animator.SetTrigger("Change State");
        }
    }
}
