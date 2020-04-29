﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timers;

namespace POTCW
{
    public class SummonNode : BehaviourNode<EnemyAgent>
    {
        EnemyBlackBoard board;
        private bool check = false;
        AnimatorClipInfo[] currentClipInfo;

        public SummonNode(EnemyBlackBoard board)
        {
            this.board = board;
        }

        //Called when the node is entered
        public override State Start()
        {

            currentClipInfo = board.AnimatorController.GetCurrentAnimatorClipInfo(0);
            TimerManager.Instance.AddTimer(() => { check = !check; }, currentClipInfo[0].clip.length);

            board.AnimatorController.SetTrigger(Globals.BOSS_SUMMON_ANIMATORBOOL);

            Debug.Log("Start Summon");
            return State.IN_PROGRESS;
        }

        //Called everey frame while the node is active
        public override State Update()
        {
            if (check)
            {
                //Spawn Minions
                foreach (Transform spawn in board.EnemyAgent.MinionSpawns)
                {
                    GameObject minion = GameObject.Instantiate(board.EnemyAgent.MinionPrefab, spawn.position, Quaternion.identity);
                }
                return State.SUCCESS;
            }
            else
                return State.IN_PROGRESS;
        }
    }
}
