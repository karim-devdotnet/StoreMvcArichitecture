using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.Model;
using Store.Data.Repositories;
using Store.Data.Infrastructure;

namespace Store.Service
{
    public class GadgetService : IGadgetService
    {
        private readonly IGadgetRepository _GadgetsRepository;
        private readonly ICategoryRepository _CategoryRepository;
        private readonly IUnitOfWork _UnitOfWork;

        public GadgetService(IGadgetRepository gadgetsRepository, ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            _GadgetsRepository = gadgetsRepository;
            _CategoryRepository = categoryRepository;
            _UnitOfWork = unitOfWork;
        }

        public void CreateGadget(Gadget gadget)
        {
            _GadgetsRepository.Add(gadget);
        }

        public IEnumerable<Gadget> GetCategoryGadgets(string categoryName, string gadgetName = null)
        {
            var category = _CategoryRepository.GetCategoryByName(categoryName);
            return category.Gadgets.Where(g => g.Name.ToLower().Contains(gadgetName.ToLower().Trim()));
        }

        public Gadget GetGadget(int id)
        {
            return _GadgetsRepository.GetById(id);
        }

        public IEnumerable<Gadget> GetGadgets()
        {
            var gadgets = _GadgetsRepository.GetAll();
            return gadgets;
        }

        public void SaveGadget()
        {
            _UnitOfWork.Commit();
        }
    }
}
