namespace ClassLibrary1
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<account> account { get; set; }
        public virtual DbSet<administrator> administrator { get; set; }
        public virtual DbSet<client> client { get; set; }
        public virtual DbSet<EvaluationForm> EvaluationForm { get; set; }
        public virtual DbSet<FormerInformation> FormerInformation { get; set; }
        public virtual DbSet<order> order { get; set; }
        public virtual DbSet<RankingList> RankingList { get; set; }
        public virtual DbSet<runner> runner { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<account>()
                .Property(e => e.CardNumber)
                .IsUnicode(false);

            modelBuilder.Entity<account>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<account>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<account>()
                .Property(e => e.Nickname)
                .IsUnicode(false);

            modelBuilder.Entity<account>()
                .Property(e => e.Telephone)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<account>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<account>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<account>()
                .HasMany(e => e.client)
                .WithRequired(e => e.account)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<account>()
                .HasMany(e => e.EvaluationForm)
                .WithRequired(e => e.account)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<account>()
                .HasMany(e => e.runner)
                .WithRequired(e => e.account)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<administrator>()
                .Property(e => e.AdminID)
                .IsUnicode(false);

            modelBuilder.Entity<administrator>()
                .Property(e => e.AdminName)
                .IsUnicode(false);

            modelBuilder.Entity<client>()
                .Property(e => e.ClientID)
                .IsUnicode(false);

            modelBuilder.Entity<client>()
                .Property(e => e.CardNumber)
                .IsUnicode(false);

            modelBuilder.Entity<client>()
                .HasMany(e => e.order)
                .WithRequired(e => e.client)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EvaluationForm>()
                .Property(e => e.RunnerID)
                .IsUnicode(false);

            modelBuilder.Entity<EvaluationForm>()
                .Property(e => e.RunnerName)
                .IsUnicode(false);

            modelBuilder.Entity<EvaluationForm>()
                .Property(e => e.CardNumber)
                .IsUnicode(false);

            modelBuilder.Entity<EvaluationForm>()
                .Property(e => e.Summary)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<EvaluationForm>()
                .Property(e => e.Positive)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<EvaluationForm>()
                .Property(e => e.Negative)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FormerInformation>()
                .Property(e => e.CardNumber)
                .IsUnicode(false);

            modelBuilder.Entity<FormerInformation>()
                .Property(e => e.ClientName)
                .IsUnicode(false);

            modelBuilder.Entity<FormerInformation>()
                .Property(e => e.PrimaryPhone)
                .IsUnicode(false);

            modelBuilder.Entity<FormerInformation>()
                .Property(e => e.PrimaryAddress)
                .IsUnicode(false);

            modelBuilder.Entity<order>()
                .Property(e => e.OrderNumber)
                .IsUnicode(false);

            modelBuilder.Entity<order>()
                .Property(e => e.Text)
                .IsUnicode(false);

            modelBuilder.Entity<order>()
                .Property(e => e.ClientID)
                .IsUnicode(false);

            modelBuilder.Entity<order>()
                .Property(e => e.RunnerID)
                .IsUnicode(false);

            modelBuilder.Entity<order>()
                .Property(e => e.ClientPhone)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<order>()
                .Property(e => e.RunnerPhone)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<order>()
                .Property(e => e.Evaluate)
                .IsUnicode(false);

            modelBuilder.Entity<order>()
                .Property(e => e.Tip)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<RankingList>()
                .Property(e => e.RunnerID)
                .IsUnicode(false);

            modelBuilder.Entity<RankingList>()
                .Property(e => e.RunnerName)
                .IsUnicode(false);

            modelBuilder.Entity<RankingList>()
                .Property(e => e.TipSum)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<runner>()
                .Property(e => e.RunnerID)
                .IsUnicode(false);

            modelBuilder.Entity<runner>()
                .Property(e => e.CardNumber)
                .IsUnicode(false);

            modelBuilder.Entity<runner>()
                .Property(e => e.TipSum)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<runner>()
                .HasMany(e => e.order)
                .WithRequired(e => e.runner)
                .WillCascadeOnDelete(false);
        }
    }
}
