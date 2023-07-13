namespace Motorsport1.Web.ViewModels.Article
{
    using System.ComponentModel.DataAnnotations;

    using static Common.GeneralApplicationConstants;
    public class AllArticlesQueryModel
    {
        public AllArticlesQueryModel()
        {
            this.CurrentPage = DefaulPage;
            this.ArticlesPerPage = EntitiesPerPage;

            this.Categories = new HashSet<string>();
            this.Articles = new HashSet<AllArticleViewModel>();
        }

        public string? Category { get; set; }

        [Display(Name = "Search")]
        public string? SearchString { get; set; }

        public int CurrentPage { get; set; }

        [Display(Name = "Articles per page")]
        public int ArticlesPerPage { get; set; }

        public int TotalArticles { get; set; }

        public IEnumerable<string> Categories { get; set; }

        public IEnumerable<AllArticleViewModel> Articles { get; set; }
    }
}
