// <copyright file="Message.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace U09_DelegatesEvents.T_03
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class MessageEventArgs : EventArgs
    {
        private readonly string mailFrom;
        private readonly string mailTo;
        private readonly string mailSubject;

        public MessageEventArgs(string from, string to, string subject)
        {
            this.mailFrom = from;
            this.mailTo = to;
            this.mailSubject = subject;
        }

        public string From
        {
            get { return this.mailFrom; }
        }

        public string To
        {
            get { return this.mailTo; }
        }

        public string Subject
        {
            get { return this.mailSubject; }
        }

        public override string ToString()
        {
            return $"{this.mailFrom} {this.mailTo} {this.mailSubject}";
        }
    }
}
