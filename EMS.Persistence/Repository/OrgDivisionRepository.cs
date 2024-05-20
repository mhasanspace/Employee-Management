using DocumentFormat.OpenXml.Drawing.Charts;
using EMS.Domain.IRepository;
using EMS.Domain.Models;
using EMS.Domain.ViewModels;
using EMS.Persistence.DBaseContext;

namespace EMS.Persistence.Repository
{
    public class OrgDivisionRepository : RepositoryBase<EmsDbContext, OrgDivision>, IOrgDivisionRepository
    {

        private readonly EmsDbContext _context;
        public OrgDivisionRepository(EmsDbContext context) : base(context)
        {
            _context = context;
        }

        public List<OrgDivisionView> GetOrgDivisionList(string? searchTerm)
        {
            List<OrgDivisionView> orgDivisionViews = new List<OrgDivisionView>();

            try
            {
                var query = from ord in context.OrgDivisions
                            join auc in context.Users on ord.CreateBy equals auc.Id
                            join aum in context.Users on ord.LastModifyBy equals aum.Id into lastModifyJoin
                            from aum in lastModifyJoin.DefaultIfEmpty()
                            select new OrgDivisionView
                            {
                                Id = ord.Id,
                                Name = ord.Name,
                                CreateDate = ord.CreateDate.HasValue ? ord.CreateDate.Value.ToString("dd-MMM-yyyy") : string.Empty,
                                CreateByName = auc != null ? $"{auc.FirstName} {auc.LastName}" : "",
                                LastModifyDate = ord.LastModifyDate.HasValue ? ord.LastModifyDate.Value.ToString("dd-MMM-yyyy") : string.Empty,
                                LastModifyByName = aum != null ? $"{aum.FirstName} {aum.LastName}" : ""
                            };

                if (!string.IsNullOrEmpty(searchTerm))
                {
                    query = query.Where(x => x.Name.Contains(searchTerm));
                }

                query = query.OrderByDescending(od => od.Id);

                orgDivisionViews = query.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            return orgDivisionViews ?? new List<OrgDivisionView>();
        }




        public List<OrgDivisionView> GetAllOrgDivision()
        {
            List<OrgDivisionView> orgDivisionViews = new List<OrgDivisionView>();

            try
            {
                var query = from ord in context.OrgDivisions
                            join auc in context.Users on ord.CreateBy equals auc.Id
                            join aum in context.Users on ord.LastModifyBy equals aum.Id into lastModifyJoin
                            from aum in lastModifyJoin.DefaultIfEmpty()
                            select new OrgDivisionView
                            {
                                Id = ord.Id,
                                Name = ord.Name,
                                CreateDate = ord.CreateDate.HasValue ? ord.CreateDate.Value.ToString("dd-MMM-yyyy") : string.Empty,
                                CreateByName = auc != null ? $"{auc.FirstName} {auc.LastName}" : "",
                                LastModifyDate = ord.LastModifyDate.HasValue ? ord.LastModifyDate.Value.ToString("dd-MMM-yyyy") : string.Empty,
                                LastModifyByName = aum != null ? $"{aum.FirstName} {aum.LastName}" : ""
                            };

                query = query.OrderByDescending(od => od.Id);

                orgDivisionViews = query.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            return orgDivisionViews ?? new List<OrgDivisionView>();
        }



        public OrgDivisionView GetOrgDivisionById(int orgDivId)
        {
            OrgDivisionView orgDivisionView = new OrgDivisionView();
            try
            {
                var query = from ord in context.OrgDivisions
                            join auc in context.Users on ord.CreateBy equals auc.Id
                            join aum in context.Users on ord.LastModifyBy equals aum.Id into lastModifyJoin
                            from aum in lastModifyJoin.DefaultIfEmpty()
                            where ord.Id == orgDivId
                            select new OrgDivisionView
                            {
                                Id = ord.Id,
                                Name = ord.Name,
                                CreateDate = ord.CreateDate.HasValue ? ord.CreateDate.Value.ToString("dd-MMM-yyyy") : string.Empty,
                                CreateByName = auc != null ? $"{auc.FirstName} {auc.LastName}" : "",
                                LastModifyDate = ord.LastModifyDate.HasValue ? ord.LastModifyDate.Value.ToString("dd-MMM-yyyy") : string.Empty,
                                LastModifyByName = aum != null ? $"{aum.FirstName} {aum.LastName}" : ""
                            };

                orgDivisionView = query.FirstOrDefault();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            return orgDivisionView;
        }




        void IOrgDivisionRepository.Add(OrgDivision orgDivision)
        {
            _context.Set<OrgDivision>().Add(orgDivision);
        }




    }
}
