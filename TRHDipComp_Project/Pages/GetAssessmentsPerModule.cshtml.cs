using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using TRHDipComp_Project.Models;


namespace TRHDipComp_Project.Pages
{
    public class GetAssessmentsPerModuleModel : PageModel
    {

        private readonly CollegeDbContext _db;

        private string modID = "";

        public string Message { get; set; } = "";

        [BindProperty]
        public IList<Assessment> AssessmentList { get; private set; }

        [BindProperty]
        public IList<Assessment> SelectedAssessmentList { get; private set; } = new List<Assessment>();

        public GetAssessmentsPerModuleModel(CollegeDbContext db)
        {
            _db = db;
        }

        public async Task<JsonResult> OnGetAsync()
        {
            AssessmentList = await _db.Assessments.AsNoTracking().ToListAsync();

            if (RouteData.Values["id"] != null)
            {
                modID = RouteData.Values["id"].ToString();
            }

            // @*Get assessments for this module return Page();return Page();return Page();
            if (AssessmentList.Count() != 0)
            {
                var assessmentsForThisModule = AssessmentList.Where(
                                               a => a.ModuleID == modID)
                                                     .Select(a => a);
                
                foreach (var assess in assessmentsForThisModule)
                {
                    SelectedAssessmentList.Add(assess);
                }
            }
            // return Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(SelectedAssessmentList.ToString());
            // var json = new JavaScriptSerializer().Serialize(SelectedAssessmentList);
            // return Newtonsoft.Json.JsonConvert.Des;
            // return Page();
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(SelectedAssessmentList.First());
            // return new JsonResult() { Data = json, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            return new JsonResult(json);
        }
    }
}