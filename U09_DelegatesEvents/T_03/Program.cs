// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace U09_DelegatesEvents.T_03
{
    using U09_DelegatesEvents.T_03.Listeners;

    public class Program
    {
        static void Main(string[] args)
        {
            var manager = new CountdownManager();
            var listener = new Listener1(manager);
            var listener2 = new Listener2(manager);

            manager.CallMessage("Me", "ToYou", "Subject");
        }
    }
}
