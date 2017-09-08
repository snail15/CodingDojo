using DapperApp.Models;
using System.Collections.Generic;
namespace lostinthewoods.Factories
{
    public interface IFactory<T> where T : BaseEntity
    {
    }
}