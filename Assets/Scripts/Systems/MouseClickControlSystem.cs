using UnityEngine;
using Wargon.ezs;
using Wargon.ezs.Unity;

namespace TaskGame.Systems {
    public class MouseClickControlSystem : UpdateSystem {
        private GameRunTimeData _gameRunTimeData;
        public override void OnInit() {
            _gameRunTimeData = Service<GameRunTimeData>.Get();
        }

        public override void Update() {
            if (Input.GetMouseButtonDown(0) && _gameRunTimeData.CurentSide == SideTurn.Player) {
                var ray = Camera.main.ScreenPointToRay(Input.mousePosition); //in the old versions of the unit it caused allocations, now it is fixed
            
                if (!Physics.Raycast(ray, out RaycastHit hit)) return;
            
                var monoEntity = hit.collider.GetComponent<MonoEntity>();

                if (monoEntity == null) return;
                
                var e = monoEntity.Entity;
                
                if (e.Has<PlayerTag>()) {
                    entities.Each((Entity selectedEntity, SelectedTag selectedTag) => { // unselect other unit
                        if (e.id != selectedEntity.id)
                            selectedEntity.Remove<SelectedTag>();
                    });
                    
                    e.Add(new SelectedTag());
                }else 
                if (e.Has<BotTag>() && _gameRunTimeData.NextTick == TickType.Attack) {
                    entities.Each((Entity selectedEntity, SelectedTag selectedTag) => { // if has selected player unit
                        e.Add(new ClickedEvent());
                        entities.Each((ref CurrentGameTick tick) => tick.tickDelay = Service<StaticDataService>.Get().DelayAfterBotAttack);
                        _gameRunTimeData.NextTick = TickType.PoisonDamage;
                    });
                }
            }
        }
    }
}