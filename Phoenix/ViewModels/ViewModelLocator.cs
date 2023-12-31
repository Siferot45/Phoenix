﻿using Microsoft.Extensions.DependencyInjection;

namespace Phoenix.ViewModels
{
    internal class ViewModelLocator
    {
         public MainWindowViewModel MainWindowModel => App.Services.GetRequiredService<MainWindowViewModel>();
    }
}
