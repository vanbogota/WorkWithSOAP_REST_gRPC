using Microsoft.AspNetCore.Cors;
using System.ComponentModel.DataAnnotations;

namespace LibraryService.Web.Models
{
    public enum SearchType
    {
        [Display(Name = "Автор")]
        Author,
        [Display(Name = "Заголовок")]
        Title,
        [Display(Name = "Категория")]
        Category
    }
}
