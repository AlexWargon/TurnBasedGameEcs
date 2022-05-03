using DG.Tweening;
using UnityEngine;
using Wargon.ezs;

namespace TaskGame.Systems {
    public class DamageAnimationEffectSystem : OnAdd<DamagedEvent> {
        public override void Execute(in Entity entity) {

            var dir = Random.value > 0.5f ? Vector3.left : Vector3.right;
            entity.Get<TransformRef>().Value.DOPunchPosition(dir, 0.3f, 5, 0.6f);
            entity.Get<TransformRef>().Value.DOPunchScale(dir, 0.3f);
        }
    }
}