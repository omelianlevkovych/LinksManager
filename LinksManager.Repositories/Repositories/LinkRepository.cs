using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinksManager.Entities;

namespace LinksManager.Repositories.Repositories
{
    public class LinkRepository : ILinkRepository
    {
        private static readonly List<LinkEntity> links;

        private static int lastGeneratedId;

        static LinkRepository()
        {
            links = new List<LinkEntity>()
            {
                new LinkEntity {Id = 1, Title = "www.google.com", CreationDate = DateTime.Now },
                new LinkEntity {Id = 2, Title = "github.com", CreationDate = DateTime.Now },
                new LinkEntity {Id = 3, Title = "www.coursera.org", CreationDate = DateTime.Now }
            };

            lastGeneratedId = 3;
        }

        private int GenerateNextId()
        {
            lastGeneratedId++;
            return lastGeneratedId;
        }

        public LinkEntity Add(LinkEntity link)
        {
            link.Id = GenerateNextId();
            links.Add(link);

            return link;
        }

        public LinkEntity Get(int id)
        {
            LinkEntity link = links
                .Where(x => x.Id == id)
                .Single();

            return link;
        }

        public IEnumerable<LinkEntity> GetLinks()
        {
            return links;
        }

        public void Remove(int id)
        {
            var existingLink = links
                .Where(x => x.Id == id)
                .Single();
            links.Remove(existingLink);
        }

        public LinkEntity Update(LinkEntity link)
        {
            var existingLink = links
                .Select((l, i) => new { Link = l, Index = i })
                .Where(x => x.Link.Id == link.Id)
                .Single();
            links[existingLink.Index] = link;

            return link;
        }
    }
}
