using UnityEngine;
using Wargon.ezs;
using Wargon.ezs.Unity;

namespace TaskGame.Systems {
    public class EffectDelaySystem : UpdateSystem {
        private EntityType<EffectDelay>.WithOut<UnActive> _effectsDelay;
        public override void OnInit() {
            _effectsDelay = entities.Without<UnActive>().GetEntityType<EffectDelay>();
        }
        public override void Update() {
            var dt = Time.deltaTime;
            for (var i = 0; i < _effectsDelay.Count; i++) {
                var effect = _effectsDelay.GetA(i);
                effect.value -= dt;
                if (effect.value <= 0) {
                    var e = _effectsDelay.GetEntity(i);
                    e.Remove<EffectDelay>();
                }
            }
        }
    }
}