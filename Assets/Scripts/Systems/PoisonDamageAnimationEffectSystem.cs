using DG.Tweening;
using UnityEngine;
using Wargon.ezs;

namespace TaskGame.Systems {
    public class PoisonDamageAnimationEffectSystem : OnAdd<PoisonDamageEvent> {
        public override void Execute(in Entity entity) {
            var transform = entity.Get<TransformRef>().Value;
            var dir = Random.value > 0.5f ? Vector3.left : Vector3.right;
            transform.DOPunchScale(dir, 0.5f);
        }
    }
}