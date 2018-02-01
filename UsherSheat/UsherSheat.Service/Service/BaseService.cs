namespace UsherSheat.Service.Service
{
    public class BaseService
    {
        protected IDataContext DataContext;

        public BaseService(IDataContext dataContext)
        {
            DataContext = dataContext;
        }
    }
}
