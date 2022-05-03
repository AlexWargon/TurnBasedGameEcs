using UnityEngine;
using Wargon.ezs;

namespace TaskGame.Systems {
    public class DamageSystem : UpdateSystem {
        public override void Update() {
            entities.Each((Entity entity, ClickedEvent clickedTag) => {
                entities.Each((Entity attackingEntity, SelectedTag selectedTag, Damage damage) => {
                    entity.Get<DamagedEvent>().value = Random.Range(damage.min, damage.max);
                    attackingEntity.Add(new UnitAttackEvent());
                    world.CreateEntity().Get<EffectDelay>().value = Constans.EFFECT_DELAY;
                });    
            });
        }
    }
}