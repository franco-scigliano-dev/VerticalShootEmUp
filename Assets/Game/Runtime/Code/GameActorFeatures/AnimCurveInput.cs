using com.fscigliano.VerticalShootEmUp.GameActors;
using com.fscigliano.CommonExtensions;
using UnityEngine;

namespace com.fscigliano.VerticalShootEmUp.GameActorFeatures
{
    /// <summary>
    /// Product Name:    VerticalShootEmUp
    /// Developers:      Franco Scigliano
    /// Description:     Evaluates an animationCurve for x and another for y movement. This feeds the intention
    ///                  Vector3 for the movement feature.
    /// Changelog:       
    /// </summary>
    public class AnimCurveInput : GameActorFeatureBase, IInputProvider
    {
        public Vector2 Intention
        {
            get => intention;
            set => intention = value;
        }

        public bool Attack { get; set; }

        public AnimationCurve xMovement;
        public AnimationCurve yMovement;
        public float totalDuration;

        protected Vector2 intention;


        public override void DoUpdate(GameActor a, float t)
        {
            var r = MathHelper.InverseLerpUnclamped(0, totalDuration, t);
            float vx = xMovement.Evaluate(r);
            float vy = yMovement.Evaluate(r);
            intention.x = vx;
            intention.y = vy;
        }
    }
}