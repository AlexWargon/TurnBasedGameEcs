using System;
using System.Collections.Generic;
using UnityEngine;
using Wargon.ezs;
using Wargon.ezs.Unity;
using TaskGame.Systems;

public static class Constans {
    public const float EFFECT_DELAY = 1f;
    public static readonly Quaternion DAMAGE_POPUP_ROTATION;
    
    static Constans() {
        DAMAGE_POPUP_ROTATION = Quaternion.Euler(45,45,0);
    }
}
public class GameCore : MonoBehaviour {
    
    private World _world;
    private Systems _updateSystems;
    [SerializeField] private StaticDataService _staticDataService;
    [SerializeField] private PrefabsService _prefabsService;
    [SerializeField] private TeamsService _teamsService;
    [SerializeField] private ScreenService _screenService;
    [SerializeField] private GameRunTimeData _gameRunTimeData;
    private void Awake() {
        Application.targetFrameRate = 60;
        Configs.ComponentCacheSize = 128;
        Configs.EntityCacheSize = 128;
        Configs.PoolsCacheSize = 128;
        Configs.EntityTypesCacheSize = 64;

        InitServices();
        InitEcsWorld();
    }

    private void InitEcsWorld() {
        _world = new World();
        MonoConverter.Init(_world);
        _updateSystems = new Systems(_world)
                .Add(new InitGameSystem())
                .Add(new TickControlSystem())
                .Add(new EffectDelaySystem())
                .Add(new UnitStatsPopupTriggerSystem())
                .Add(new MouseClickControlSystem())
                .Add(new BotAiSystem())
                .Add(new DamageSystem())
                .Add(new PoisonDamageSystem())
                .Add(new AddPoisonEffectSystem())
                .Add(new BonusDamageSystem())
                .Add(new ApplyDamageSystem())
                .Add(new ApplyPoisonDamageSystem())
                .Add(new PooledEntityLifeTimeSystem())
                .Add(new DamagePopupAnimationSystem())
                .Add(new DestroyUnitSystem())
                .Add(new SpawnParticleOnUnitDeathSystem())
                .Add(new PlayerParticleOnPoolSystem())
                .Add(new UnselectUnitSystem())
                .Add(new CheckEndOfGameSystem())
                .Add(new ClearUpdateEventsSystem())
                
                //Reactive systems executes not in order, only when they are triggered;
                .AddReactive(new ChangeTurnSystem())
                .AddReactive(new DamageAnimationEffectSystem())
                .AddReactive(new PoisonDamageAnimationEffectSystem())
                .AddReactive(new UnitAttackAnimationSystem())
                .AddReactive(new InitHealthSystem())
                .AddReactive(new InitHealthBarSystem())
                .AddReactive(new OnSelectUnitSystem())
                .AddReactive(new OnUnSelectSystem())
                .AddReactive(new OnAddPoisonSystem())
             
            ;
#if UNITY_EDITOR
        new DebugInfo(_world);
#endif
        _updateSystems.Init();
    }

    private void InitServices() {
        Service<PrefabsService>.Set(_prefabsService);
        Service<TeamsService>.Set(_teamsService);
        Service<ScreenService>.Set(_screenService);
        Service<StaticDataService>.Set(_staticDataService);
        Service<GameRunTimeData>.Set(_gameRunTimeData);
    }
    private void Update() {
        if(_world==null) return;
        if(_gameRunTimeData.GameResult != GameResultType.GoOn) return;
        _updateSystems.OnUpdate();
    }


    private void OnDestroy() {
        if (_world != null) {
            _updateSystems = null;
            _world.Destroy();
            _world = null;
        }
    }
}