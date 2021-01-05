using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System.Threading.Tasks;

namespace DelayTest.Core
{
    public abstract class ComponenteCore<T> : ComponentBase where T : class
    {
        [Inject]
        protected NavigationManager NavigationManager { get; set; }

        [Inject]
        protected AuthenticationStateProvider AuthenticationStateProvider { get; set; }
    }

    public abstract class PageCore<T> : ComponenteCore<T> where T : class
    {
        protected abstract Task LoadData();

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            await LoadData();
        }
    }
}