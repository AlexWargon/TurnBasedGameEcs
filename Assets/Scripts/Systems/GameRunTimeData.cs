using UnityEngine;
using UnityEngine.Serialization;

namespace TaskGame.Systems {
    public class GameRunTimeData : MonoBehaviour {
        public GameResultType GameResult = GameResultType.GoOn;
        public TickType NextTick = TickType.Attack;
        public SideTurn CurentSide = SideTurn.Player;
    }
}