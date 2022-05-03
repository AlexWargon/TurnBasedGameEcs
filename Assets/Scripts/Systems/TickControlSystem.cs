using TaskGame.Systems;
using UnityEngine;
using Wargon.ezs;
using Wargon.ezs.Unity;

public class TickControlSystem : UpdateSystem {
    private GameRunTimeData _gameRunTimeData;
    private EntityType<EffectDelay>.WithOut<UnActive> _effectsDelay;
    public override void OnInit() {
        _gameRunTimeData = Service<GameRunTimeData>.Get();
        _effectsDelay = entities.Without<UnActive>().GetEntityType<EffectDelay>();
    }

    public override void Update() {
        var dt = Time.deltaTime;
        entities.Each((CurrentGameTick gameTick) => {
            gameTick.tickDelay -= dt;
            if (gameTick.tickDelay <= 0) {
                var staticData = Service<StaticDataService>.Get();
                switch (_gameRunTimeData.NextTick) {
                    case TickType.Attack:
                        if (_gameRunTimeData.CurentSide == SideTurn.Bot) {
                            _gameRunTimeData.NextTick = TickType.PoisonDamage;
                            world.CreateEntity().Add(new AttackTick());
                            gameTick.tickDelay = staticData.DelayAfterBotAttack;
                        }
                        break;
                    case TickType.PoisonDamage:
                        _gameRunTimeData.NextTick = TickType.UnitsDeath;
                        world.CreateEntity().Add(new PoisonDamageTick());
                        gameTick.tickDelay = staticData.DelayAfterPoisonDamage;
                        break;
                    case TickType.UnitsDeath:
                        _gameRunTimeData.NextTick = TickType.TurnChange;
                        world.CreateEntity().Add(new UnitsDeathTick());
                        gameTick.tickDelay = staticData.DelayAfterUnitDeaths;
                        break;
                    case TickType.TurnChange:
                        if (_effectsDelay.IsEmpty()) {
                            _gameRunTimeData.NextTick = TickType.Attack;
                            world.CreateEntity().Add(new TurnChangeTick());
                            gameTick.tickDelay = staticData.BotAttackDelay;
                        }
                        break;
                }
            }
        });
    }
}