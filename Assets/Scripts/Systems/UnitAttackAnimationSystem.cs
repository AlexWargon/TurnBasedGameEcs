using DG.Tweening;
using Wargon.ezs;

namespace TaskGame.Systems {
    public class UnitAttackAnimationSystem : OnAdd<UnitAttackEvent> {
        public override void Execute(in Entity entity) {
            var transform = entity.Get<TransformRef>().Value;
            var startPos = transform.position;
            transform.DOMove(transform.position + transform.forward, 0.2f).OnComplete(() => {
                transform.DOMove(startPos, 0.2f);
            });
        }
    }
}