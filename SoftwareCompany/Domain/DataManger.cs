using SoftwareCompany.Domain.Repositories.Abstract;
using SoftwareCompany.Domain.Repositories.EntityFramework;

namespace SoftwareCompany.Domain
{
    public class DataManger
    {
        public ITextFieldsRepository TextFields { get; set; }
        public IServiceItemsRepository ServiceItems { get; set; }

        public DataManger(ITextFieldsRepository textFieldsRepository, IServiceItemsRepository serviceItemsRepository) 
        {
            TextFields = textFieldsRepository;
            ServiceItems = serviceItemsRepository;

        }
    }
}
