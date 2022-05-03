using UnityEngine;
using Wargon.ezs;
using Wargon.ezs.Unity;

namespace TaskGame.Systems {
    public class DamagePopupAnimationSystem : UpdateSystem {
        public override void Update() {
            var dt = Time.deltaTime;
            entities.Without<UnActive>().Each((DamagePopup DamagePopup, Pooled pooled, TransformRef transformRef) => {
                transformRef.Value.position += transformRef.Value.up * 2f * dt;
                //transformRef.Value.position -= Vector3.back * dt;
                var scale = transformRef.Value.localScale;
                var percendOfDefaultLifeTime = pooled.CurrentLifeTime / pooled.LifeTime;
                var scalex = 1 - (1 - percendOfDefaultLifeTime);
                scale.x = scalex;
                scale.y = scalex;
                transformRef.Value.localScale = scale;
            });
        }
    }
}