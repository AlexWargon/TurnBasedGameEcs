using UnityEngine;
using Wargon.ezs;
using Wargon.ezs.Unity;

namespace TaskGame.Systems {
    public class PooledEntityLifeTimeSystem : UpdateSystem {
        public override void Update() {
            var dt = Time.deltaTime;
            entities.Without<UnActive>().Each((Pooled pooled) => {
                pooled.CurrentLifeTime -= dt;
                if (pooled.CurrentLifeTime <= 0 && !pooled.StaticLife) {
                    pooled.SetActive(false);
                }
            });
        }
    }
}