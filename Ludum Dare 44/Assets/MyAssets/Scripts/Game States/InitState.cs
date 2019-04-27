using System;
using UnityEngine;

namespace AdrianKovatana
{
    public class InitState : StateMachineBehaviour
    {
#pragma warning disable
        [SerializeField]
        private FloatVariable _currentTime;

        [SerializeField]
        private GameEvent _sceneFadeInComplete;
#pragma warning restore

        private Animator _animator;

        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            _animator = animator;
            _sceneFadeInComplete.RegisterListener(ChangeState);
            _currentTime.ResetValue();
        }

        //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        //{
        //}

        override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            _sceneFadeInComplete.UnregisterListener(ChangeState);
        }

        private void ChangeState()
        {
            _animator.SetTrigger("Change State");
        }
    }
}
