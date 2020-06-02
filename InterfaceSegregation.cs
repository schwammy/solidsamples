using System;
using System.Net;

namespace EndToEndSamples.SOLID
{

    public interface IRepository<T>
    {
        T Find(int id);
        IEnumerable<T> Get();
        void Add(T item);
        void Update(T item);
        void Delete(T item);
    }

    public interface IReadonlyRepository<T>
    {
        T Find(int id);
        IEnumerable<T> Get();
    }

    public interface IWriteableRepository<T> : IReadonlyRepository<T>
    {
        void Add(T item);
        void Update(T item);
        void Delete(T item);
    }


    public interface IEntity
    {
        int Id { get; set; }
        DateTime CreatedDate { get; set; }
        string CreatedByUser { get; set; }
        DateTime? LastUpdatedDate { get; set; }
        string LastUpdatedByUser { get; set; }

    }

    public interface IIntId
    {
        int Id { get; set; }
    }

    public interface IAuditable
    {
        DateTime CreatedDate { get; set; }
        string CreatedByUser { get; set; }
        DateTime? LastUpdatedDate { get; set; }
        string LastUpdatedByUser { get; set; }
    }

    public class Something : IIntId, IAuditable
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedByUser { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public string LastUpdatedByUser { get; set; }
    }

}