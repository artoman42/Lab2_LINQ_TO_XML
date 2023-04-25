using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryDAL;
using LibraryBLL;
using FluentValidation;
using Library;
using LibraryBLL.Validators;

namespace LibraryUIL
{
    public static class ServiceCollections
    {
        
        public static IServiceCollection AddServices(this IServiceCollection serviceDescriptors) {
            serviceDescriptors.AddTransient<IRunner, Runner>();
            serviceDescriptors.AddTransient<IXMLClassDeserializer, XMLCLassDeserializer>();
            serviceDescriptors.AddTransient<IXMLClassReader, XMLClassReader>();
            serviceDescriptors.AddTransient<IXMLClassWriters, XMLClassWriters>();
            serviceDescriptors.AddTransient<IXClassDoc, XClassDoc>();
            serviceDescriptors.AddTransient<IQueries, Queries>();
            serviceDescriptors.AddTransient<IDictCommands, DictCommands>();
            serviceDescriptors.AddTransient<ICommands, Commands>();
            serviceDescriptors.AddTransient<IXSDValidation, XSDValidation>();

            serviceDescriptors.AddTransient<IValidator<Author>, AuthorValidator>();
            serviceDescriptors.AddTransient<IValidator<Book>, BookValidator>();
            serviceDescriptors.AddTransient<IValidator<Client>, ClientValidator>();
            serviceDescriptors.AddTransient<IValidator<Co_Author>, Co_AuthorValidator>();
            serviceDescriptors.AddTransient<IValidator<Genre>, GenreValidator>();
            serviceDescriptors.AddTransient<IValidator<Subscription>, SubscriptionValidator>();
            return serviceDescriptors;
        }
    }
}
