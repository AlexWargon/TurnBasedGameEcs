using UnityEngine;
using Wargon.ezs;

namespace TaskGame.Systems {

    public class BotAiSystem : UpdateSystem {
        private TeamsService _teamsService;
        private Entity targetForAttack;
        public override void OnInit() {
            _teamsService = Service<TeamsService>.Get();
        }
        public override void Update() {
            entities.Each((ref AttackTick tickEvent) => {
                entities.Each((BotTurn botTurn) => {
                    SelectAttacker();
                    SelectTargetForAttack();
                });
            });
        }

        private void SelectTargetForAttack() {
            entities.Each((Entity entity, PlayerTag playerTag, Health health) => {
                if (targetForAttack == null || targetForAttack.IsDead()) {
                    targetForAttack = entity;
                }else
                if (targetForAttack.Get<Health>().value > health.value) {
                    targetForAttack = entity;
                }
            });
            targetForAttack?.Add(new ClickedEvent());
        }

        private void SelectAttacker() {
            var targetIndex = Random.Range(0, _teamsService.Bot.Count);
            var target = _teamsService.Bot[targetIndex];
            var targetEntity = target.Entity;
            entities.Each((Entity selectedEntity, SelectedTag selectedTag) => {
                selectedEntity.Remove<SelectedTag>();
            });
            targetEntity.Add(new SelectedTag());
        }
    }
}