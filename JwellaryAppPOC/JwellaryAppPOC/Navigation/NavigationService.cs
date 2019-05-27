using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace JwellaryAppPOC.Navigation
{
    public class NavigationService : INavigationService
    {
        private readonly object _sync = new object();
        private readonly Dictionary<string, Type> _pagesByKey = new Dictionary<string, Type>();
        private readonly Stack<NavigationPage> _navigationPageStack = new Stack<NavigationPage>();

        private NavigationPage CurrentNavigationPage => _navigationPageStack.Peek();
       
       // private string currentPageKey = null;
        private bool goback = true;
        private string currentPageKey = null;

        public void Configure(string pageKey, Type pageType)
        {
            try
            {
                lock (_sync)
                {
                    if (_pagesByKey.ContainsKey(pageKey))
                    {
                        _pagesByKey[pageKey] = pageType;
                    }
                    else
                    {
                        _pagesByKey.Add(pageKey, pageType);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
            }
        }
        public Page SetRootPage(string rootPageKey)
        {
            try
            {
                var rootPage = GetPage(rootPageKey);
                _navigationPageStack.Clear();
                var mainPage = new NavigationPage(rootPage);
                _navigationPageStack.Push(mainPage);
                return mainPage;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
                return null;
            }
        }
        public string CurrentPageKey
        {
            get
            {
                lock (_sync)
                {
                    if (CurrentNavigationPage?.CurrentPage == null)
                    {
                        return null;
                    }

                    var pageType = CurrentNavigationPage.CurrentPage.GetType();

                    return _pagesByKey.ContainsValue(pageType)
                        ? _pagesByKey.First(p => p.Value == pageType).Key
                        : null;
                }
            }
        }

       

        // object INavigationService.CurrentPageKey => throw new NotImplementedException();

        private Page GetPage(string pageKey, object parameter = null)
        {
            try
            {
                lock (_sync)
                {
                    if (!_pagesByKey.ContainsKey(pageKey))
                    {
                        throw new ArgumentException(
                            $"No such page: {pageKey}. Did you forget to call NavigationService.Configure?");
                    }

                    var type = _pagesByKey[pageKey];

                    ConstructorInfo constructor;
                    object[] parameters;

                    if (parameter == null)
                    {
                        constructor = type.GetTypeInfo()
                            .DeclaredConstructors
                            .FirstOrDefault(c => !c.GetParameters().Any());

                        parameters = new object[]
                        {
                        };
                    }
                    else
                    {
                        constructor = type.GetTypeInfo()
                            .DeclaredConstructors
                            .FirstOrDefault(
                                c =>
                                {
                                    var p = c.GetParameters();
                                    return p.Length == 1
                                           && p[0].ParameterType == parameter.GetType();
                                });

                        parameters = new object[]
                        {
                    parameter
                    };
                    }

                    if (constructor == null)
                    {
                        throw new InvalidOperationException(
                            "No suitable constructor found for page " + pageKey);
                    }

                    var page = constructor.Invoke(parameters) as Page;

                    return page;
                }
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
                return null;
            }

        }

        public async Task PopAsync(bool animated = true)
        {
            try
            {
                var navigationStack = CurrentNavigationPage.Navigation;
                if (navigationStack.NavigationStack.Count > 1)
                {
                    if (goback)
                    {
                        goback = false;
                        await CurrentNavigationPage.PopAsync();

                        Device.StartTimer(new TimeSpan(0, 0, 2), () => {
                            goback = true;
                            return false;
                        });

                    }
                    else
                    {
                        return;
                    }

                }
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
            }
        }

        public async Task PopModalAsync()
        {
            try
            {
                if (_navigationPageStack.Count > 1)
                {
                    if (goback)
                    {
                        goback = false;
                        _navigationPageStack.Pop();
                        await CurrentNavigationPage.Navigation.PopModalAsync();

                        Device.StartTimer(new TimeSpan(0, 0, 2), () =>
                        {
                            goback = true;
                            return false;
                        });
                    }

                    else
                    {
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
            }
            
        }

        public async Task PushAsync(string pageKey, bool animated = true)
        {
            await PushAsync(pageKey, null, animated);
        }

        public async Task PushAsync(string pageKey, object parameter, bool animated = true)
        {
            try
            {
                var page = GetPage(pageKey, parameter);
                currentPageKey = pageKey;
                if (App.NavigationService.CurrentPageKey != currentPageKey)
                {
                    await CurrentNavigationPage.Navigation.PushAsync(page, animated);
                }
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
            }
           
        }

        public async Task PushModalAsync(string pageKey, bool animated = true)
        {
            await PushModalAsync(pageKey, null, animated);
        }

        public Task PushModalAsync(string pageKey, object parameter, bool animated = true)
        {
           
                throw new NotImplementedException();
            
           
        }
    }
}
