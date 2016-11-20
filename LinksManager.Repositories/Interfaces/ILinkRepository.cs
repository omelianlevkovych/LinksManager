using LinksManager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinksManager.Repositories
{
    public interface ILinkRepository
    {
        IEnumerable<LinkEntity> GetLinks();

        LinkEntity Get(int id);

        LinkEntity Update(LinkEntity link);

        LinkEntity Add(LinkEntity link);

        void Remove(int id);
    }
}
