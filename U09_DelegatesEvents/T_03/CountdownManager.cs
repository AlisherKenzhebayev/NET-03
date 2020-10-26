// <copyright file="CountdownManager.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace U09_DelegatesEvents.T_03
{
    using System;
    using System.Threading;

    public class CountdownManager
    {
        public event EventHandler<MessageEventArgs> NewMessage = (sender, e) => { };

        public void CallMessage(string from, string to, string subject)
        {
            Console.WriteLine("Enter time in seconds");
            var inSeconds = 0;
            try
            {
                inSeconds = int.Parse(Console.ReadLine());
            }
            catch
            {
            }

            Thread.Sleep(inSeconds * 1000);
            this.OnNewMessage(new MessageEventArgs(from, to, subject));
        }

        protected virtual void OnNewMessage(MessageEventArgs e)
        {
            var t = this.NewMessage;
            t?.Invoke(this, e);
        }
    }
}
