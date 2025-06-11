using Blazor.ECommerce.Constants;
using Microsoft.AspNetCore.Components.Authorization;

namespace Blazor.ECommerce.Components.Layout
{
    public partial class MainLayout(AuthenticationStateProvider authenticationStateProvider)
    {
        private bool _IsNavbarVisible;
        protected override async Task OnInitializedAsync()
        {
            _IsNavbarVisible = await ShowNavbarAsync();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            _IsNavbarVisible = await ShowNavbarAsync();
        }

        public async Task<bool> ShowNavbarAsync()
        {
            var userState = await authenticationStateProvider.GetAuthenticationStateAsync();
            var user = userState.User;

            if (user.Identity?.IsAuthenticated ==false)
            {
                return true;
            }

            if (!user.IsInRole(RoleData.Admin))
            {
                return true;
            }

            return false;
        }
    }
}
