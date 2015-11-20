using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Libero;
using Libero.Interfaces;
using Libero.Repositorios;
using Moq;
using FizzWare.NBuilder;
using System.Data.Entity;
using Repositorios.Interfaces;
using System.Collections.ObjectModel;
using System.Linq;
using System.Collections.Generic;

namespace LiberoTeste
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            

            var mockContext = new Mock<IContext>();
            mockContext.Setup(m => m.Clientes).Returns(new FakeSET<Cliente>());

            var service = new RepoCliente(mockContext.Object);
            service.CadastrarCliente(new Cliente() { Nome = "Codorna", Cpf = "089.358.804-00", DadosCartao = "1",
                                    Endereco="rua dez", ClienteId = 50});

          
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }
    }
    public class FakeSET<T> : IDbSet<T> where T : class
    {
        ObservableCollection<T> fakeSet;
        IQueryable query;

        public FakeSET()
        {
            fakeSet = new ObservableCollection<T>();
            query = fakeSet.AsQueryable();
        }

        public virtual T Find(params object[] keyValues)
        {
            throw new NotImplementedException("Achou?:)");
        }

        public T Add(T item)
        {
            fakeSet.Add(item);
            return item;
        }

        public T Remove(T item)
        {
            fakeSet.Remove(item);
            return item;
        }

        public T Attach(T item)
        {
            fakeSet.Add(item);
            return item;
        }

        public T Detach(T item)
        {
            fakeSet.Remove(item);
            return item;
        }

        public T Create()
        {
            return Activator.CreateInstance<T>();
        }

        public TDerivedEntity Create<TDerivedEntity>() where TDerivedEntity : class, T
        {
            return Activator.CreateInstance<TDerivedEntity>();
        }

        public ObservableCollection<T> Local
        {
            get { return fakeSet; }
        }

        Type IQueryable.ElementType
        {
            get { return query.ElementType; }
        }

        System.Linq.Expressions.Expression IQueryable.Expression
        {
            get { return query.Expression; }
        }

        IQueryProvider IQueryable.Provider
        {
            get { return query.Provider; }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return fakeSet.GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return fakeSet.GetEnumerator();
        }
    }
}
