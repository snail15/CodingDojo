using dojoleague.Models;
using System.Collections.Generic;
namespace dojoleague.Factories
{
    public interface IFactory<T> where T : BaseEntity
    {
    }
}