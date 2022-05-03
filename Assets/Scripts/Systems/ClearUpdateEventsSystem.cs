using Wargon.ezs;

// ReSharper disable once CheckNamespace
namespace TaskGame.Systems {
    public class ClearUpdateEventsSystem : UpdateSystem {
        public override void Update() {
            entities.Each((Entity e, in ClickedEvent damagedEvent) =>           e.Remove<ClickedEvent>());
            entities.Each((Entity e, DamagedEvent damagedEvent) =>                  e.Remove<DamagedEvent>());
            //entities.Each((Entity e, PoisonDamageEvent damagedEvent) =>             e.Remove<PoisonDamageEvent>());
            entities.Each((Entity e, in TurnTickEvent damagedEvent) =>          e.Remove<TurnTickEvent>());
            entities.Each((Entity e, TurnEnd damagedEvent) =>                    e.Remove<TurnEnd>()); 
            entities.Each((Entity e, in BotAttackEvent damagedEvent) =>          e.Remove<BotAttackEvent>());
            entities.Each((Entity e, in UnitAttackEvent attackEvent) =>          e.Remove<UnitAttackEvent>());
            entities.Each((Entity e, in DestroyUnitEvent attackEvent) =>        e.Remove<DestroyUnitEvent>());
            entities.Each((Entity e, in PooledEvent pooledEvent) =>             e.Remove<PooledEvent>());
            entities.Each((Entity e, in CheckEndOfGameEvent pooledEvent) =>     e.Remove<CheckEndOfGameEvent>());
            
            
            entities.Each((Entity e, in AttackTick tick) => e.Remove<AttackTick>());
            entities.Each((Entity e, in PoisonDamageTick tick) => e.Remove<PoisonDamageTick>());
            entities.Each((Entity e, in TurnChangeTick tick) => e.Remove<TurnChangeTick>());
            entities.Each((Entity e, in UnitsDeathTick tick) => e.Remove<UnitsDeathTick>());
        }
    }
}