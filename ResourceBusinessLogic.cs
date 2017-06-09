using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContosoUniversity.Data;
using ContosoUniversity.Models;
using ContosoUniversity.Models.SchoolViewModels;
using ContosoUniversity.Models.SearchModel;
using Microsoft.EntityFrameworkCore;

namespace ContosoUniversity
{
    public class ResourceBusinessLogic
    {
        private readonly SchoolContext _context;
        private IRepository<Culture> _repoCulture;
        private IRepository<Resource> _repoResource;

        //public ResourceBusinessLogic()
        //{
        //    //_context = context;
        //    //_repoCulture = repoCulture;
        //    //_repoResource = repoResource;
        //}

        public ResourceBusinessLogic(SchoolContext context, IRepository<Culture> repoCulture, IRepository<Resource> repoResource)
        {
            _context = context;
            _repoCulture = repoCulture;
            _repoResource = repoResource;
        }



        public IQueryable<Resource> GetResources(ResourceSearchModel searchModel)
        {
            var result = _context.Resources.AsQueryable();
         //   var result = _context.Resources.Include(d => d.Culture);
            if (searchModel != null)
            {
                if (searchModel.Key != null)
                    result = result.Where(x => x.Key == searchModel.Key);
                //if (!string.IsNullOrEmpty(searchModel.Culture.Name))
                //    result = result.Where(x => x.Culture.Name.Contains(searchModel.Culture.Name));
                //if (searchModel.PriceFrom.HasValue)
                //    result = result.Where(x => x.Price >= searchModel.PriceFrom);
                //if (searchModel.PriceTo.HasValue)
                //    result = result.Where(x => x.Price <= searchModel.PriceTo);
            }
            return result;
        }
    }
}
