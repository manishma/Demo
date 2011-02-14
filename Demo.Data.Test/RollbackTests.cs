using NHibernate;
using NUnit.Framework;

namespace Demo.Data.Test
{
    [TestFixture]
    public abstract class RollbackTests
    {
        protected ISession Session;
        protected ITransaction Transaction;

        static RollbackTests()
        {
            // init NHProf
            HibernatingRhinos.Profiler.Appender.NHibernate.NHibernateProfiler.Initialize();

        }

        [SetUp]
        public virtual void SetUp()
        {
            Session = SessionManager.SessionFactory.OpenSession();
            Transaction = Session.BeginTransaction();
        }

        [TearDown]
        public virtual void TearDown()
        {
            Transaction.Rollback();
            Transaction.Dispose();
            Session.Dispose();
        }
        
    }
}