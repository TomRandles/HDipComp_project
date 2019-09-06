using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TRHDipComp_Project.Models;
using TRHDipComp_Project.Models.Database;

namespace TRHDipComp_Project.Areas.AssessmentPages.Pages
{
    public class GetAssessmentsPerModuleModel : PageModel
    {

        #region db_properties_ctr
        private readonly CollegeDbContext _db;

        private string moduleID = "";

        [BindProperty]
        public IList<Assessment> AssessmentList { get; private set; }

        [BindProperty]
        public IList<Assessment> SelectedAssessmentList { get; private set; } = new List<Assessment>();

        public GetAssessmentsPerModuleModel(CollegeDbContext db)
        {
            _db = db;
        }
        #endregion

        #region get
        public async Task<JsonResult> OnGetAsync()
        {
            AssessmentList = await _db.Assessments.AsNoTracking().ToListAsync();

            if (RouteData.Values["id"] != null)
            {
                moduleID = RouteData.Values["id"].ToString();
            }

            // Get assessments for this module 
            if (AssessmentList.Count() != 0)
            {
                SelectedAssessmentList = AssessmentList.Where(a => a.ModuleID == moduleID)
                                                       .Select(a => a)
                                                       .ToList();
            }

            var json = Newtonsoft.Json.JsonConvert.SerializeObject(SelectedAssessmentList);
            return new JsonResult(json);
        }
        #endregion
    }
}