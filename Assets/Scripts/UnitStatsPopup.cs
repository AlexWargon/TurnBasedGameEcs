using System;
using DG.Tweening;
using TMPro;
using UnityEngine;
using Wargon.ezs;

public class UnitStatsPopup : UIElement {
    [SerializeField] private TextMeshProUGUI _health;
    [SerializeField] private TextMeshProUGUI _damage;
    [SerializeField] private GameObject _bonusDamageHolder;
    [SerializeField] private TextMeshProUGUI _bonusDamage;
    [SerializeField] private GameObject _poisonHolder;
    [SerializeField] private TextMeshProUGUI _poison;

    public UnitStatsPopup SetStats(Entity entity) {
        if (entity == null || entity.IsDead()) return this;
        _health.text = $"Health:{entity.Get<Health>().value}/{entity.Get<Health>().max}";
        _damage.text = $"Damage:{entity.Get<Damage>().min}-{entity.Get<Damage>().max}";

        _bonusDamageHolder.SetActive(entity.Has<BonusDamage>());
        _poisonHolder.SetActive(entity.Has<PoisonAbility>());
        
        if (entity.Has<BonusDamage>())
            _bonusDamage.text = $"Bonus Damage:{entity.Get<BonusDamage>().valueInPersent}%";

        if(entity.Has<PoisonAbility>())
            _poison.text = $"Poison Damage:{entity.Get<PoisonAbility>().damage}";

        return this;
    }
}