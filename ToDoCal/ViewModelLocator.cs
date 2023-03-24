using DevExpress.Mvvm;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoCal.Services;
using ToDoCal.ViewModels;

namespace ToDoCal
{
    internal class ViewModelLocator
    {
        private static ServiceProvider? _provider;

        public static void Init()
        {

            var services = new ServiceCollection();

            services.AddTransient<MainWindowViewModel>();
            services.AddTransient<AllNotesViewModel>();
            services.AddTransient<SelectedDateNotesViewModel>();
            services.AddTransient<AddNoteViewModel>();

            services.AddSingleton<PageService>();

            _provider = services.BuildServiceProvider();
        }
        public MainWindowViewModel? MainWindowViewModel => _provider?.GetRequiredService<MainWindowViewModel>();
        public AllNotesViewModel? AllNotesViewModel => _provider?.GetRequiredService<AllNotesViewModel>();
        public SelectedDateNotesViewModel? SelectedDateNotesViewModel => _provider?.GetRequiredService<SelectedDateNotesViewModel>();
        public AddNoteViewModel? AddNoteViewModel => _provider?.GetRequiredService<AddNoteViewModel>();

    }
}
