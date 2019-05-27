using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JwellaryAppPOC.Navigation
{
    public interface INavigationService
    {
        string CurrentPageKey { get; }

        void Configure(string pageKey, Type pageType);
        Task PopModalAsync();
        Task PushModalAsync(string pageKey, bool animated = true);
        Task PushModalAsync(string pageKey, object parameter, bool animated = true);
        Task PushAsync(string pageKey, bool animated = true);
        Task PushAsync(string pageKey, object parameter, bool animated = true);
        Task PopAsync(bool animated);
    }
}
