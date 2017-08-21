using System;
using System.Collections.Generic;
using System.Text;

namespace Fiver.Design.Builder
{
    public interface IEmailBuilderAddSubject
    {
        IEmailBuilderAddFrom AddSubject(string subject);
    }

    public interface IEmailBuilderAddFrom
    {
        IEmailBuilderAddBody AddFrom(string from);
    }

    public interface IEmailBuilderAddBody
    {
        IEmailBuilderAddTo AddBody(string body);
    }

    public interface IEmailBuilderAddTo
    {
        IEmailBuilder AddTo(string to);
    }

    public interface IEmailBuilder
    {
        IEmailBuilder AddTo(string to);
        IEmailBuilder AddCC(string cc);
        IEmailBuilder AddBCC(string bcc);
        IEmailBuilder AddAttachment(string attachment);
        Email Build();
    }

    public sealed class EmailBuilder :
        IEmailBuilderAddSubject, 
        IEmailBuilderAddFrom,
        IEmailBuilderAddBody,
        IEmailBuilderAddTo,
        IEmailBuilder
    {
        private string subject = "";
        private string from = "";
        private string body = "";
        private List<string> to = new List<string>();
        private List<string> cc = new List<string>();
        private List<string> bcc = new List<string>();
        private List<string> attachments = new List<string>();

        private EmailBuilder() {}

        public static IEmailBuilderAddSubject CreateNew()
        {
            return new EmailBuilder();
        }

        public IEmailBuilderAddFrom AddSubject(string subject)
        {
            this.subject = subject;
            return this;
        }

        public IEmailBuilderAddBody AddFrom(string from)
        {
            this.from = from;
            return this;
        }

        public IEmailBuilderAddTo AddBody(string body)
        {
            this.body = body;
            return this;
        }

        public IEmailBuilder AddTo(string to)
        {
            this.to.Add(to);
            return this;
        }

        public IEmailBuilder AddCC(string cc)
        {
            this.cc.Add(cc);
            return this;
        }

        public IEmailBuilder AddBCC(string bcc)
        {
            this.bcc.Add(bcc);
            return this;
        }

        public IEmailBuilder AddAttachment(string attachment)
        {
            this.attachments.Add(attachment);
            return this;
        }

        public Email Build()
        {
            return new Email(
                subject: this.subject,
                from: this.from,
                body: this.body,
                to: this.to,
                cc: this.cc,
                bcc: this.bcc,
                attachments: this.attachments);
        }
    }
}
