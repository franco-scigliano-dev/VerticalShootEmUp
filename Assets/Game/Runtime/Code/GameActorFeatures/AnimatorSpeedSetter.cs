using com.fscigliano.VerticalShootEmUp.GameActors;
using UnityEngine;

namespace com.fscigliano.VerticalShootEmUp.GameActorFeatures
{
    /// <summary>
    /// Product Name:    VerticalShootEmUp
    /// Developers:      Franco Scigliano
    /// Description:     
    /// Changelog:       
    /// </summary>
    public class AnimatorSpeedSetter : GameActorFeatureBase
    {
        [SerializeField] protected Animator _animator;
        [SerializeField] protected Rigidbody2D _rb2d;
        [SerializeField] private string _parameter;
        [SerializeField] private float _currentSpeed;
        [SerializeField] private float _speed = 0.5f;
        [SerializeField] private float _cSpeed;

        public override void DoFixedUpdate(GameActor a, float t)
        {
            base.DoFixedUpdate(a, t);
            _currentSpeed = Mathf.SmoothDamp(_currentSpeed, _rb2d.linearVelocity.x, ref _cSpeed, _speed);
            _animator.SetFloat(_parameter, _currentSpeed);
        }
    }
}