﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.controller.piece;
using Assets.Scripts.engine.session;

namespace Assets.Scripts.controller.session
{
    public class SessionController:Singleton<SessionController>
    {
        private Session session;
        private IGameServices services;

        public void StartSession(IGameServices services)
        {
            this.services = services;
            session = new Session();
            services.NotifyStartSession();
            CheckNewPiece();
        }

        public void CheckNewPiece()
        {
            if(session.isOver) services.NotifyEndGame(session.isWinner);
            else{ services.NotifyNextPiece(session.NextPiece());}
        }

        public int falls => session.falls;
        public int stackeds => session.stackeds;


        public void SetFail() => session.SetFail();
        public void SetStacked() => session.SetStacked();
        public void SetFall() => session.SetFall();

    }
}
