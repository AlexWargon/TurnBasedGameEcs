using System.Collections.Generic;
using UnityEngine;
using Wargon.ezs.Unity;

public class TeamsService : MonoBehaviour {
    [SerializeField] private List<MonoEntity> bot;
    [SerializeField] private List<MonoEntity> player;
    public List<MonoEntity> Player => player;
    public List<MonoEntity> Bot => bot;

    public void Remove(MonoEntity monoEntity) {
        var e = monoEntity.Entity;
        if (e.Has<BotTag>())
            bot.Remove(monoEntity);
        else
            player.Remove(monoEntity);
    }
}