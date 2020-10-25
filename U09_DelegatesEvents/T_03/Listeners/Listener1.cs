// <copyright file="Listener1.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace U09_DelegatesEvents.T_03.Listeners
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Listener1
    {
        public Listener1(CountdownManager countdown)
        {
            countdown.NewMessage += this.ReceiveMessage;
        }

        public void Subscribe(CountdownManager countdown)
        {
            countdown.NewMessage += this.ReceiveMessage;
        }

        public void Unsubscribe(CountdownManager countdown)
        {
            countdown.NewMessage -= this.ReceiveMessage;
        }

        private void ReceiveMessage(object sender, MessageEventArgs msg)
        {
            Console.WriteLine(this.ToString() + " " + msg);
        }
    }
}
