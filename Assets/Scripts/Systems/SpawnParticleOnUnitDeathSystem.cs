using UnityEngine;
using Wargon.ezs;
using Wargon.ezs.Unity;

namespace TaskGame.Systems {
    public class SpawnParticleOnUnitDeathSystem : UpdateSystem {
        public override void Update() {
            entities.Each((DestroyUnitEvent destroyEvent, View view, DeathEffect deathEffect) => {
                Pools.ReuseEntity(deathEffect.value, view.value.transform.position, Quaternion.identity);
                Service<TeamsService>.Get().Remove(view.value);
                Object.Destroy(view.value.gameObject);
                world.CreateEntity().Get<EffectDelay>().value = Constans.EFFECT_DELAY;
                world.CreateEntity().Add(new CheckEndOfGameEvent());
            });
        }
    }
}