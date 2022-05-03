using UnityEngine;
using Wargon.ezs;
using Wargon.ezs.Unity;

namespace TaskGame.Systems {
    public class UnitStatsPopupTriggerSystem : UpdateSystem {
        private ScreenService _screenService;
        public override void OnInit() {
            _screenService = Service<ScreenService>.Get();
        }

        public override void Update() {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (!Physics.Raycast(ray, out RaycastHit hit)) return;
            
            var monoEntity = hit.collider.GetComponent<MonoEntity>();
            
            if (monoEntity == null) {
                _screenService.Hide<UnitStatsPopup>();
            }
            else 
            if (monoEntity.Entity != null) {
                _screenService.Get<UnitStatsPopup>()
                    .SetStats(monoEntity.Entity)
                    .Show();
            }
            
            
        }
    }
}