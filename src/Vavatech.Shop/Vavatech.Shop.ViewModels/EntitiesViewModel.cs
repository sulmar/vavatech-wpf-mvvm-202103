using System.ComponentModel;
using Vavatech.Shop.IServices;

namespace Vavatech.Shop.ViewModels
{
    public class EntitiesViewModel<TEntity> : BaseViewModel
    {
        private readonly IEntityService<TEntity> entityService;
        private TEntity selectedEntity;

        public BindingList<TEntity> Entities { get; set; }

        public TEntity SelectedEntity
        {
            get => selectedEntity; set
            {
                selectedEntity = value;
                OnPropertyChanged();
            }
        }

        public EntitiesViewModel(IEntityService<TEntity> entityService)
        {
            this.entityService = entityService;

            Load();
        }

        protected virtual void Load()
        {
            Entities = entityService.Get().ToBindingList();
        }
    }
}
