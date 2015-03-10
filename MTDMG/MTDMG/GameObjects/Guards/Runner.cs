using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameHelper;
using Microsoft.Xna.Framework;

namespace MTDMG.GameObjects.Guards
{
    /// <summary>
    /// Runner
    /// </summary>
    class Runner : Guard
    {
        public Runner(MazeGame game, PlayerControler player)
            : base(game, player)
        {
            IntervallOffset = 0.3f;
            renderer = new Render3D(this, "Model/Runner");
            transform.Scale = new Vector3(0.6f, 0.6f, 0.6f);
        }


        public override void SearchPath()
        {
            GameHelper.Graph.Vertex<CellSlot> BaseVertex = GetVertex(player.playerGraph, ((Scenes.StartScene)game.myScene).GetOpposit(player).myBase.transform.ToVector2());

            if (BaseVertex != null)
            {
                FindPath(BaseVertex.data);
            }
            else
            {
                myState = States.SearchField;
            }
        }

        public override void Attack()
        {
            ((Scenes.StartScene)game.myScene).GetOpposit(player).myBase.GetDamage();
            base.Attack();
        }


    }
}
