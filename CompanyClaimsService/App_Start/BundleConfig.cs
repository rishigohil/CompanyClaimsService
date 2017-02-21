using System.Web.Optimization;

namespace CompanyClaimsService
{
    public static class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/bundles/myapp")
                            .IncludeDirectory("~/Scripts/Controllers", "*.js")
                            .Include("~/Scripts/app.js"));

            BundleTable.EnableOptimizations = true;
        }
    }
}