using Blazor.ECommerce.Data;
using Blazor.ECommerce.Repositories.IRepositories;

namespace Blazor.ECommerce.Components.Pages
{
    public partial class Home(IProductRepository productRepository, ICategoryRepository categoryRepository)
    {
        public IEnumerable<Product> Products { get; set; } = new List<Product>();
        public IEnumerable<Product> FilteredProducts { get; set; } = new List<Product>();
        public IEnumerable<Category> Categories { get; set; } = new List<Category>();

        public int _selectedCategoryId { get; set; } = 0;
        public string _searchText { get; set; } = "";
        public bool IsProcessing { get; set; } = true;

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await LoadData();

                IsProcessing = false;
                StateHasChanged();
            }
        }

        private async Task LoadData()
        {
            Products = await productRepository.GetAllAsync();
            Categories = await categoryRepository.GetAllAsync();

            FilterProducts(0);
        }

        private void FilterProducts(int categoryId)
        {
            if (categoryId == 0)
            {
                FilteredProducts = Products;
                _selectedCategoryId = categoryId;
            }
        }

        private void FilterProductsByName(string newValueOfSearchText)
        {
            if (string.IsNullOrWhiteSpace(newValueOfSearchText))
            {
                FilteredProducts = Products;
            }
            else
            {
                FilteredProducts = Products.Where(p =>
                    p.Name.Contains(newValueOfSearchText, StringComparison.InvariantCultureIgnoreCase)).ToList();
            }

            _searchText = newValueOfSearchText;
        }
    }
}
