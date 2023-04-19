using System.Collections.Generic;
using NetChallenge.Abstractions;
using NetChallenge.Domain;
using NetChallenge.Domain.Office;

namespace NetChallenge.Infrastructure
{
    public class OfficeRepository : IOfficeRepository
    {
        private List<Office> officeList = new List<Office>();

        public IEnumerable<Office> AsEnumerable()
        {
            return officeList;
        }

        public void Add(Office item)
        {
            officeList.Add(item);
        }
    }
}