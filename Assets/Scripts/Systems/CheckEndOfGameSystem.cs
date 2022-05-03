using UnityEngine;
using Wargon.ezs;

namespace TaskGame.Systems {
    public class CheckEndOfGameSystem : UpdateSystem {
        private GameRunTimeData _gameRunTimeData;
        private ScreenService _screens;
        public override void OnInit() {
            _gameRunTimeData = Service<GameRunTimeData>.Get();
            _screens = Service<ScreenService>.Get();
        }

        public override void Update() {
            entities.Each((ref CheckEndOfGameEvent checkEndOfGameEvent) => {

                var teamService = Service<TeamsService>.Get();
                var player = teamService.Player;
                var bot = teamService.Bot;
                
                if (player.Count == 0 && bot.Count == 0) {
                    _gameRunTimeData.GameResult = GameResultType.Tie;
                }else
                if (player.Count == 0) {
                    _gameRunTimeData.GameResult = GameResultType.PlayerLose;
                }else
                if (bot.Count == 0) {
                    _gameRunTimeData.GameResult = GameResultType.PlayerWin;
                }
                
                if(_gameRunTimeData.GameResult!= GameResultType.GoOn)
                    _screens.Get<WinScreen>().SetContext(_gameRunTimeData.GameResult).Show();
            });
        }
    }

    public enum GameResultType {
        GoOn,
        PlayerWin,
        PlayerLose,
        Tie
    }

}

public enum SideTurn {
    Player,
    Bot
}
public enum TickType {
    Attack,
    PoisonDamage,
    UnitsDeath,
    TurnChange
}